using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using System.Linq;
using Terraria.DataStructures;
using Glorymod.Dusts;

namespace Glorymod.Projectiles
{
    public class AnnihBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Bolt");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 10;
            projectile.height = 10;
            projectile.tileCollide = true;
            projectile.timeLeft = 400;

        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

    }
    public class AnnihCrystal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Fragment");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 10;
            projectile.height = 10;
            projectile.tileCollide = true;
            projectile.timeLeft = 500;
            projectile.penetrate = 2;

        }
        public override void AI()
        {
            projectile.rotation += 0.3f;
        }

    }
    public class AnnihScythe : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Scythe");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 20;
            projectile.height = 20;
            projectile.tileCollide = true;
            projectile.timeLeft = 1000;

        }
        public override void AI()
        {
            if(projectile.timeLeft < 50)
            {
                projectile.hostile = false;
                projectile.alpha += 6;
            }
            projectile.rotation += 0.3f;
        }

    }
    public class JapanBanger69 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Nuke");
            Main.projFrames[projectile.type] = 9;
        }
        int radius = 700;
        int countdown = 4;
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 76;
            projectile.height = 76;
            projectile.tileCollide = true;
            projectile.timeLeft = 225;

        }
        public override void AI()
        {
            Dust dust2;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust2 = Terraria.Dust.NewDustPerfect(position, ModContent.DustType<AnnihDust>());

            if (projectile.timeLeft % 45 == 0)
            {
                CombatText.NewText(new Rectangle((int)projectile.Center.X, (int)projectile.Center.Y, 40, 20), Color.Red, countdown, false);
                countdown--;
            }
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 9)
                {
                    projectile.frame = 0;
                }
            }
            if (projectile.timeLeft == 199)
            {
                //spawn helper;
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if(projectile.timeLeft == 20)
            {
                Projectile.NewProjectile(projectile.Center, Vector2.Zero, ModContent.ProjectileType<NuclearExplosion>(), 0, 0, Main.myPlayer);
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 360; i++)
            {

                Dust dust;

                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.Center + new Vector2(radius, 0).RotatedBy(MathHelper.ToDegrees(i));
                int r = Main.rand.Next(3);
                if (r == 2)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 6, 0, 0, 0, new Color(255, 255, 255), 1f)];
                    dust.noGravity = true;
                }


            }
            Main.PlaySound(SoundID.NPCKilled, -1, -1, mod.GetSoundSlot(SoundType.NPCKilled, "Sounds/NPCKilled/398283__flashtrauma__explosion"));
        }
    }
    public class NuclearExplosion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("NuclearExplosion");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 1;
            projectile.height = 1;
            projectile.tileCollide = true;
            projectile.timeLeft = 200;

        }
        int radius = 700;
        public override void AI()
        {
            if(projectile.timeLeft == 180)
            {
                for (int i = 0; i < Main.player.Count(); i++)
                {
                    Vector2 distance = Main.player[i].Center - projectile.Center;
                    if (distance.Length() < radius)
                    {
                        Main.player[i].Hurt(PlayerDeathReason.ByCustomReason(Main.player[i].name + " got nuked"), 350, -Main.LocalPlayer.direction);
                    }
                }
            }
            
            if(projectile.timeLeft == 199)
            {
                if (Main.netMode != NetmodeID.Server && !Filters.Scene["Shockwave"].IsActive())
                {
                    Filters.Scene.Activate("Shockwave", projectile.Center).GetShader().UseColor(3, 4, 50).UseTargetPosition(projectile.Center);
                }
                
            }
            if (Main.netMode != NetmodeID.Server && Filters.Scene["Shockwave"].IsActive())
            {
                float progress = (180f - projectile.timeLeft) / 60f; // Will range from -3 to 3, 0 being the point where the bomb explodes.
                Filters.Scene["Shockwave"].GetShader().UseProgress(progress).UseOpacity(100f * (1 - progress / 3f));
            }

        }
        public override void Kill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.Server && Filters.Scene["Shockwave"].IsActive())
            {
                Filters.Scene["Shockwave"].Deactivate();
            }
        }
    }
}
