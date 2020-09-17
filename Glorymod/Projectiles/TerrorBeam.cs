using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Win32;

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
            if(projectile.ai[0] == 0)
            {
                projectile.timeLeft -= 5;
                if (projectile.timeLeft > 330)
                {
                    projectile.friendly = false;
                }
                else projectile.friendly = true;
            }
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
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Vector2.Zero.X, Vector2.Zero.Y, ModContent.ProjectileType<TerrorPlosion>(), 30, 0);
            if(projectile.ai[0] == 1)
            {
                for(int i = 0; i < 10; i++)
                {
                    Vector2 a = new Vector2(0, 5).RotatedBy(MathHelper.ToRadians(i * 36));
                    int B = Projectile.NewProjectile(projectile.Center, a, ModContent.ProjectileType<TerrorBeam>(), 20, 0, Main.myPlayer);
                    Main.projectile[B].ai[0] = 0;
                }
            }
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
            projectile.width = 50;
            projectile.height = 50;
            projectile.tileCollide = false;
            projectile.timeLeft = 28;
            projectile.penetrate = 20;
            projectile.scale = 1;
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
