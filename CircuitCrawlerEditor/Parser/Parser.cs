﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

using CircuitCrawlerEditor.Entities;
using CircuitCrawlerEditor.Parser;
using CircuitCrawlerEditor.Triggers;

namespace CircuitCrawlerEditor.Parser
{
    public static class Parser
	{
		#region Load

		public static void loadLevel(String filepath, out Tile[][] tileset, out List<Entity> entities, out List<Cause> causes, out List<Effect> effects, out List<Trigger> triggers)
		{
			StreamReader xmlReader = new StreamReader(filepath);
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Level));
			Level level = (Level)xmlSerializer.Deserialize(xmlReader);

			entities = new List<Entity>();
			causes = new List<Cause>();
			effects = new List<Effect>();
			triggers = new List<Trigger>();

			#region Load Tileset

			int x = Convert.ToInt32(level.Tileset.x);
			int y = Convert.ToInt32(level.Tileset.y);

			tileset = new Tile[y][];

			for (int i = 0; i < tileset.Length; i++)
			{
				tileset[i] = new Tile[x];
			}

			for (int i = 0; i < y; i++)
				for (int j = 0; j < x; j++)
					tileset[i][j] = new Tile(new Point(j, i), x, y, (TileType)level.Tileset.Tile[i * x + j].state);

			#endregion

			#region Load Entities

			if (level.Entities.Button != null)
			{
				foreach (ButtonInfo bInfo in level.Entities.Button)
				{
					Button b = new Button(bInfo.xPos, bInfo.yPos);
					b = LoadEntity<ButtonInfo, Button>(bInfo, b);
					entities.Add(b);
				}
			}

			if (level.Entities.Cannon != null)
			{
				foreach (CannonInfo cInfo in level.Entities.Cannon)
				{
					Cannon c = new Cannon(cInfo.size, cInfo.xPos, cInfo.yPos);
					c.BallSpeed = cInfo.shotVelocity;
					c.Stupidity = cInfo.stupidity;
					c = LoadEntity<CannonInfo, Cannon>(cInfo, c);
					entities.Add(c);
				}
			}

			if (level.Entities.Door != null)
			{
				foreach (DoorInfo dInfo in level.Entities.Door)
				{
					Door d = new Door(dInfo.xPos, dInfo.yPos);
					d.Dir = (Direction)dInfo.dir;
					d = LoadEntity<DoorInfo, Door>(dInfo, d);
					entities.Add(d);
				}
			}

			if (level.Entities.LaserShooter != null)
			{
				foreach (LaserShooterInfo lsi in level.Entities.LaserShooter)
				{
					LaserShooter ls = new LaserShooter(lsi.size, lsi.xPos, lsi.yPos);
					ls.BeamWidth = lsi.beamWidth;
					ls.ShotsPerSecond = lsi.shotsPerSecond;
					ls.Stupidity = lsi.stupidity;
					ls = LoadEntity<LaserShooterInfo, LaserShooter>(lsi, ls);
					entities.Add(ls);
				}
			}

			if (level.Entities.PhysBall != null)
			{
				foreach (PhysBallInfo ballInfo in level.Entities.PhysBall)
				{
					Ball ball = new Ball(ballInfo.size, ballInfo.xPos, ballInfo.yPos);
					ball.Friction = ballInfo.friction;
					ball = LoadEntity<PhysBallInfo, Ball>(ballInfo, ball);
					entities.Add(ball);
				}
			}

			if (level.Entities.PhysBlock != null)
			{
				foreach (PhysBlockInfo blockInfo in level.Entities.PhysBlock)
				{
					Block block = new Block(blockInfo.size, blockInfo.xPos, blockInfo.yPos);
					block.Friction = blockInfo.friction;
					block = LoadEntity<PhysBlockInfo, Block>(blockInfo, block);
					entities.Add(block);
				}
			}

			if (level.Entities.Player != null)
			{
				PlayerInfo pi = level.Entities.Player;
				Player player = new Player(pi.size, pi.xPos, pi.yPos);
				player = LoadEntity<PlayerInfo, Player>(pi, player);
				entities.Add(player);
			}

			if (level.Entities.PuzzleBox != null)
			{
				foreach (PuzzleBoxInfo pbi in level.Entities.PuzzleBox)
				{
					PuzzleBox pb = new PuzzleBox(pbi.size, pbi.xPos, pbi.yPos);
					pb = LoadEntity<PuzzleBoxInfo, PuzzleBox>(pbi, pb);
					entities.Add(pb);
				}
			}

