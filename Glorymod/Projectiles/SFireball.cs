using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class SFireball : ModProjectile
    {


        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 8;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 14;
            projectile.height = 14;
            projectile.tileCollide = false;
            projectile.timeLeft = 700;

        }
        public override void AI()
        {
            if (Main.rand.NextFloat() < 0.3157895f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 0, new Color(255, 255, 255), 0.3289474f)];
                dust.fadeIn = 0.5921053f;
            }

        }

    }
}
