using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

using CircuitCrawlerEditor.Entities;
using CircuitCrawlerEditor.Triggers;

using OpenTK.Graphics.OpenGL;

namespace CircuitCrawlerEditor.Parser
{
	public static class Parser
	{
		#region Load

		public static CircuitCrawlerEditor.Level LoadLevel(String filepath)
		{
			try
			{
				Tile[][] tileset;
				List<Entity> entities;
				List<Cause> causes;
				List<Effect> effects;
				List<Trigger> triggers;
				List<Light> lights;
				LoadLevel(filepath, out tileset, out entities, out causes, out effects, out triggers, out lights);
				CircuitCrawlerEditor.Level level = new CircuitCrawlerEditor.Level();
				level.Tileset = new Tileset(tileset, new Texture(new Bitmap("Resources/Textures/tilesetworld.png"), 16, 8, TextureMinFilter.Linear, TextureMagFilter.Linear, TextureWrapMode.Clamp, TextureWrapMode.Clamp));
				level.Entities = entities;
				level.Causes = causes;
				level.Effects = effects;
				level.Triggers = triggers;
				level.Lights = lights;
				return level;
			}
			catch
			{
				return null;
			}
		}

		private static bool LoadLevel(String filepath, out Tile[][] tileset, out List<Entity> entities, out List<Cause> causes, out List<Effect> effects, out List<Trigger> triggers, out List<Light> lights)
		{
			try
			{
				StreamReader xmlReader = new StreamReader(filepath);
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Level));
				Level level = (Level)xmlSerializer.Deserialize(xmlReader);

				entities = new List<Entity>();
				causes = new List<Cause>();
				effects = new List<Effect>();
				triggers = new List<Trigger>();
				lights = new List<Light>();

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

				if (level.Entities.BreakableDoor != null)
				{
					foreach (BreakableDoorInfo bdi in level.Entities.BreakableDoor)
					{
						BreakableDoor breakableDoor = new BreakableDoor(bdi.xPos, bdi.yPos);
						breakableDoor.MaxHits = bdi.maxHits;
						breakableDoor = LoadEntity<BreakableDoorInfo, BreakableDoor>(bdi, breakableDoor);
						entities.Add(breakableDoor);
					}
				}

				if (level.Entities.Cannon != null)
				{
					foreach (CannonInfo cInfo in level.Entities.Cannon)
					{
						Cannon c = new Cannon(cInfo.xPos, cInfo.yPos);
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
						LaserShooter ls = new LaserShooter(lsi.xPos, lsi.yPos);
						ls.BeamWidth = lsi.beamWidth;
						ls.ShotsPerSecond = lsi.shotsPerSecond;
						ls.Stupidity = lsi.stupidity;
						ls = LoadEntity<LaserShooterInfo, LaserShooter>(lsi, ls);
						entities.Add(ls);
					}
				}

				if (level.Entities.Ball != null)
				{
					foreach (BallInfo ballInfo in level.Entities.Ball)
					{
						Ball ball = new Ball(ballInfo.xPos, ballInfo.yPos);
						ball.Friction = ballInfo.friction;
						ball = LoadEntity<BallInfo, Ball>(ballInfo, ball);
						entities.Add(ball);
					}
				}

				if (level.Entities.Block != null)
				{
					foreach (BlockInfo blockInfo in level.Entities.Block)
					{
						Block block = new Block(blockInfo.xPos, blockInfo.yPos);
						block.Friction = blockInfo.friction;
						block = LoadEntity<BlockInfo, Block>(blockInfo, block);
						entities.Add(block);
					}
				}

				if (level.Entities.Player != null)
				{
					PlayerInfo pi = level.Entities.Player;
					Player player = new Player(pi.xPos, pi.yPos);
					player = LoadEntity<PlayerInfo, Player>(pi, player);
					entities.Add(player);
				}

