using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class VoltaicSword : ModProjectile
    {


        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 255;
            projectile.width = 22;
            projectile.height = 32;
            projectile.tileCollide = true;
            projectile.timeLeft = 500;
        }
        public override void AI()
        {
            if(projectile.alpha > 0)
            {
                projectile.alpha -= 6;
            }
            if(projectile.alpha <= 12)
            {
                projectile.hostile = true;
                projectile.position.Y += 7f;
            }
        }
    }
}
