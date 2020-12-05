using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Steamworks;
using Glorymod.Dusts;
using Glorymod.Projectiles;
namespace Glorymod.NPCs
{
    public class Hand : ModNPC
    {
        public override bool CheckDead()
        {
            Gore.NewGoreDirect(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HandGore"), 1f);
            return true;
        }
        int Degrees;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiend Viscount's Hand");
        }
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.width = 60;
            npc.height = 60;
            npc.damage = 40;
            npc.defense = 12;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lifeMax = 1500;
            npc.timeLeft = 60000;
            npc.knockBackResist = 0;
            npc.HitSound = SoundID.NPCHit21;
        }
        NPC npce;
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            return false;
        }
        public override void AI()
        {
            if (Main.player.Count(p => p.active && !p.dead) == 0 || !NPC.AnyNPCs(NPCID.SkeletronHead))
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
            if(!Main.npc[(int)npc.ai[0]].GetGlobalNPC<GlobalNPCe>().Phase2)
            {
                float speed = 20f;
                float inertia = 60f;
                Vector2 direction = new Vector2(npce.Center.X - npc.Center.X + 200, npce.Center.Y - npc.Center.Y + 100);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                #region Attacks
                int i2 = (int)Main.npc[(int)npc.ai[0]].GetGlobalNPC<GlobalNPCe>().PhaseChange;
                if (i2 == 80 || i2 == 180 || i2 == 280 || i2 == 380 || i2 == 480)
                {
                    npc.TargetClosest();
                    Player player = Main.player[npc.target];
                    switch (Main.npc[(int)npc.ai[0]].GetGlobalNPC<GlobalNPCe>().o)
                    {
                        case 1:
                            for (int i = 0; i < 90; i++)
                            {
                                Vector2 s = npc.Center + new Vector2(0, 10).RotatedBy(MathHelper.ToDegrees(i * 4));
                                Dust.NewDust(s, 0, 0, ModContent.DustType<ViscountCyan>());
                            }
                            break;
                        case 2:
                            for (int i = 0; i < 90; i++)
                            {
                                Vector2 s = npc.Center + new Vector2(0, 10).RotatedBy(MathHelper.ToDegrees(i * 4));
                                Dust.NewDust(s, 0, 0, ModContent.DustType<ViscountRed>());
                            }
                            break;
                        case 3:
                            for (int i = 0; i < 90; i++)
                            {
                                Vector2 s = npc.Center + new Vector2(0, 10).RotatedBy(MathHelper.ToDegrees(i * 4));
                                Dust.NewDust(s, 0, 0, ModContent.DustType<ViscountPurple>());
                            }
                            break;
                    }


                }
                if (i2 == 140 || i2 == 240 || i2 == 340 || i2 == 440 || i2 == 540)
                {
                    npc.TargetClosest();
                    Player player = Main.player[npc.target];
                    switch (Main.npc[(int)npc.ai[0]].GetGlobalNPC<GlobalNPCe>().o)
                    {
                        case 1:
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
                            
                            break;
                        case 2:
                            Projectile.NewProjectile(npc.Center, Vector2.Normalize(player.Center - npc.Center) * 3, ModContent.ProjectileType<SFireball>(), 20, 1);
                            Projectile.NewProjectile(npc.Center, Vector2.Normalize(player.Center - npc.Center) * 5, ModContent.ProjectileType<SFireball>(), 20, 1);
                            Projectile.NewProjectile(npc.Center, Vector2.Normalize(player.Center - npc.Center) * 7, ModContent.ProjectileType<SFireball>(), 20, 1);
                            Projectile.NewProjectile(npc.Center, Vector2.Normalize(player.Center - npc.Center) * 10, ModContent.ProjectileType<SFireball>(), 20, 1);
                            Projectile.NewProjectile(npc.Center, Vector2.Normalize(player.Center - npc.Center) * 15, ModContent.ProjectileType<SFireball>(), 20, 1);
                            break;
                        case 3:
                            npc.velocity = Vector2.Normalize(player.Center - npc.Center) * 40;
                            Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 19);
                            break;
                    }


                }
                #endregion
            }
            else
            {
                Degrees += 2;
                if(Degrees > 360)
                {
                    Degrees = 0;
                }
                Vector2 vector = new Vector2(-500, 0).RotatedBy(MathHelper.ToRadians(Degrees));
                npc.position = npce.Center + vector;
            }
        }
    }

    public class Hand2 : ModNPC
    {
        public override bool CheckDead()
        {
            Gore.NewGoreDirect(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HandGore"), 1f);
            return true;
        }
        int Degrees;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiend Viscount's Hand");
        }
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.width = 60;
            npc.height = 60;
            npc.damage = 40;
            npc.defense = 12;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lifeMax = 1500;
            npc.timeLeft = 60000;
            npc.knockBackResist = 0;
            npc.HitSound = SoundID.NPCHit21;
        }
        NPC npce;
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            return false;
        }
        public override void AI()
        {
            if (Main.player.Count(p => p.active && !p.dead) == 0 || !NPC.AnyNPCs(NPCID.SkeletronHead))
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
            if (!Main.npc[(int)npc.ai[0]].GetGlobalNPC<GlobalNPCe>().Phase2)
            {
                float speed = 20f;
                float inertia = 60f;
                Vector2 direction = new Vector2(npce.Center.X - npc.Center.X - 200, npce.Center.Y - npc.Center.Y + 100);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                
                #region Attacks
                int i2 = (int)Main.npc[(int)npc.ai[0]].GetGlobalNPC<GlobalNPCe>().PhaseChange;
                if (i2 == 80 || i2 == 180 || i2 == 280 || i2 == 380 || i2 == 480)
                {
                    npc.TargetClosest();
                    Player player = Main.player[npc.target];
                    switch(Main.npc[(int)npc.ai[0]].GetGlobalNPC<GlobalNPCe>().o)
                    {
                        case 1:
                            for (int i = 0; i < 90; i++)
                            {
                                Vector2 s = npc.Center + new Vector2(0, 10).RotatedBy(MathHelper.ToDegrees(i * 4));
                                Dust.NewDust(s, 0, 0, ModContent.DustType<ViscountCyan>());
                            } break;
                        case 2:
                            for (int i = 0; i < 90; i++)
                            {
                                Vector2 s = npc.Center + new Vector2(0, 10).RotatedBy(MathHelper.ToDegrees(i * 4));
                                Dust.NewDust(s, 0, 0, ModContent.DustType<ViscountRed>());
                            }
                            break;
                        case 3:
                            for (int i = 0; i < 90; i++)
                            {
                                Vector2 s = npc.Center + new Vector2(0, 10).RotatedBy(MathHelper.ToDegrees(i * 4));
                                Dust.NewDust(s, 0, 0, ModContent.DustType<ViscountPurple>());
                            }
                            break;
                    }
                    

                }
                if (i2 == 140 || i2 == 240 || i2 == 340 || i2 == 440 || i2 == 540)
                {
                    npc.TargetClosest();
                    Player player = Main.player[npc.target];
                    switch (Main.npc[(int)npc.ai[0]].GetGlobalNPC<GlobalNPCe>().o)
                    {
                        case 1:
                            if(!NPC.AnyNPCs(ModContent.NPCType<Hand>()))
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
                            }
                            break;
                        case 2:
                            Projectile.NewProjectile(npc.Center, Vector2.Normalize(player.Center - npc.Center) * 3, ModContent.ProjectileType<SFireball>(), 20, 1);
                            Projectile.NewProjectile(npc.Center, Vector2.Normalize(player.Center - npc.Center) * 5, ModContent.ProjectileType<SFireball>(), 20, 1);
                            Projectile.NewProjectile(npc.Center, Vector2.Normalize(player.Center - npc.Center) * 7, ModContent.ProjectileType<SFireball>(), 20, 1);
                            Projectile.NewProjectile(npc.Center, Vector2.Normalize(player.Center - npc.Center) * 10, ModContent.ProjectileType<SFireball>(), 20, 1);
                            Projectile.NewProjectile(npc.Center, Vector2.Normalize(player.Center - npc.Center) * 15, ModContent.ProjectileType<SFireball>(), 20, 1);
                            break;
                        case 3:
                            npc.velocity = Vector2.Normalize(player.Center - npc.Center) * 40;
                            Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 19);

                            break;
                    }
                    

                }
                #endregion
            }
            else
            {
                Degrees += 2;
                if (Degrees > 360)
                {
                    Degrees = 0;
                }
                Vector2 vector = new Vector2(500, 0).RotatedBy(MathHelper.ToRadians(Degrees));
                npc.position = (npce.Center + vector);
            }
        }
    }
}
