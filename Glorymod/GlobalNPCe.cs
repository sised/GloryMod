using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Glorymod.NPCs;
using Glorymod.Projectiles;
using System;
using Glorymod.Buffs;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using IL.Terraria.DataStructures;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader.IO;
using Glorymod;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.UI;
using Glorymod.Items.Accessories.Hm;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Threading;
using Ionic.Zip;

namespace Glorymod
{
    
    public class GlobalNPCe : GlobalNPC
    {
        public static bool deadp;
        public override bool InstancePerEntity => true;
        public float BlazingRadious = 1500;
        bool Enter = true;
        public float PhaseChange;
        Vector2 Prediction;
        public bool LaserAttached = false;
        public bool FixerAttached = false;
        public float targetX = 0;
        public int PhaseChange2;
        public float targetY = 0;
        public int HP;
        public bool Phase2 = false;

        bool Exist = false;
        int Ypos = -300;
        public override void NPCLoot(NPC npc)
        {
            if(npc.type == NPCID.WallofFlesh)
            {
                Item.NewItem(npc.Center, ModContent.ItemType<TrophyOfMenace>());
            }
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {

        }
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                Exist = false;
                NPC npc;
                if (!Exist)
                {
                    npc = Main.npc[i];
                }
                else break;
                if (npc.boss && npc.active)
                {
                    if (!Exist)
                    {
                        Exist = true;
                        Main.npc[i].GetGlobalNPC<GlobalNPCe>().LaserAttached = true;
                    }

                    break;
                }
                


            }
            if (Exist)
            {
                pool.Clear();
            }
        }
        public override void SetDefaults(NPC npc)
        {
            if(Mworld.Menace)
            {
                if(npc.type == NPCID.WallofFlesh)
                {
                    npc.HitSound = SoundID.NPCHit2;
                    npc.GivenName = "Basalt Barricade";
                    npc.lifeMax = 15000;
                    npc.defense = 15;
                }

                if(npc.type == NPCID.SkeletronHead)
                {
                    npc.GivenName = "Fiend Viscount";
                    npc.aiStyle = -1;
                }
            }
            
        }
        
        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            if(npc.active)
            {
                if (npc.type == 4)
                {
                    damage = 60;
                }
                if (npc.type == 34 || npc.type == 36)
                {
                    target.AddBuff(BuffID.OnFire, 200);
                }
            }
            
        }
        public override void AI(NPC npc)
        {

            
            if (npc.active)
            {
                


                #region Special Effects
                // Voltaic canister debuff giver
                for (int i = 0; i < Main.maxPlayers; i++)
                {
                    float a = (npc.position - Main.player[npc.target].position).Length();
                    Player p = Main.player[i];
                    if (p.active && p.GetModPlayer<MPlayer>().isWearingVoltaicCanister && a < 600 && npc.CanBeChasedBy())
                    {
                        npc.AddBuff(ModContent.BuffType<Voltaic>(), 2, false);
                        break;
                    }
                }
                #endregion
                #region Main Changes menace mode
                if (Mworld.Menace)
                {
                    //neon tyrant spawn
                    if (npc.type == NPCID.KingSlime)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<NeonTyrant>());
                        npc.active = false;
                    }
                    //altintellect spawn
                    if (npc.type == NPCID.BrainofCthulhu)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Brain>());
                        npc.active = false;
                    }
                    //altintellect spawn
                    if (npc.type == NPCID.EyeofCthulhu)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Sightseer>());
                        npc.active = false;
                    }
                    //pellucid wolfer spawn
                    if (npc.type == NPCID.EaterofWorldsHead)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<EoW1>());
                        npc.active = false;
                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            if (Main.npc[i].type == NPCID.EaterofWorldsBody || Main.npc[i].type == NPCID.EaterofWorldsTail)
                            {
                                Main.npc[i].active = false;
                            }
                        }
                    }
                    //creepers despawn when altintellect spawns
                    if (npc.type == NPCID.Creeper)
                    {
                        npc.active = false;
                    }
                    //boss despawns if all players are dead
                    if (npc.boss)
                    {
                        if (Main.player.Count(p => p.active && !p.dead) == 0)
                        {
                            npc.active = false;
                        }
                    }
                }
                #endregion
                #region Basalt Barricade
                // Mouth
                
                if (Mworld.Menace && npc.type == NPCID.WallofFlesh)
                {
                    npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -5f, +5f);
                    if (npc.life < npc.lifeMax / 2 && !NPC.AnyNPCs(ModContent.NPCType<TrophyOfMenaceBB>()))
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<TrophyOfMenaceBB>());
                    }
                    PhaseChange++;
                    if (PhaseChange > 250 && Enter)
                    {
                        Enter = false;
                        PhaseChange = 0;
                        npc.defense = 15;
                    }
                    if (Enter)
                    {
                        npc.defense = 75;
                        BlazingRadious -= 5;
                    }

                    if(!Enter)
                    {
                        if(PhaseChange < 300)
                        {
                            BlazingRadious = 250;
                        }
                        if(PhaseChange > 300 && PhaseChange < 351)
                        {
                            BlazingRadious += 15;
                        }
                        if(PhaseChange == 351)
                        {
                            Projectile.NewProjectile(npc.Center, npc.velocity, ModContent.ProjectileType<MoltenDeathray>(), 40, 1);
                            
                        }
                        if(PhaseChange == 471)
                        {
                            for (int i = 0; i < 30; i++)
                            {
                                if (npc.velocity.X > 0)
                                {
                                    Projectile.NewProjectile(npc.Center.X + i * 75, npc.Center.Y, 0f, 4f, ModContent.ProjectileType<WoFshard>(), 20, 1);
                                    Projectile.NewProjectile(npc.Center.X + i * 75, npc.Center.Y, 0f, -4f, ModContent.ProjectileType<WoFshard>(), 20, 1);
                                }
                                if (npc.velocity.X < 0)
                                {
                                    Projectile.NewProjectile(npc.Center.X - i * 75, npc.Center.Y, 0f, 4f, ModContent.ProjectileType<WoFshard>(), 20, 1);
                                    Projectile.NewProjectile(npc.Center.X - i * 75, npc.Center.Y, 0f, -4f, ModContent.ProjectileType<WoFshard>(), 20, 1);
                                }
                            }
                        }
                        if(PhaseChange > 350 && PhaseChange < 700)
                        {
                            if(npc.velocity.X > 0)
                            {
                                npc.rotation = npc.velocity.ToRotation();
                            }
                            else
                            {
                                npc.rotation = npc.velocity.RotatedBy(MathHelper.PiOver2 * 2).ToRotation();
                            }
                        }
                        if(PhaseChange > 700 && PhaseChange < 751)
                        {
                            BlazingRadious += 10;
                        }
                        if(PhaseChange == 751)
                        {
                            Main.PlaySound(29, (int)npc.Center.X, (int)npc.Center.Y, 105);
                        }
                        if(PhaseChange == 800)
                        {
                            Main.PlaySound(15, (int)npc.Center.X, (int)npc.Center.Y, 0);
                            if (npc.velocity.X > 0)
                            {
                                npc.velocity.X = 33;
                            }
                            if (npc.velocity.X < 0)
                            {
                                npc.velocity.X = -33;
                            }
                        }
                        if(PhaseChange > 800 && PhaseChange < 900)
                        {
                            if(npc.velocity.X > 0)
                            {
                                npc.velocity.X = 33 - ((PhaseChange - 800) * 0.33f);
                            }
                            if (npc.velocity.X < 0)
                            {
                                npc.velocity.X = -33 + ((PhaseChange - 800) * 0.33f);
                            }
                        }
                        if(PhaseChange > 900 && PhaseChange < 951)
                        {
                            BlazingRadious -= 10;
                        }
                        if(PhaseChange == 951 || PhaseChange == 1000 || PhaseChange == 1050 || PhaseChange == 1100 || PhaseChange == 1150)
                        {
                            
                            if(npc.velocity.X > 0)
                            {
                                Main.NewText("a");
                                if(Main.player[npc.target].velocity.X > 0)
                                {
                                    Prediction = (Main.player[npc.target].Center - npc.Center).RotatedBy(MathHelper.ToRadians(-Main.player[npc.target].velocity.X + Main.player[npc.target].velocity.Y));
                                }
                                if (Main.player[npc.target].velocity.X < 0)
                                {
                                    Prediction = (Main.player[npc.target].Center - npc.Center).RotatedBy(MathHelper.ToRadians(-Main.player[npc.target].velocity.X * 3 + Main.player[npc.target].velocity.Y));
                                }
                            }
                            if (npc.velocity.X < 0)
                            {
                                if (Main.player[npc.target].velocity.X > 0)
                                {
                                    Prediction = (Main.player[npc.target].Center - npc.Center).RotatedBy(MathHelper.ToRadians(-Main.player[npc.target].velocity.X * 3));
                                }
                                if (Main.player[npc.target].velocity.X < 0)
                                {
                                    Prediction = (Main.player[npc.target].Center - npc.Center).RotatedBy(MathHelper.ToRadians(-Main.player[npc.target].velocity.X * 3));
                                }
                            }
                            Projectile.NewProjectile(npc.Center, Prediction, ModContent.ProjectileType<LavaBlob>(), 20, 0);
                        }
                        if(PhaseChange > 1199)
                        {
                            if(PhaseChange % 10 == 0 && npc.life < npc.lifeMax / 4 && npc.velocity.X > 0)
                            {
                                Main.PlaySound(SoundID.Item33, (int)npc.Center.X, (int)npc.Center.Y);
                                Vector2 a = new Vector2(0, 5).RotatedBy(MathHelper.ToRadians(PhaseChange - 1200 * 2)) * 3;
                                Projectile.NewProjectile(npc.Center, a, ModContent.ProjectileType<BasaltLaser>(), 20, 1);
                            }
                            if (PhaseChange % 10 == 0 && npc.life < npc.lifeMax / 4 && npc.velocity.X < 0)
                            {
                                Main.PlaySound(SoundID.Item33, (int)npc.Center.X, (int)npc.Center.Y);
                                Vector2 a = new Vector2(0, 5).RotatedBy(MathHelper.ToRadians(PhaseChange - 1200 * 2 + 180)) * 3;
                                Projectile.NewProjectile(npc.Center, a, ModContent.ProjectileType<BasaltLaser>(), 20, 1);
                            }
                            BlazingRadious -= 7.5f;
                        }
                        if(PhaseChange == 1300)
                        {
                            PhaseChange = 0;
                        }
                    }
                    for (int i = 0; i < 360; i++)
                    {

                        Dust dust;
                        
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = npc.Center + new Vector2(BlazingRadious, 0).RotatedBy(MathHelper.ToDegrees(i));
                        int r = Main.rand.Next(3);
                        if(r == 2)
                        {
                            dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 6, 0 ,0, 0, new Color(255, 255, 255), 1f)];
                            dust.noGravity = true;
                        }
                        

                    }
                }
                // Wall of Flesh stuff despawns
                BasaltBarricadeUnneededNPCDespawn(npc);
                // Hungry Despawn
                if(Mworld.Menace && npc.type == NPCID.TheHungry) { npc.active = false; }


                if (npc.type == ModContent.NPCType<EoW>())
                {
                }
                #endregion
                #region Fiend Viscount
                if (Mworld.Menace && npc.type == NPCID.SkeletronHead)
                {
                    if (Main.player.Count(p => p.active && !p.dead) == 0)
                    {
                        npc.active = false;
                    }
                    npc.TargetClosest();
                    Player player = Main.player[npc.target];
                    if(!Phase2)
                    {
                        PhaseChange2++;
                        if(PhaseChange2 < 120)
                        {
                            if(PhaseChange2 % 30 == 0)
                            {
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, 5,
                                    ModContent.ProjectileType<FiendBolt>(), 20, 1);
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, -5,
                                    ModContent.ProjectileType<FiendBolt>(), 20, 1);

                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, 5,
                                    ModContent.ProjectileType<FiendBolt>(), 20, 1);
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, -5,
                                    ModContent.ProjectileType<FiendBolt>(), 20, 1);
                            }
                        }
                        if(PhaseChange2 > 120 && PhaseChange2 < 240)
                        {
                        }
                        if(PhaseChange2 > 240)
                        {
                            if(PhaseChange2 % 20 == 0)
                            {
                                Vector2 a = Vector2.Normalize(player.Center - npc.Center);
                                a *= 3f;
                                Projectile.NewProjectile(npc.Center, a, ModContent.ProjectileType<DemonClaw>(), 20, 1);
                            }
                        }
                        if(PhaseChange2 > 360)
                        {
                            PhaseChange2 = 0;
                        }
                        if(Enter)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Joint>());
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Hand>(), 0, npc.whoAmI);
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Joint2>());
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Hand2>(), 0, npc.whoAmI);
                            Enter = false;
                        }
                        npc.rotation = MathHelper.Clamp(npc.velocity.X, MathHelper.ToRadians(-30), MathHelper.ToRadians(30));
                        PhaseChange++;
                        if(PhaseChange < 120)
                        {
                            npc.TargetClosest();
                            Vector2 pos = new Vector2(player.Center.X - 200, player.Center.Y - 300);
                            npc.position.X = MathHelper.SmoothStep(npc.position.X, pos.X, .15f);
                            npc.position.Y = MathHelper.SmoothStep(npc.position.Y, pos.Y, .15f);
                        }
                        if(PhaseChange > 120)
                        {
                            npc.TargetClosest();
                            Vector2 pos = new Vector2(player.Center.X + 200, player.Center.Y - 300);
                            npc.position.X = MathHelper.SmoothStep(npc.position.X, pos.X, .15f);
                            npc.position.Y = MathHelper.SmoothStep(npc.position.Y, pos.Y, .15f);
                        }
                        if(PhaseChange > 240)
                        {
                            int A = Projectile.NewProjectile(player.Center, npc.velocity, ModContent.ProjectileType<ViscountDeathray>(), 20, 1);
                            Main.projectile[A].ai[1] = 0;
                            int B = Projectile.NewProjectile(player.Center, npc.velocity, ModContent.ProjectileType<ViscountDeathray>(), 20, 1);
                            Main.projectile[B].ai[1] = 1000;
                            int C = Projectile.NewProjectile(player.Center, npc.velocity, ModContent.ProjectileType<ViscountDeathray>(), 20, 1);
                            Main.projectile[B].ai[1] = 2000;
                            int D = Projectile.NewProjectile(player.Center, npc.velocity, ModContent.ProjectileType<ViscountDeathray>(), 20, 1);
                            Main.projectile[D].ai[1] = 3000;
                            int E = Projectile.NewProjectile(player.Center, npc.velocity, ModContent.ProjectileType<ViscountDeathray>(), 20, 1);
                            Main.projectile[E].ai[1] = -1000;
                            PhaseChange = 0;
                        }
                        if(!NPC.AnyNPCs(ModContent.NPCType<Hand>()) && !NPC.AnyNPCs(ModContent.NPCType<Hand2>()))
                        {
                            Phase2 = true;
                            Enter = true;
                        }
                    }
                    else
                    {
                        if (Enter)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Joint>());
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Hand>(), 0, npc.whoAmI);
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Joint2>());
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Hand2>(), 0, npc.whoAmI);
                            Enter = false;
                        }
                        PhaseChange++;
                        if(PhaseChange > 240)
                        {
                            PhaseChange = 0;
                        }
                        npc.TargetClosest();
                        Vector2 pos = new Vector2(player.Center.X, player.Center.Y);
                        npc.position.X = MathHelper.SmoothStep(npc.position.X, pos.X, .05f);
                        npc.position.Y = MathHelper.SmoothStep(npc.position.Y, pos.Y, .05f);
                        if(PhaseChange == 0)
                        {
                            //sound
                        }
                        if(PhaseChange == 120)
                        {
                            
                        }
                        if(PhaseChange > 260 && PhaseChange < 400)
                        {
                            //spiral
                        }
                        if(PhaseChange > 600)
                        {
                            PhaseChange = 0;
                        }
                    }
                }
                #endregion
            }
        }
        public void BasaltBarricadeUnneededNPCDespawn(NPC npc)
        {
            if (Mworld.Menace && (npc.type == NPCID.WallofFleshEye || npc.type == NPCID.TheHungry || npc.type == NPCID.LeechBody || npc.type == NPCID.LeechTail || npc.type == NPCID.LeechHead)) { npc.active = false; }
        }
        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
            if(npc.active)
            {
                if (npc.type == 114 && npc.life <= 0)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<WoFeye1>());
                }
            }
            
        }
        
        public override bool CheckDead(NPC npc)
        {
            
            return true;
        }
        

    }



    public class BasaltLaser : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 14;
            projectile.height = 14;
            projectile.tileCollide = false;
            projectile.timeLeft = 700;

        }
        public override void AI()
        {
            Vector2 position = projectile.oldPosition;
            projectile.rotation = projectile.velocity.ToRotation();
        }
    }


    public class Joint : ModNPC
    {
        bool Exist;
        public override void SetDefaults()
        {
            npc.damage = 0;
            npc.lifeMax = 100;
            npc.dontTakeDamage = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lavaImmune = true;
        }
        NPC npce;
        NPC npce2;
        public override void AI()
        {
            if (Main.player.Count(p => p.active && !p.dead) == 0 || !NPC.AnyNPCs(NPCID.SkeletronHead) || !NPC.AnyNPCs(ModContent.NPCType<Hand>()))
            {
                npc.active = false;
            }
            Exist = false;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                npce = Main.npc[i];
                if (npce.type == NPCID.SkeletronHead && npce.active)
                {
                    Exist = true;
                    break;
                }

            }
            
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                npce2 = Main.npc[i];
                if (npce2.type == ModContent.NPCType<Hand>() && npce.active)
                {
                    break;
                }

            }
            /*float speed = 20f;
            float inertia = 60f;
            Vector2 direction = new Vector2(npce.Center.X - npc.Center.X + 200, npce.Center.Y - npc.Center.Y);
            direction.Normalize();
            direction *= speed;
            npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;*/
            float t = 0.6f;
            npc.position.X = MathHelper.SmoothStep(npce.position.X, npce2.position.X, t);
            npc.position.Y = MathHelper.SmoothStep(npce.position.Y, npce2.position.Y, t);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (npc.active)
            {
                DrawArm(spriteBatch, Main.npcTexture[npc.type]);
            } return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            DrawHand(spriteBatch, Main.npcTexture[npc.type]);
        }
        public void DrawArm(SpriteBatch spriteBatch, Texture2D texture)
        {
            if (npc.active)
            {
                //Draws the bone from the joint to the head
                spriteBatch.Draw(texture, npc.Center - Main.screenPosition,
                    new Rectangle(0, 0, 38, 136), Color.White, (npce.Center - npc.Center).ToRotation() - MathHelper.ToRadians(90), new Vector2(28 * .5f, 26 * .5f), 1, 0, 0.1f);
                //Draws the bone from the joint to the hand
                spriteBatch.Draw(texture, npc.Center - Main.screenPosition,
                    new Rectangle(0, 0, 38, 136), Color.White, (npce2.Center - npc.Center).ToRotation() - MathHelper.ToRadians(90), new Vector2(28 * .5f, 26 * .5f), 1, 0, 0.1f);
            }
        }
        public void DrawHand(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, npce2.Center - Main.screenPosition,
                    new Rectangle(0, 138, 60, 72), Color.White, (npce.position - npce2.position).ToRotation() + MathHelper.ToRadians(90), new Vector2(28 * .5f, 26 * .5f), 1, 0, 1f);
        }
    }

    public class Joint2 : ModNPC
    {
        public override void SetDefaults()
        {
            npc.damage = 0;
            npc.lifeMax = 100;
            npc.dontTakeDamage = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lavaImmune = true;
        }
        NPC npce;
        NPC npce2;
        public override void AI()
        {
            if (Main.player.Count(p => p.active && !p.dead) == 0 || !NPC.AnyNPCs(NPCID.SkeletronHead) || !NPC.AnyNPCs(ModContent.NPCType<Hand2>()))
            {
                npc.active = false;
            }
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                npce = Main.npc[i];
                if (npce.type == NPCID.SkeletronHead && npce.active)
                {
                    break;
                }

            }

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                npce2 = Main.npc[i];
                if (npce2.type == ModContent.NPCType<Hand2>() && npce.active)
                {
                    break;
                }

            }
            /*float speed = 20f;
            float inertia = 60f;
            Vector2 direction = new Vector2(npce.Center.X - npc.Center.X + 200, npce.Center.Y - npc.Center.Y);
            direction.Normalize();
            direction *= speed;
            npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;*/
            float t = 0.6f;
            npc.position.X = MathHelper.SmoothStep(npce.position.X, npce2.position.X, t);
            npc.position.Y = MathHelper.SmoothStep(npce.position.Y, npce2.position.Y, t);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (npc.active)
            {
                DrawArm(spriteBatch, Main.npcTexture[npc.type]);
            }
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            DrawHand(spriteBatch, Main.npcTexture[npc.type]);
        }
        public void DrawArm(SpriteBatch spriteBatch, Texture2D texture)
        {
            if (npc.active)
            {
                //Draws the bone from the joint to the head
                spriteBatch.Draw(texture, npc.Center - Main.screenPosition,
                    new Rectangle(0, 0, 38, 136), Color.White, (npce.Center - npc.Center).ToRotation() - MathHelper.ToRadians(90), new Vector2(28 * .5f, 26 * .5f), 1, 0, 0.1f);
                //Draws the bone from the joint to the hand
                spriteBatch.Draw(texture, npc.Center - Main.screenPosition,
                    new Rectangle(0, 0, 38, 136), Color.White, (npce2.Center - npc.Center).ToRotation() - MathHelper.ToRadians(90), new Vector2(28 * .5f, 26 * .5f), 1, 0, 0.1f);
            }
        }
        public void DrawHand(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, npce2.Center - Main.screenPosition,
                    new Rectangle(0, 138, 60, 72), Color.White, (npce.position - npce2.position).ToRotation() + MathHelper.ToRadians(90), new Vector2(28 * .5f, 26 * .5f), 1, 0, 1f);
        }
    }

}