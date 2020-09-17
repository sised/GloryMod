using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Win32;

namespace Glorymod.Projectiles
{
    public class Tornado : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame Tornado");
            Main.projFrames[projectile.type] = 10;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 250);
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 60;
            projectile.height = 20;
            projectile.tileCollide = false;
            projectile.timeLeft = 700;
            aiType = ProjectileID.Sharknado;
        }
        float Xv = 0;
        bool XvIncreasing = true;
        Vector2 origin;
        public override void AI()
        {

            if(projectile.timeLeft == 699)
            {
                origin = projectile.Center;
                //projectile.scale = 0.3f + (projectile.ai[0] / 4);
            }
            if (projectile.ai[0] < 30 && projectile.timeLeft == 695)
            {
                int penis = Projectile.NewProjectile(origin.X, origin.Y - projectile.scale * 20, Vector2.Zero.X, Vector2.Zero.Y, ModContent.ProjectileType<Tornado>(), 20, 0);
                Main.projectile[penis].ai[0] = projectile.ai[0] + 1;
            }
            if (++projectile.frameCounter >= 4) 
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 10)
                {
                    projectile.frame = 0;
                }
            }
            if (XvIncreasing)
            {
                projectile.velocity.X = Xv;
                Xv *= 1.1f;
                Xv += 0.1f;
                if (Xv > 5)
                {
                    Xv = 0;
                    XvIncreasing = false;
                }
            }
            if (!XvIncreasing)
            {
                projectile.velocity.X = -Xv;
                Xv *= 1.1f;
                Xv += 0.1f;
                if (Xv > 5)
                {
                    Xv = 0;
                    XvIncreasing = true;
                }
            }

        }
    }
}
