using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class TerrorBeam : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terror Beam");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 32;
            projectile.height = 32;
            projectile.tileCollide = false;
            projectile.timeLeft = 400;
            projectile.penetrate = 1;
        }
        public override void AI()
        {
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
        }
        public override bool PreKill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center.X + 60, projectile.Center.Y + 60, Vector2.Zero.X, Vector2.Zero.Y, ModContent.ProjectileType<TerrorPlosion>(), 30, 0);
            return true;
        }
    }


    public class TerrorPlosion : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terror Plosion");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 60;
            projectile.height = 60;
            projectile.tileCollide = false;
            projectile.timeLeft = 28;
            projectile.penetrate = 20;
            projectile.scale = 2;
        }
        public override void AI()
        {
            
            if (++projectile.frameCounter >= 7)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }

        }

    }
}
