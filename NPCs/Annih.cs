using Glorymod.Buffs;
using Glorymod.Items.Accessories.PreHm;
using Glorymod.Items.Weapons.Melee;
using Glorymod.Items.Weapons.Ranged;
using Glorymod.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Glorymod.NPCs
{
	[AutoloadBossHead]
	internal class Annih1 : Annih
	{
		public override bool CheckActive()
		{
			return false;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Crystallizing>(), 300);
		}
		public override bool CheckDead()
		{
			NPC.downedBoss2 = true;
			return true;
		}
		public override void NPCLoot()
		{
			Item.NewItem(npc.Center, ItemID.EaterOfWorldsBossBag);
			Item.NewItem(npc.Center, ModContent.ItemType<PellucidCore>());
			if (Main.rand.Next(10) == 5)
			{
				Item.NewItem(npc.Center, ModContent.ItemType<TheOverwatch>());
			}
			if (Main.rand.Next(10) == 5)
			{
				Item.NewItem(npc.Center, ModContent.ItemType<DemonSemen>());
			}
		}
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DiggerHead);
			// Head is 10 defence, body 20, tail 30.
			npc.aiStyle = -1;
			npc.lifeMax = 60000;
			npc.scale = 1.2f;
			npc.damage = 80;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.lavaImmune = true;
			npc.defense = 50;
			npc.width = 54;
			npc.height = 54;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.boss = true;
		}

		public override void Init()
		{
			base.Init();
			head = true;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0 && Main.player.Count(p => p.active) > 0)
			{
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW1"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW1"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW2"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW3"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW3"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW3"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW4"), 1f);
			}
		}
		public override void CustomBehavior()
		{

		}
	}

	internal class Annih2 : Annih
	{
		public override bool CheckActive()
		{
			return false;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0 && Main.player.Count(p => p.active) > 0)
			{
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW1"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW1"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW2"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW3"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW3"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW3"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW4"), 1f);
			}
		}
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DiggerHead);
			npc.aiStyle = -1;
			npc.lifeMax = 6000;
			npc.damage = 80;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.lavaImmune = true;
			npc.defense = 12;
			npc.scale = 1.2f;
			npc.width = 54;
			npc.height = 54;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;
		}
	}

	internal class Annih3 : Annih
	{
		public override bool CheckActive()
		{
			return false;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0 && Main.player.Count(p => p.active) > 0)
			{
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW1"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW1"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW2"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW3"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW3"), 1f);
				Gore.NewGore(npc.position, new Vector2(Main.rand.Next(10) - Main.rand.Next(10), Main.rand.Next(10) - Main.rand.Next(10)), mod.GetGoreSlot("Gores/EoW3"), 1f);
			}
		}
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DiggerHead);
			npc.aiStyle = -1;
			npc.lifeMax = 6000;
			npc.damage = 80;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.lavaImmune = true;
			npc.scale = 1.2f;
			npc.defense = 12;
			npc.width = 54;
			npc.height = 54;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;
		}

		public override void Init()
		{
			base.Init();
			tail = true;
		}
	}

	// I made this 2nd base class to limit code repetition.
	public abstract class Annih : Worm2
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Annihilator");
		}

		public override void Init()
		{
			minLength = 20;
			maxLength = 20;
			tailType = NPCType<Annih3>();
			bodyType = NPCType<Annih2>();
			headType = NPCType<Annih1>();
			speed = 5.5f;
			turnSpeed = 0.045f;
		}
	}

	//ported from my tAPI mod because I'm lazy
	// This abstract class can be used for non splitting worm type NPC.
	public abstract class Worm2 : ModNPC
	{
		/* ai[0] = follower
		 * ai[1] = following
		 * ai[2] = distanceFromTail
		 * ai[3] = head
		 */
		public bool head;
		public bool tail;
		public int minLength = 20;
		public int maxLength = 20;
		public int headType;
		public int bodyType;
		public int tailType;
		public bool flies = true;
		int phase = 1;
		public bool directional = false;
		public float speed = 5;
		public float turnSpeed = 1;
		public float gap = 1.2f;
		public int phaseChange;
		public int sunphase = 4;
		public int CrystalTimer;
		float BoltSpeed = 10;
		float CrystalSpeed = 4;
		public void AdditionalAi()
		{
			if (Main.player.Count(p => p.active && !p.dead) == 0)
			{
				npc.active = false;
			}
			if (npc.type == headType)
			{

				Player player = Main.player[npc.target];
				Vector2 between = player.Center - npc.Center;

			}
			if (phase == 1)
			{
				phaseChange++;
				if (sunphase == 1)
				{
					if (npc.type == tailType)
					{
						if (phaseChange % 2 == 0)
						{
							Player player = Main.player[npc.target];
							Vector2 between = player.Center - npc.Center;

							Projectile.NewProjectile(npc.Center, between * 2, ProjectileID.DeathLaser, 50, 0, Main.myPlayer);
						}

					}
					directional = false;
					flies = true;
					speed = 20;
					turnSpeed = 0.3f;
				}
				if (sunphase == 2)
				{
					if (phaseChange % 120 == 0 && npc.type == headType)
					{
						for (int i = 0; i < 38; i++)
						{
							Vector2 round = new Vector2(0, CrystalSpeed);
							round = round.RotatedBy(MathHelper.ToRadians(i * 10));
							Projectile.NewProjectile(npc.Center, round, ModContent.ProjectileType<AnnihCrystal>(), 50, 0, Main.myPlayer);
							Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 4);
						}
					}
					directional = false;
					flies = true;
					speed = 20;
					turnSpeed = 0.2f;
				}
				if (sunphase == 3)
				{
					directional = false;
					flies = true;
					speed = 40;
					turnSpeed = 0.2f;
					if (npc.type == tailType)
					{
						if (phaseChange % 10 == 0)
						{
							Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<AnnihScythe>(), 50, 0, Main.myPlayer);
						}
					}
				}
				if (sunphase == 4)
				{
					if (npc.type == tailType)
					{
						if (phaseChange % 4 == 0 && phaseChange > 910 && phaseChange < 1900)
						{
						}

					}
					CrystalTimer = 0;
					directional = false;
					flies = false;
					speed = 30;
					turnSpeed = 0.4f;
					if (phaseChange == 1150)
					{
						Main.PlaySound(29, (int)npc.Center.X, (int)npc.Center.Y, 105);
					}
				}
				if (phaseChange > 200 && sunphase == 1)
				{
					Main.npc[npc.whoAmI].GetGlobalNPC<GlobalNPCe>().FixerAttached = false;
					int Shield = Projectile.NewProjectile(npc.Center, npc.velocity, ModContent.ProjectileType<AnnihDeathray>(), 80, 1, Main.myPlayer);
					Main.projectile[Shield].ai[0] = npc.whoAmI;
					sunphase = 2;
				}
				if (phaseChange > 600 && sunphase == 2)
				{
					if (npc.type == tailType)
					{
						Main.NewText("Tactical nuke, incoming!", Color.Red);
						Player player = Main.player[npc.target];
						Vector2 between = player.Center - npc.Center;
						between = Vector2.Normalize(between);
						Projectile.NewProjectile(npc.Center, between * 5, ModContent.ProjectileType<JapanBanger69>(), 300, 1, Main.myPlayer);
					}


					sunphase = 3;
				}
				if (phaseChange > 900 && sunphase == 3)
				{

					sunphase = 4;
				}
				if (phaseChange > 1200 && sunphase == 4)
				{

					sunphase = 1;
					phaseChange = 0;
				}
			}
			if (phase == 1 && npc.life < npc.lifeMax / 2 && npc.type == headType)
            {
				phaseChange = 0;
				phase = 2;
				speed = 12;
				turnSpeed = 0.1f;
				Main.NewText("External armor damage detected, activating backup systems", Color.Red);
            }
		}
		public override void AI()
		{

			if (npc.localAI[1] == 0f)
			{
				npc.localAI[1] = 1f;
				Init();
			}
			if (npc.ai[3] > 0f)
			{
				npc.realLife = (int)npc.ai[3];
			}
			if (!head && npc.timeLeft < 300)
			{
				npc.timeLeft = 300;
			}
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
			{
				npc.TargetClosest(true);
			}
			if (Main.player[npc.target].dead && npc.timeLeft > 300)
			{
				npc.timeLeft = 300;
			}
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				if (!tail && npc.ai[0] == 0f)
				{
					if (head)
					{
						npc.ai[3] = (float)npc.whoAmI;
						npc.realLife = npc.whoAmI;
						npc.ai[2] = (float)Main.rand.Next(minLength, maxLength + 1);
						npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / gap)), (int)(npc.position.Y + (float)npc.height), bodyType, npc.whoAmI);
					}
					else if (npc.ai[2] > 0f)
					{
						npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / gap)), (int)(npc.position.Y + (float)npc.height), npc.type, npc.whoAmI);
					}
					else
					{
						npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / gap)), (int)(npc.position.Y + (float)npc.height), tailType, npc.whoAmI);
					}
					Main.npc[(int)npc.ai[0]].ai[3] = npc.ai[3];
					Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
					Main.npc[(int)npc.ai[0]].ai[1] = (float)npc.whoAmI;
					Main.npc[(int)npc.ai[0]].ai[2] = npc.ai[2] - 1f;
					npc.netUpdate = true;
				}
				if (!head && (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].type != headType && Main.npc[(int)npc.ai[1]].type != bodyType))
				{
					npc.life = 0;
					npc.HitEffect(0, 10.0);
					npc.active = false;
				}
				if (!tail && (!Main.npc[(int)npc.ai[0]].active || Main.npc[(int)npc.ai[0]].type != bodyType && Main.npc[(int)npc.ai[0]].type != tailType))
				{
					npc.life = 0;
					npc.HitEffect(0, 10.0);
					npc.active = false;
				}
				if (!npc.active && Main.netMode == NetmodeID.Server)
				{
					NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
				}
			}
			int PixelPositionX = (int)(npc.position.X / 16f) - 1;
			int PixelPositionX2 = (int)((npc.position.X + (float)npc.width) / 16f) + 2;
			int PixelPositionY = (int)(npc.position.Y / 16f) - 1;
			int PixelPositionY2 = (int)((npc.position.Y + (float)npc.height) / 16f) + 2;
			if (PixelPositionX < 0)
			{
				PixelPositionX = 0;
			}
			if (PixelPositionX2 > Main.maxTilesX)
			{
				PixelPositionX2 = Main.maxTilesX;
			}
			if (PixelPositionY < 0)
			{
				PixelPositionY = 0;
			}
			if (PixelPositionY2 > Main.maxTilesY)
			{
				PixelPositionY2 = Main.maxTilesY;
			}
			bool FlyingWorm = flies;
			if (!FlyingWorm)
			{
				for (int num184 = PixelPositionX; num184 < PixelPositionX2; num184++)
				{
					for (int num185 = PixelPositionY; num185 < PixelPositionY2; num185++)
					{
						if (Main.tile[num184, num185] != null && (Main.tile[num184, num185].nactive() && (Main.tileSolid[(int)Main.tile[num184, num185].type] || Main.tileSolidTop[(int)Main.tile[num184, num185].type] && Main.tile[num184, num185].frameY == 0) || Main.tile[num184, num185].liquid > 64))
						{
							Vector2 vector17;
							vector17.X = (float)(num184 * 16);
							vector17.Y = (float)(num185 * 16);
							if (npc.position.X + (float)npc.width > vector17.X && npc.position.X < vector17.X + 16f && npc.position.Y + (float)npc.height > vector17.Y && npc.position.Y < vector17.Y + 16f)
							{
								FlyingWorm = true;
								if (Main.rand.NextBool(100) && npc.behindTiles && Main.tile[num184, num185].nactive())
								{
									WorldGen.KillTile(num184, num185, true, true, false);
								}
								if (Main.netMode != NetmodeID.MultiplayerClient && Main.tile[num184, num185].type == 2)
								{
									ushort arg_BFCA_0 = Main.tile[num184, num185 - 1].type;
								}
							}
						}
					}
				}
			}
			if (!FlyingWorm && head)
			{
				Rectangle rectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
				int num186 = 1000;
				bool flag19 = true;
				for (int num187 = 0; num187 < 255; num187++)
				{
					if (Main.player[num187].active)
					{
						Rectangle rectangle2 = new Rectangle((int)Main.player[num187].position.X - num186, (int)Main.player[num187].position.Y - num186, num186 * 2, num186 * 2);
						if (rectangle.Intersects(rectangle2))
						{
							flag19 = false;
							break;
						}
					}
				}
				if (flag19)
				{
					FlyingWorm = true;
				}
			}
			if (directional)
			{
				if (npc.velocity.X < 0f)
				{
					npc.spriteDirection = 1;
				}
				else if (npc.velocity.X > 0f)
				{
					npc.spriteDirection = -1;
				}
			}



			float WormSpeed = speed;
			float WormTurnSpeed = turnSpeed;
			Vector2 WormEdge = new Vector2(npc.position.X + (float)npc.width * 1f, npc.position.Y + (float)npc.height * 1f);
			float PlayerWidth = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
			float PlayerHeight = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
			PlayerWidth = (float)((int)(PlayerWidth / 16f) * 16);
			PlayerHeight = (float)((int)(PlayerHeight / 16f) * 16);
			WormEdge.X = (float)((int)(WormEdge.X / 16f) * 16);
			WormEdge.Y = (float)((int)(WormEdge.Y / 16f) * 16);
			PlayerWidth -= WormEdge.X;
			PlayerHeight -= WormEdge.Y;
			float num193 = (float)System.Math.Sqrt((double)(PlayerWidth * PlayerWidth + PlayerHeight * PlayerHeight));
			if (npc.ai[1] > 0f && npc.ai[1] < (float)Main.npc.Length)
			{
				try
				{
					WormEdge = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					PlayerWidth = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - WormEdge.X;
					PlayerHeight = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - WormEdge.Y;
				}
				catch
				{
				}
				npc.rotation = (float)System.Math.Atan2((double)PlayerHeight, (double)PlayerWidth) + 1.57f;
				num193 = (float)System.Math.Sqrt((double)(PlayerWidth * PlayerWidth + PlayerHeight * PlayerHeight));
				int num194 = npc.width;
				num193 = (num193 - (float)num194) / num193;
				PlayerWidth *= num193;
				PlayerHeight *= num193;
				npc.velocity = Vector2.Zero;
				npc.position.X = npc.position.X + PlayerWidth;
				npc.position.Y = npc.position.Y + PlayerHeight;
				if (directional)
				{
					if (PlayerWidth < 0f)
					{
						npc.spriteDirection = 1;
					}
					if (PlayerWidth > 0f)
					{
						npc.spriteDirection = -1;
					}
				}
			}
			else
			{
				if (!FlyingWorm)
				{
					npc.TargetClosest(true);
					npc.velocity.Y = npc.velocity.Y + 0.11f;
					if (npc.velocity.Y > WormSpeed)
					{
						npc.velocity.Y = WormSpeed;
					}
					if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)WormSpeed * 0.4)
					{
						if (npc.velocity.X < 0f)
						{
							npc.velocity.X = npc.velocity.X - WormTurnSpeed * 1.1f;
						}
						else
						{
							npc.velocity.X = npc.velocity.X + WormTurnSpeed * 1.1f;
						}
					}
					else if (npc.velocity.Y == WormSpeed)
					{
						if (npc.velocity.X < PlayerWidth)
						{
							npc.velocity.X = npc.velocity.X + WormTurnSpeed;
						}
						else if (npc.velocity.X > PlayerWidth)
						{
							npc.velocity.X = npc.velocity.X - WormTurnSpeed;
						}
					}
					else if (npc.velocity.Y > 4f)
					{
						if (npc.velocity.X < 0f)
						{
							npc.velocity.X = npc.velocity.X + WormTurnSpeed * 0.9f;
						}
						else
						{
							npc.velocity.X = npc.velocity.X - WormTurnSpeed * 0.9f;
						}
					}
				}
				else
				{
					if (!flies && npc.behindTiles && npc.soundDelay == 0)
					{
						float num195 = num193 / 40f;
						if (num195 < 10f)
						{
							num195 = 10f;
						}
						if (num195 > 20f)
						{
							num195 = 20f;
						}
						npc.soundDelay = (int)num195;
						Main.PlaySound(SoundID.Roar, npc.position, 1);
					}
					num193 = (float)System.Math.Sqrt((double)(PlayerWidth * PlayerWidth + PlayerHeight * PlayerHeight));
					float num196 = System.Math.Abs(PlayerWidth);
					float num197 = System.Math.Abs(PlayerHeight);
					float num198 = WormSpeed / num193;
					PlayerWidth *= num198;
					PlayerHeight *= num198;
					if (ShouldRun())
					{
						bool flag20 = true;
						for (int num199 = 0; num199 < 255; num199++)
						{
							if (Main.player[num199].active && !Main.player[num199].dead && Main.player[num199].ZoneCorrupt)
							{
								flag20 = false;
							}
						}
						if (flag20)
						{
							if (Main.netMode != NetmodeID.MultiplayerClient && (double)(npc.position.Y / 16f) > (Main.rockLayer + (double)Main.maxTilesY) / 2.0)
							{
								npc.active = false;
								int num200 = (int)npc.ai[0];
								while (num200 > 0 && num200 < 200 && Main.npc[num200].active && Main.npc[num200].aiStyle == npc.aiStyle)
								{
									int num201 = (int)Main.npc[num200].ai[0];
									Main.npc[num200].active = false;
									npc.life = 0;
									if (Main.netMode == NetmodeID.Server)
									{
										NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, num200, 0f, 0f, 0f, 0, 0, 0);
									}
									num200 = num201;
								}
								if (Main.netMode == NetmodeID.Server)
								{
									NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc.whoAmI, 0f, 0f, 0f, 0, 0, 0);
								}
							}
							PlayerWidth = 0f;
							PlayerHeight = WormSpeed;
						}
					}
					bool flag21 = false;
					if (npc.type == NPCID.WyvernHead)
					{
						if ((npc.velocity.X > 0f && PlayerWidth < 0f || npc.velocity.X < 0f && PlayerWidth > 0f || npc.velocity.Y > 0f && PlayerHeight < 0f || npc.velocity.Y < 0f && PlayerHeight > 0f) && System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y) > WormTurnSpeed / 2f && num193 < 300f)
						{
							flag21 = true;
							if (System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y) < WormSpeed)
							{
								npc.velocity *= 1.1f;
							}
						}
						if (npc.position.Y > Main.player[npc.target].position.Y || (double)(Main.player[npc.target].position.Y / 16f) > Main.worldSurface || Main.player[npc.target].dead)
						{
							flag21 = true;
							if (System.Math.Abs(npc.velocity.X) < WormSpeed / 2f)
							{
								if (npc.velocity.X == 0f)
								{
									npc.velocity.X = npc.velocity.X - (float)npc.direction;
								}
								npc.velocity.X = npc.velocity.X * 1.1f;
							}
							else
							{
								if (npc.velocity.Y > -WormSpeed)
								{
									npc.velocity.Y = npc.velocity.Y - WormTurnSpeed;
								}
							}
						}
					}
					if (!flag21)
					{
						if (npc.velocity.X > 0f && PlayerWidth > 0f || npc.velocity.X < 0f && PlayerWidth < 0f || npc.velocity.Y > 0f && PlayerHeight > 0f || npc.velocity.Y < 0f && PlayerHeight < 0f)
						{
							if (npc.velocity.X < PlayerWidth)
							{
								npc.velocity.X = npc.velocity.X + WormTurnSpeed;
							}
							else
							{
								if (npc.velocity.X > PlayerWidth)
								{
									npc.velocity.X = npc.velocity.X - WormTurnSpeed;
								}
							}
							if (npc.velocity.Y < PlayerHeight)
							{
								npc.velocity.Y = npc.velocity.Y + WormTurnSpeed;
							}
							else
							{
								if (npc.velocity.Y > PlayerHeight)
								{
									npc.velocity.Y = npc.velocity.Y - WormTurnSpeed;
								}
							}
							if ((double)System.Math.Abs(PlayerHeight) < (double)WormSpeed * 0.2 && (npc.velocity.X > 0f && PlayerWidth < 0f || npc.velocity.X < 0f && PlayerWidth > 0f))
							{
								if (npc.velocity.Y > 0f)
								{
									npc.velocity.Y = npc.velocity.Y + WormTurnSpeed * 2f;
								}
								else
								{
									npc.velocity.Y = npc.velocity.Y - WormTurnSpeed * 2f;
								}
							}
							if ((double)System.Math.Abs(PlayerWidth) < (double)WormSpeed * 0.2 && (npc.velocity.Y > 0f && PlayerHeight < 0f || npc.velocity.Y < 0f && PlayerHeight > 0f))
							{
								if (npc.velocity.X > 0f)
								{
									npc.velocity.X = npc.velocity.X + WormTurnSpeed * 2f;
								}
								else
								{
									npc.velocity.X = npc.velocity.X - WormTurnSpeed * 2f;
								}
							}
						}
						else
						{
							if (num196 > num197)
							{
								if (npc.velocity.X < PlayerWidth)
								{
									npc.velocity.X = npc.velocity.X + WormTurnSpeed * 1.1f;
								}
								else if (npc.velocity.X > PlayerWidth)
								{
									npc.velocity.X = npc.velocity.X - WormTurnSpeed * 1.1f;
								}
								if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)WormSpeed * 0.5)
								{
									if (npc.velocity.Y > 0f)
									{
										npc.velocity.Y = npc.velocity.Y + WormTurnSpeed;
									}
									else
									{
										npc.velocity.Y = npc.velocity.Y - WormTurnSpeed;
									}
								}
							}
							else
							{
								if (npc.velocity.Y < PlayerHeight)
								{
									npc.velocity.Y = npc.velocity.Y + WormTurnSpeed * 1.1f;
								}
								else if (npc.velocity.Y > PlayerHeight)
								{
									npc.velocity.Y = npc.velocity.Y - WormTurnSpeed * 1.1f;
								}
								if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)WormSpeed * 0.5)
								{
									if (npc.velocity.X > 0f)
									{
										npc.velocity.X = npc.velocity.X + WormTurnSpeed;
									}
									else
									{
										npc.velocity.X = npc.velocity.X - WormTurnSpeed;
									}
								}
							}
						}
					}
				}
				npc.rotation = (float)System.Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;
				if (head)
				{
					if (FlyingWorm)
					{
						if (npc.localAI[0] != 1f)
						{
							npc.netUpdate = true;
						}
						npc.localAI[0] = 1f;
					}
					else
					{
						if (npc.localAI[0] != 0f)
						{
							npc.netUpdate = true;
						}
						npc.localAI[0] = 0f;
					}
					if ((npc.velocity.X > 0f && npc.oldVelocity.X < 0f || npc.velocity.X < 0f && npc.oldVelocity.X > 0f || npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f || npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f) && !npc.justHit)
					{
						npc.netUpdate = true;
						return;
					}
				}
			}
			AdditionalAi();
			CustomBehavior();


		}

		public virtual void Init()
		{
		}

		public virtual bool ShouldRun()
		{
			return false;
		}

		public virtual void CustomBehavior()
		{
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return head ? (bool?)null : false;
		}

	}
	[AutoloadBossHead]
	public class ShieldGenerator : ModNPC
    {
		int phasechange;
		int phase = 1;
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Shield Generator");
        }
        public override void SetDefaults()
        {
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.aiStyle = -1;
			npc.defense = 20;
			npc.lifeMax = 4000;
			npc.scale = 1.2f;
			npc.damage = 40;
			npc.lavaImmune = true;
        }
        public override void AI()
        {
			npc.TargetClosest();
			Player player = Main.player[npc.target];
			phasechange++;
			if(phasechange > 300)
            {
				switch(phase)
                {
					case 1: phase = 2; break;
					case 2: phase = 3; break;
					case 3: phase = 4; break;
					case 4: phase = 0; break;
                }
				phasechange = 0;
            }
        }
    }
}