			if (level.Entities.SpikeWall != null)
			{
				foreach (SpikeWallInfo swi in level.Entities.SpikeWall)
				{
					SpikeWall sw = new SpikeWall(swi.xPos, swi.yPos);
					sw.Dir = (Direction)swi.dir;
					sw = LoadEntity<SpikeWallInfo, SpikeWall>(swi, sw);
					entities.Add(sw);
				}
			}

			if (level.Entities.Teleporter != null)
			{
				foreach (TeleporterInfo tInfo in level.Entities.Teleporter)
				{
					Teleporter t = new Teleporter(tInfo.size, tInfo.xPos, tInfo.yPos);
					t = LoadEntity<TeleporterInfo, Teleporter>(tInfo, t);
					entities.Add(t);
				}
			}

			#endregion

			if (level.Triggers != null)
			{
				#region Load Causes

				if (level.Triggers.Cause != null)
				{
					foreach (LevelTriggersCause curCause in level.Triggers.Cause)
					{
						switch (curCause.type)
						{
							case causeType.CauseAND:
								{
									CauseAND c = new CauseAND();
									string[] data = curCause.Value.Split(',');
									c.Cause1 = causes.Find(cause => cause.ID == data[0]);
									c.Cause2 = causes.Find(cause => cause.ID == data[1]);
									c.ID = curCause.id;
									causes.Add(c);
									break;
								}
							case causeType.CauseButton:
								{
									CauseButton c = new CauseButton();
									c.Button = entities.Find(ent => ent.ID == curCause.Value) as Button;
									c.ID = curCause.id;
									causes.Add(c);
									break;
								}
							case causeType.CauseEntityDestruction:
								{
									CauseEntityDestruction c = new CauseEntityDestruction();
									c.Entity = entities.Find(ent => ent.ID == curCause.Value);
									c.ID = curCause.id;
									causes.Add(c);
									break;
								}
							case causeType.CauseLocation:
								{
									CauseLocation c = new CauseLocation();
									string[] data = curCause.Value.Split(',');
									c.Player = entities.Find(ent => ent.ID == data[0]) as Player;
									c.MinimumX = float.Parse(data[1]);
									c.MaximumX = float.Parse(data[2]);
									c.MinimumY = float.Parse(data[3]);
									c.MaximumY = float.Parse(data[4]);
									c.ID = curCause.id;
									causes.Add(c);
									break;
								}
							case causeType.CauseNOT:
								{
									CauseNOT c = new CauseNOT();
									c.Cause = causes.Find(cause => cause.ID == curCause.Value);
									c.ID = curCause.id;
									causes.Add(c);
									break;
								}
							case causeType.CauseOR:
								{
									CauseOR c = new CauseOR();
									string[] data = curCause.Value.Split(',');
									c.Cause1 = causes.Find(cause => cause.ID == data[0]);
									c.Cause2 = causes.Find(cause => cause.ID == data[1]);
									c.ID = curCause.id;
									causes.Add(c);
									break;
								}
							case causeType.CauseTimePassed:
								{
									CauseTimePassed c = new CauseTimePassed();
									c.TriggerTime = int.Parse(curCause.Value);
									c.ID = curCause.id;
									causes.Add(c);
									break;
								}
							case causeType.CauseXOR:
								{
									CauseXOR c = new CauseXOR();
									string[] data = curCause.Value.Split(',');
									c.Cause1 = causes.Find(cause => cause.ID == data[0]);
									c.Cause2 = causes.Find(cause => cause.ID == data[1]);
									c.ID = curCause.id;
									causes.Add(c);
									break;
								}
						}
					}
				}

				#endregion

				#region Load Effects

				if (level.Triggers.Effect != null)
				{
					foreach (LevelTriggersEffect curEffect in level.Triggers.Effect)
					{
						switch (curEffect.type)
						{
							case effectType.EffectAND:
								{
									EffectAND e = new EffectAND();
									string[] data = curEffect.Value.Split(',');
									e.Effect1 = effects.Find(effect => effect.ID == data[0]);
									e.Effect2 = effects.Find(effect => effect.ID == data[1]);
									e.ID = curEffect.id;
									effects.Add(e);
									break;
								}
							case effectType.EffectDoor:
								{
									EffectDoor e = new EffectDoor();
									e.Door = entities.Find(ent => ent.ID == curEffect.Value) as Door;
									e.ID = curEffect.id;
									effects.Add(e);
									break;
								}
							case effectType.EffectEndGame:
								{
									EffectEndGame e = new EffectEndGame();
									e.CharlieSheen = bool.Parse(curEffect.Value);
									e.ID = curEffect.id;
									effects.Add(e);
									break;
								}
							case effectType.EffectList:
								{
									EffectList e = new EffectList();
									string[] data = curEffect.Value.Split(',');
									foreach (string s in data)
									{
										e.List.Add(effects.Find(effect => effect.ID == s));
									}
									effects.Add(e);
									break;
								}
							case effectType.EffectRaiseBridge:
								{
									EffectRaiseBridge e = new EffectRaiseBridge();
									string[] data = curEffect.Value.Split(',');
									e.TileX = int.Parse(data[0]);
									e.TileY = int.Parse(data[1]);
									e.ID = curEffect.id;
									effects.Add(e);
									break;
								}
							case effectType.EffectRemoveEntity:
								{
									EffectRemoveEntity e = new EffectRemoveEntity();
									e.Entity = entities.Find(ent => ent.ID == curEffect.Value);
									e.ID = curEffect.id;
									effects.Add(e);
									break;
								}
							case effectType.EffectTriggerTimer:
								{
									EffectTriggerTimer e = new EffectTriggerTimer();
									e.Cause = causes.Find(cause => cause.ID == curEffect.Value) as CauseTimePassed;
									e.ID = curEffect.id;
									effects.Add(e);
									break;
								}
						}
					}
				}

				#endregion

				#region Load Triggers

				if (level.Triggers.Trigger != null)
				{
					foreach (LevelTriggersTrigger triggerData in level.Triggers.Trigger)
					{
						Trigger t = new Trigger();
						t.Cause = causes.Find(cause => cause.ID == triggerData.cause);
						t.Effect = effects.Find(effect => effect.ID == triggerData.effect);
						triggers.Add(t);
					}
				}

				#endregion
			}

