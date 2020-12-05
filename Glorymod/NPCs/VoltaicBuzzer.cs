using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.ID;
using System.IO;
using Glorymod.Projectiles;

namespace Glorymod.NPCs
{
    public class VoltaicBuzzer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Voltaic Buzzer");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 6000;
            npc.defense = 20;
            npc.damage = 45;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.behindTiles = true;
            npc.boss = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0;
        }
        public override bool CheckActive()
        {
            return false;
        }
        int Subphase = 1;
        int PhaseChange;
        int pp;
        float DashSpeed = 50;
        float Xs = 0.9f;
        float Ys = 0.9f;
        float Distance;
        Vector2 SpinningPoint;
        Vector2 oldLoc;
        public override void AI()
        {
            #region Target
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if (player.dead || !player.active || player.ghost)
            {
                npc.TargetClosest(true);
            }
            #endregion
            PhaseChange++;
            #region Dash
            if (Subphase == 1)
            {
                if(PhaseChange < 30)
                {
                    npc.position.X = MathHelper.SmoothStep(player.Center.X + Distance, npc.Center.X, Xs);
                    npc.position.Y = MathHelper.SmoothStep(player.Center.Y, npc.Center.Y, Ys);
                }
                if(PhaseChange == 30)
                {
                    npc.velocity = new Vector2(-DashSpeed, 0);
                }
                if (PhaseChange > 30 && PhaseChange < 60)
                {
                    npc.position.X = MathHelper.SmoothStep(player.Center.X - Distance, npc.Center.X, Xs);
                    npc.position.Y = MathHelper.SmoothStep(player.Center.Y, npc.Center.Y, Ys);
                }
                if (PhaseChange == 60)
                {
                    npc.velocity = new Vector2(DashSpeed, 0);
                }

                if (PhaseChange > 90 && PhaseChange < 120)
                {
                    npc.position.X = MathHelper.SmoothStep(player.Center.X + Distance, npc.Center.X, Xs);
                    npc.position.Y = MathHelper.SmoothStep(player.Center.Y, npc.Center.Y, Ys);
                }
                if (PhaseChange == 120)
                {
                    npc.velocity = new Vector2(-DashSpeed, 0);
                }
                if (PhaseChange > 150 && PhaseChange < 180)
                {
                    npc.position.X = MathHelper.SmoothStep(player.Center.X - Distance, npc.Center.X, Xs);
                    npc.position.Y = MathHelper.SmoothStep(player.Center.Y, npc.Center.Y, Ys);
                }
                if (PhaseChange == 180)
                {
                    npc.velocity = new Vector2(DashSpeed, 0);
                }

                if (PhaseChange > 210 && PhaseChange < 240)
                {
                    npc.position.X = MathHelper.SmoothStep(player.Center.X + Distance, npc.Center.X, Xs);
                    npc.position.Y = MathHelper.SmoothStep(player.Center.Y, npc.Center.Y, Ys);
                }
                if (PhaseChange == 240)
                {
                    npc.velocity = new Vector2(-DashSpeed, 0);
                }
                if (PhaseChange > 270 && PhaseChange < 300)
                {
                    npc.position.X = MathHelper.SmoothStep(player.Center.X - 1000, npc.Center.X, Xs);
                    npc.position.Y = MathHelper.SmoothStep(player.Center.Y, npc.Center.Y, Ys);
                }
                if (PhaseChange > 300)
                {
                    PhaseChange = 0;
                    Subphase = 2;
                }
            }
            #endregion
            if (Subphase == 2)
            {
                if(PhaseChange == 2)
                {
                    npc.velocity = Vector2.Zero;
                    int i = Main.rand.Next(5);
                    pp = 500 + Main.rand.Next(100) - Main.rand.Next(100);
                    switch (i)
                    {
                        
                        case 1:
                            npc.position.X = player.Center.X + pp;
                            npc.position.Y = player.Center.Y + pp; 
                            break;
                        case 2:
                            npc.position.X = player.Center.X - pp;
                            npc.position.Y = player.Center.Y + pp;
                            break;
                        case 3:
                            npc.position.X = player.Center.X - pp;
                            npc.position.Y = player.Center.Y - pp;
                            break;
                        case 4:
                            npc.position.X = player.Center.X + pp;
                            npc.position.Y = player.Center.Y - pp;
                            break;
                    }
                    
                    SpinningPoint.X = npc.Center.X;
                    SpinningPoint.Y = npc.Center.Y + pp;
                    int arc = Projectile.NewProjectile(SpinningPoint, Vector2.Zero, ModContent.ProjectileType<VoltaicArc>(), 20, 0);
                    Main.projectile[arc].ai[1] = npc.whoAmI;
                    
                }
                oldLoc = new Vector2(0, -pp).RotatedBy(MathHelper.ToRadians(PhaseChange * 3));
                npc.position = SpinningPoint + oldLoc;
                if (PhaseChange > 120)
                {
                    PhaseChange = 0;
                    Subphase = 3;
                }
            }
            if (Subphase == 3)
            {
                
                if (PhaseChange > 300)
                {
                    PhaseChange = 0;
                    Subphase = 4;
                }
            }
            if (Subphase == 4)
            {
                //Rain Lightning
                if (PhaseChange > 300)
                {
                    PhaseChange = 0;
                    Subphase = 0;
                }
            }
        }
    }

    public class VoltaicArc : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Voltaic Arc");
        }
        public override void SetDefaults()
        {
            projectile.width = 90;
            projectile.height = 90;
            projectile.timeLeft = 200;
            projectile.aiStyle = 0;
            projectile.hostile = true;
            projectile.friendly = false;
        }
        public Vector2[] destination = new Vector2[3];
        public override void AI()
        {
            #region 1
            if (projectile.timeLeft == 200)
            {
                Main.NewText("a");
                destination[0] = Main.player[Main.npc[(int)projectile.ai[1]].target].Center;
            }
            Main.NewText(destination[0].X.ToString() + "   " + destination[0].Y.ToString());
            if(projectile.timeLeft == 160)
            {
                int lightning = Projectile.NewProjectile(projectile.Center, Vector2.Zero, ModContent.ProjectileType<LightningProjectile>(), 20, 0);
                Main.projectile[lightning].ai[0] = destination[0].X;
                Main.projectile[lightning].ai[1] = destination[0].Y;
            }
            #endregion
            #region 2
            if (projectile.timeLeft == 140)
            {
                Main.NewText("a");
                destination[1] = Main.player[Main.npc[(int)projectile.ai[1]].target].Center;
            }
            Main.NewText(destination[1].X.ToString() + "   " + destination[1].Y.ToString());
            if (projectile.timeLeft == 100)
            {
                int lightning = Projectile.NewProjectile(projectile.Center, Vector2.Zero, ModContent.ProjectileType<LightningProjectile>(), 20, 0);
                Main.projectile[lightning].ai[0] = destination[1].X;
                Main.projectile[lightning].ai[1] = destination[1].Y;
            }
            #endregion
            #region 3
            if (projectile.timeLeft == 80)
            {
                Main.NewText("a");
                destination[2] = Main.player[Main.npc[(int)projectile.ai[1]].target].Center;
            }
            Main.NewText(destination[2].X.ToString() + "   " + destination[2].Y.ToString());
            if (projectile.timeLeft == 40)
            {
                int lightning = Projectile.NewProjectile(projectile.Center, Vector2.Zero, ModContent.ProjectileType<LightningProjectile>(), 20, 0);
                Main.projectile[lightning].ai[0] = destination[2].X;
                Main.projectile[lightning].ai[1] = destination[2].Y;
            }
            #endregion
        }
    }
}