				if (level.Entities.PuzzleBox != null)
				{
					foreach (PuzzleBoxInfo pbi in level.Entities.PuzzleBox)
					{
						PuzzleBox pb = new PuzzleBox(pbi.xPos, pbi.yPos);
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
						Teleporter t = new Teleporter(tInfo.xPos, tInfo.yPos);
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

				#region Load Lights

				if (level.Lights != null)
				{
					for (int i = 0; i < level.Lights.Length; i++)
					{
						LightInfo ll = level.Lights[i];
						Light l = new Light();
						l.Index = ll.index;
						string[] ambient = ll.ambient.Split(',');
						l.AmbientR = float.Parse(ambient[0]);
						l.AmbientG = float.Parse(ambient[1]);
						l.AmbientB = float.Parse(ambient[2]);
						l.AmbientA = float.Parse(ambient[3]);
						string[] diffuse = ll.diffuse.Split(',');
						l.DiffuseR = float.Parse(diffuse[0]);
						l.DiffuseG = float.Parse(diffuse[1]);
						l.DiffuseB = float.Parse(diffuse[2]);
						l.DiffuseA = float.Parse(diffuse[3]);
						string[] position = ll.position.Split(',');
						l.PositionX = float.Parse(position[0]);
						l.PositionY = float.Parse(position[1]);
						l.PositionZ = float.Parse(position[2]);
						l.PositionW = float.Parse(position[3]);
						l.ConstantAttenuation = ll.constAtten;
						l.LinearAttenuation = ll.linAtten;
						l.QuadraticAttenuation = ll.quadAtten;
						lights.Add(l);
					}
				}

				#endregion

				UIEntListEditor.entList = entities;
				UICauseListEditor.causeList = causes;
				UIEffectListEditor.effectList = effects;
				UIFormEffectListEditor.effectList = effects;

				return true;
			}
			catch (Exception e)
			{
				causes = null;
				effects = null;
				entities = null;
				tileset = null;
				triggers = null;
				lights = null;
				System.Windows.Forms.MessageBox.Show("Error. Unable to load level. Reason: " + e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
		}

		public static K LoadEntity<T, K>(T info, K ent)
			where T : EntityInfo
			where K : Entity
		{
			if (info.id != null)
				ent.ID = info.id;
			if (info.angleSpecified)
				ent.Angle = info.angle - 90;

			return ent;
		}

		#endregion

		#region Save

		public static void SaveLevel(String filepath, CircuitCrawlerEditor.Level level)
		{
			SaveLevel(filepath, level.Tileset.Tiles, level.Entities, level.Causes, level.Effects, level.Triggers, level.Lights);
		}

		private static void SaveLevel(String filepath, Tile[][] tileset, List<Entity> entList, List<Cause> causeList, List<Effect> effectList, List<Trigger> triggerList, List<Light> lightList)
		{
			Level level = new Level();

			try
			{
				#region Save Tileset

				level.Tileset = new LevelTileset();

				int x = tileset[0].Length;
				int y = tileset.Length;

				level.Tileset.x = x.ToString();
				level.Tileset.y = y.ToString();

				level.Tileset.Tile = new TileInfo[tileset[0].Length * tileset.Length];

				for (int i = 0; i < y; i++)
				{
					for (int j = 0; j < x; j++)
					{
						level.Tileset.Tile[i * x + j] = new TileInfo();
						level.Tileset.Tile[i * x + j].state = (tileStateType)tileset[i][j].TileType;
					}
				}

				#endregion

				#region Save Entities

				level.Entities = new LevelEntities();

				Player player = (Player)entList.Find(ent => ent is Player);
				if (player != null)
				{
					player.ID = Guid.NewGuid().ToString();
					level.Entities.Player = new PlayerInfo();
					level.Entities.Player = SaveEntity<PlayerInfo, Player>(level.Entities.Player, player);
				}

				List<Entity> buttonList = entList.FindAll(ent => ent is Button);
				if (buttonList.Count > 0)
				{
					level.Entities.Button = new ButtonInfo[buttonList.Count];
					for (int i = 0; i < buttonList.Count; i++)
					{
						buttonList[i].ID = Guid.NewGuid().ToString();
						level.Entities.Button[i] = new ButtonInfo();
						level.Entities.Button[i] = SaveEntity<ButtonInfo, Button>(level.Entities.Button[i], (Button)buttonList[i]);
					}
				}

				List<Entity> breakableDoorList = entList.FindAll(ent => ent is BreakableDoor);
				if (breakableDoorList.Count > 0)
				{
					level.Entities.BreakableDoor = new BreakableDoorInfo[breakableDoorList.Count];
					for (int i = 0; i < breakableDoorList.Count; i++)
					{
						breakableDoorList[i].ID = Guid.NewGuid().ToString();
						level.Entities.BreakableDoor[i] = new BreakableDoorInfo();
						level.Entities.BreakableDoor[i].maxHits = ((BreakableDoor)breakableDoorList[i]).MaxHits;
						level.Entities.BreakableDoor[i] = SaveEntity<BreakableDoorInfo, BreakableDoor>(level.Entities.BreakableDoor[i], (BreakableDoor)breakableDoorList[i]);
					}
				}

				List<Entity> cannonList = entList.FindAll(ent => ent is Cannon);
				if (cannonList.Count > 0)
				{
					level.Entities.Cannon = new CannonInfo[cannonList.Count];
					for (int i = 0; i < cannonList.Count; i++)
					{
						cannonList[i].ID = Guid.NewGuid().ToString();
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
						doorList[i].ID = Guid.NewGuid().ToString();
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
						laserShooterList[i].ID = Guid.NewGuid().ToString();
						LaserShooter ls = (LaserShooter)laserShooterList[i];
						level.Entities.LaserShooter[i] = new LaserShooterInfo();
						level.Entities.LaserShooter[i].shotsPerSecond = ls.ShotsPerSecond;
						level.Entities.LaserShooter[i].beamWidth = ls.BeamWidth;
						level.Entities.LaserShooter[i].stupidity = ls.Stupidity;
						level.Entities.LaserShooter[i] = SaveEntity<LaserShooterInfo, LaserShooter>(level.Entities.LaserShooter[i], ls);
					}
				}

				List<Entity> BallList = entList.FindAll(ent => ent is Ball);
				if (BallList.Count > 0)
				{
					level.Entities.Ball = new BallInfo[BallList.Count];
					for (int i = 0; i < BallList.Count; i++)
					{
						BallList[i].ID = Guid.NewGuid().ToString();
						level.Entities.Ball[i] = new BallInfo();
						level.Entities.Ball[i].friction = ((Ball)BallList[i]).Friction;
						level.Entities.Ball[i] = SaveEntity(level.Entities.Ball[i], (Ball)BallList[i]);
					}
				}

				List<Entity> blockList = entList.FindAll(ent => ent is Block);
				if (blockList.Count > 0)
				{
					level.Entities.Block = new BlockInfo[blockList.Count];
					for (int i = 0; i < blockList.Count; i++)
					{
						blockList[i].ID = Guid.NewGuid().ToString();
						level.Entities.Block[i] = new BlockInfo();
						level.Entities.Block[i].friction = ((Block)blockList[i]).Friction;
						level.Entities.Block[i] = SaveEntity(level.Entities.Block[i], (Block)blockList[i]);
					}
				}

				List<Entity> puzzleBoxList = entList.FindAll(ent => ent is PuzzleBox);
				if (puzzleBoxList.Count > 0)
				{
					level.Entities.PuzzleBox = new PuzzleBoxInfo[puzzleBoxList.Count];
					for (int i = 0; i < puzzleBoxList.Count; i++)
					{
						puzzleBoxList[i].ID = Guid.NewGuid().ToString();
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
						spikeWallList[i].ID = Guid.NewGuid().ToString();
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
						teleporterList[i].ID = Guid.NewGuid().ToString();
						level.Entities.Teleporter[i] = new TeleporterInfo();
						level.Entities.Teleporter[i] = SaveEntity(level.Entities.Teleporter[i], (Block)teleporterList[i]);
					}
				}

				#endregion

				level.Triggers = new LevelTriggers();

				#region Save Causes

				if (causeList.Count > 0)
				{
					for (int i = 0; i < causeList.Count; i++)
					{
						causeList[i].ID = Guid.NewGuid().ToString();
					}

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
					for (int i = 0; i < effectList.Count; i++)
					{
						effectList[i].ID = Guid.NewGuid().ToString();
					}

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
						level.Triggers.Effect[i] = SaveTriggerEffect(parseList[i]);
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

				#region Save Lights

				level.Lights = new LightInfo[lightList.Count];

				for (int i = 0; i < lightList.Count; i++ )
				{
					Light l = lightList[i];
					LightInfo ll = new LightInfo();
					ll.index = l.Index;
					ll.ambient = l.AmbientR + "," + l.AmbientG + "," + l.AmbientB + "," + l.AmbientA;
					ll.diffuse = l.DiffuseR + "," + l.DiffuseG + "," + l.DiffuseB + "," + l.DiffuseB;
					ll.position = l.PositionX + "," + l.PositionY + "," + l.PositionZ + "," + l.PositionW;
					ll.constAtten = l.ConstantAttenuation;
					ll.linAtten = l.LinearAttenuation;
					ll.quadAtten = l.QuadraticAttenuation;
					level.Lights[i] = ll;
				}

				#endregion

				XmlSerializer serializer = new XmlSerializer(level.GetType());
				StreamWriter writer = new StreamWriter(filepath);
				serializer.Serialize(writer, level);
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show("Error. Unable to save level. Reason: " + e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		public static T SaveEntity<T, K>(T info, K ent)
			where T : EntityInfo
			where K : Entity
		{
			info.id = ent.ID;
			info.xPos = ent.XPos;
			info.yPos = ent.YPos;

			info.angleSpecified = true;

			info.angle = ent.Angle + 90;

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

		private static LevelTriggersEffect SaveTriggerEffect(Effect e)
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
						effects += effectsList.ID + ",";
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