			UIEntListEditor.entList = entities;
			UICauseListEditor.causeList = causes;
			UIEffectListEditor.effectList = effects;
			UIFormEffectListEditor.effectList = effects;
		}

		public static K LoadEntity<T, K>(T info, K ent)
			where T : EntityInfo
			where K : Entity
		{
			if (info.id != null)
				ent.ID = info.id;
			if (info.size != null)
				ent.Size = info.size;
			if (info.angleSpecified)
				ent.Angle = info.angle;

			return ent;
		}

		#endregion

		#region Save

		public static void saveLevel(String filepath, Tile[][] tileset, List<Entity> entList, List<Cause> causeList, List<Effect> effectList, List<Trigger> triggerList)
        {
			Level level = new Level();

			#region Save Tileset

			level.Tileset = new LevelTileset();

			int x = tileset[0].Length;
			int y = tileset.Length;

			level.Tileset.x = x.ToString();
			level.Tileset.y = y.ToString();

			level.Tileset.Tile = new TileInfo[tileset[0].Length * tileset.Length];
			for (int i = 0; i < tileset.Length; i++)
			{
				for (int j = 0; j < tileset[0].Length; j++)
				{
					level.Tileset.Tile[i * x + j] = new TileInfo();
					level.Tileset.Tile[i * x + j].state = (tileStateType)tileset[i][j].TileType;
				}
			}

			#endregion

			#region Save Entities

			level.Entities = new LevelEntities();

			List<Entity> buttonList = entList.FindAll(ent => ent is Button);
			if (buttonList.Count > 0)
			{
				level.Entities.Button = new ButtonInfo[buttonList.Count];
				for (int i = 0; i < buttonList.Count; i++)
				{
					level.Entities.Button[i] = new ButtonInfo();
					level.Entities.Button[i] = SaveEntity<ButtonInfo, Button>(level.Entities.Button[i], (Button)buttonList[i]);
				}
			}

			List<Entity> cannonList = entList.FindAll(ent => ent is Cannon);
			if (cannonList.Count > 0)
			{
				level.Entities.Cannon = new CannonInfo[cannonList.Count];
				for (int i = 0; i < cannonList.Count; i++)
				{
					Cannon c = (Cannon)cannonList[i];
					level.Entities.Cannon[i] = new CannonInfo();
					level.Entities.Cannon[i].shotVelocity = c.BallSpeed;
					level.Entities.Cannon[i].stupidity = c.Stupidity;
					level.Entities.Cannon[i] = SaveEntity<CannonInfo, Cannon>(level.Entities.Cannon[i], c);
				}
			}

			List<Entity> doorList = entList.FindAll(ent => ent is Door);
			if (doorList.Count > 0)
			{
				level.Entities.Door = new DoorInfo[doorList.Count];
				for (int i = 0; i < doorList.Count; i++)
				{
					level.Entities.Door[i] = new DoorInfo();
					level.Entities.Door[i].dir = (directionType)((Door)doorList[i]).Dir;
					level.Entities.Door[i] = SaveEntity<DoorInfo, Door>(level.Entities.Door[i], (Door)doorList[i]);
				}
			}

			List<Entity> laserShooterList = entList.FindAll(ent => ent is LaserShooter);
			if (laserShooterList.Count > 0)
			{
				level.Entities.LaserShooter = new LaserShooterInfo[laserShooterList.Count];
				for (int i = 0; i < laserShooterList.Count; i++)
				{
					LaserShooter ls = (LaserShooter)laserShooterList[i];
					level.Entities.LaserShooter[i] = new LaserShooterInfo();
					level.Entities.LaserShooter[i].shotsPerSecond = ls.ShotsPerSecond;
					level.Entities.LaserShooter[i].beamWidth = ls.BeamWidth;
					level.Entities.LaserShooter[i].stupidity = ls.Stupidity;
					level.Entities.LaserShooter[i] = SaveEntity<LaserShooterInfo, LaserShooter>(level.Entities.LaserShooter[i], ls);
				}
			}

			List<Entity> physBallList = entList.FindAll(ent => ent is Ball);
			if (physBallList.Count > 0)
			{
				level.Entities.PhysBall = new PhysBallInfo[physBallList.Count];
				for (int i = 0; i < physBallList.Count; i++)
				{
					level.Entities.PhysBall[i] = new PhysBallInfo();
					level.Entities.PhysBall[i].friction = ((Ball)physBallList[i]).Friction;
					level.Entities.PhysBall[i] = SaveEntity(level.Entities.PhysBall[i], (Ball)physBallList[i]);
				}
			}

			List<Entity> physBlockList = entList.FindAll(ent => ent is Block);
			if (physBlockList.Count > 0)
			{
				level.Entities.PhysBlock = new PhysBlockInfo[physBlockList.Count];
				for (int i = 0; i < physBlockList.Count; i++)
				{
					level.Entities.PhysBlock[i] = new PhysBlockInfo();
					level.Entities.PhysBlock[i].friction = ((Block)physBlockList[i]).Friction;
					level.Entities.PhysBlock[i] = SaveEntity(level.Entities.PhysBlock[i], (Block)physBlockList[i]);
				}
			}

			List<Entity> puzzleBoxList = entList.FindAll(ent => ent is PuzzleBox);
			if (puzzleBoxList.Count > 0)
			{
				level.Entities.PuzzleBox = new PuzzleBoxInfo[puzzleBoxList.Count];
				for (int i = 0; i < puzzleBoxList.Count; i++)
				{
					level.Entities.PuzzleBox[i] = new PuzzleBoxInfo();
					level.Entities.PuzzleBox[i] = SaveEntity(level.Entities.PuzzleBox[i], (PuzzleBox)puzzleBoxList[i]);
				}
			}

			List<Entity> spikeWallList = entList.FindAll(ent => ent is SpikeWall);
			if (spikeWallList.Count > 0)
			{
				level.Entities.SpikeWall = new SpikeWallInfo[spikeWallList.Count];
				for (int i = 0; i < spikeWallList.Count; i++)
				{
					level.Entities.SpikeWall[i] = new SpikeWallInfo();
					level.Entities.SpikeWall[i].dir = (directionType)((SpikeWall)spikeWallList[i]).Dir;
					level.Entities.SpikeWall[i] = SaveEntity<SpikeWallInfo, SpikeWall>(level.Entities.SpikeWall[i], (SpikeWall)spikeWallList[i]);
				}
			}

			List<Entity> teleporterList = entList.FindAll(ent => ent is Teleporter);
			if (teleporterList.Count > 0)
			{
				level.Entities.Teleporter = new TeleporterInfo[teleporterList.Count];
				for (int i = 0; i < teleporterList.Count; i++)
				{
					level.Entities.Teleporter[i] = new TeleporterInfo();
					level.Entities.Teleporter[i] = SaveEntity(level.Entities.Teleporter[i], (Block)teleporterList[i]);
				}
			}

			#endregion

			level.Triggers = new LevelTriggers();

			#region Save Causes

			if (causeList.Count > 0)
			{
				level.Triggers.Cause = new LevelTriggersCause[causeList.Count];

				List<Cause> startList = new List<Cause>();
				List<Cause> parseList = new List<Cause>();
				foreach (Cause c in causeList)
					startList.Add(c);

				List<Cause> refList = new List<Cause>();
				refList = startList.FindAll(cause => cause is CauseAND || cause is CauseOR || cause is CauseNOT || cause is CauseXOR);
				foreach (Cause c in refList)
					startList.Remove(c);

				List<int> refCount = new List<int>();
				while (refCount.Count != refList.Count)
					refCount.Add(0);


				for (int i = 0; i < refList.Count; i++)
				{
					Cause c = refList[i];
					int refs = 0;
					foreach (Cause cCompare in refList)
					{
						if (cCompare is CauseAND)
						{
							if (((CauseAND)cCompare).Cause1 == c || ((CauseAND)cCompare).Cause2 == c)
								refs++;
						}
						else if (cCompare is CauseOR)
						{
							if (((CauseOR)cCompare).Cause1 == c || ((CauseOR)cCompare).Cause2 == c)
								refs++;
						}
						else if (cCompare is CauseNOT)
						{
							if (((CauseNOT)cCompare).Cause == c)
								refs++;
						}
						else if (cCompare is CauseXOR)
						{
							if (((CauseXOR)cCompare).Cause1 == c || ((CauseXOR)cCompare).Cause2 == c)
								refs++;
						}
					}
					refCount[i] = refs;
				}

				int refNum = 0;
				for (int i = 0; i < refCount.Count; i++)
				{
					if (refCount[i] > refNum)
						refNum = refCount[i];
				}

				List<Cause> removeList = new List<Cause>();
				for (int i = 0; i <= refNum; i++)
				{
					for (int j = 0; j < refList.Count; j++)
					{
						if (refCount[j] <= i)
						{
							parseList.Add(refList[j]);
							removeList.Add(refList[j]);
						}
					}

					foreach (Cause c in removeList)
						refList.Remove(c);

					removeList.Clear();
				}

				foreach (Cause c in startList)
					parseList.Add(c);

				parseList.Reverse();

				for (int i = 0; i < parseList.Count; i++)
					level.Triggers.Cause[i] = saveTriggerCause(parseList[i]);
			}

			#endregion

			#region Save Effects

			if (effectList.Count > 0)
			{
				level.Triggers.Effect = new LevelTriggersEffect[effectList.Count];

				List<Effect> startList = new List<Effect>();
				List<Effect> parseList = new List<Effect>();
				foreach (Effect e in effectList)
					startList.Add(e);

				List<Effect> refList = new List<Effect>();
				refList = startList.FindAll(effect => effect is EffectAND || effect is EffectList);
				foreach (Effect e in refList)
					startList.Remove(e);

				List<int> refCount = new List<int>();
				while (refCount.Count != refList.Count)
					refCount.Add(-1);


				for (int i = 0; i < refList.Count; i++)
				{
					Effect e = refList[i];
					int refs = 0;
					foreach (Effect eCompare in refList)
					{
						if (eCompare is EffectAND)
						{
							if (((EffectAND)eCompare).Effect1 == e || ((EffectAND)eCompare).Effect2 == e)
								refs++;
						}

						else if (eCompare is EffectList)
						{
							foreach (Effect lEffect in ((EffectList)eCompare).List)
							{
								if (eCompare == lEffect)
								{
									refs++;
									break;
								}
							}
						}
					}
					refCount[i] = refs;
				}

				int refNum = 0;
				for (int i = 0; i < refCount.Count; i++)
				{
					if (refCount[i] > refNum)
						refNum = refCount[i];
				}

				List<Effect> removeList = new List<Effect>();
				for (int i = 0; i <= refNum; i++)
				{
					for (int j = 0; j < refList.Count; j++)
					{
						if (refCount[j] <= i)
						{
							parseList.Add(refList[j]);
							removeList.Add(refList[j]);
						}
					}

					foreach (Effect e in removeList)
						refList.Remove(e);

					removeList.Clear();
				}

				foreach (Effect e in startList)
					parseList.Add(e);

				parseList.Reverse();

				for (int i = 0; i < parseList.Count; i++)
					level.Triggers.Effect[i] = saveTriggerEffect(parseList[i]);
			}

			#endregion

			#region Save Triggers

			if (triggerList.Count > 0)
			{
				if (level.Triggers == null)
					level.Triggers = new LevelTriggers();

				level.Triggers.Trigger = new LevelTriggersTrigger[triggerList.Count];

				for (int i = 0; i < triggerList.Count; i++)
				{
					LevelTriggersTrigger tData = new LevelTriggersTrigger();
					tData.cause = triggerList[i].Cause.ID;
					tData.effect = triggerList[i].Effect.ID;
					level.Triggers.Trigger[i] = tData;
				}
			}

			#endregion
		}

		public static T SaveEntity<T, K>(T info, K ent)
			where T : EntityInfo
			where K : Entity
		{
			info.id = ent.ID;
			info.size = ent.Size;
			info.xPos = ent.XPos;
			info.yPos = ent.YPos;

			info.angleSpecified = true;

			info.angle = ent.Angle;

			return info;
		}

		public static LevelTriggersCause saveTriggerCause(Cause c)
		{
			LevelTriggersCause causeData = new LevelTriggersCause();
			switch (c.GetType().Name)
			{
				case "CauseAND":
					CauseAND cAND = (CauseAND)c;
					causeData.Value = cAND.Cause1.ID + "," + cAND.Cause2.ID;
					causeData.type = causeType.CauseAND;
					break;
				case "CauseButton":
					causeData.Value = ((CauseButton)c).Button.ID;
					causeData.type = causeType.CauseButton;
					break;
				case "CauseEntityDestruction":
					causeData.Value = ((CauseEntityDestruction)c).Entity.ID;
					causeData.type = causeType.CauseEntityDestruction;
					break;
				case "CauseLocation":
					CauseLocation cl = (CauseLocation)c;
					causeData.Value = cl.Player + "," + cl.MinimumX + "," + cl.MaximumX + "," + cl.MinimumY + "," + cl.MaximumY;
					causeData.type = causeType.CauseLocation;
					break;
				case "CauseNOT":
					causeData.Value = ((CauseNOT)c).Cause.ID;
					causeData.type = causeType.CauseNOT;
					break;
				case "CauseOR":
					CauseOR cOR = (CauseOR)c;
					causeData.Value = cOR.Cause1.ID + "," + cOR.Cause2.ID;
					causeData.type = causeType.CauseOR;
					break;
				case "CauseTimePassed":
					causeData.Value = ((CauseTimePassed)c).TriggerTime.ToString();
					causeData.type = causeType.CauseTimePassed;
					break;
				case "CauseXOR":
					CauseXOR cXOR = (CauseXOR)c;
					causeData.Value = cXOR.Cause1.ID + "," + cXOR.Cause2.ID;
					causeData.type = causeType.CauseXOR;
					break;
				default:
					return null;
			}
			causeData.id = c.ID;
			return causeData;
		}

		public static LevelTriggersEffect saveTriggerEffect(Effect e)
		{
			LevelTriggersEffect effectData = new LevelTriggersEffect();
			switch (e.GetType().Name)
			{
				case "EffectAND":
					EffectAND eAND = (EffectAND)e;
					effectData.Value = eAND.Effect1.ID + "," + eAND.Effect2.ID;
					effectData.type = effectType.EffectAND;
					break;
				case "EffectDoor":
					effectData.Value = ((EffectDoor)e).Door.ID;
					effectData.type = effectType.EffectDoor;
					break;
				case "EffectEndGame":
					effectData.Value = ((EffectEndGame)e).CharlieSheen.ToString();
					effectData.type = effectType.EffectEndGame;
					break;
				case "EffectList":
					string effects = "";
					foreach (Effect effectsList in ((EffectList)e).List)
						effects += effectsList.ID;
					effectData.Value = effects;
					effectData.type = effectType.EffectList;
					break;
				case "EffectRaiseBridge":
					EffectRaiseBridge eRB = (EffectRaiseBridge)e;
					effectData.Value = eRB.TileX + "," + eRB.TileY ;
					effectData.type = effectType.EffectRaiseBridge;
					break;
				case "EffectRemoveEntity":
					effectData.Value = ((EffectRemoveEntity)e).Entity.ID;
					effectData.type = effectType.EffectRemoveEntity;
					break;
				case "EffectTriggerTimer":
					effectData.Value = ((EffectTriggerTimer)e).Cause.ID;
					effectData.type = effectType.EffectTriggerTimer;
					break;
				default:
					return null;
			}
			effectData.id = e.ID;
			return effectData;
		}

		#endregion
	}
}