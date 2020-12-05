using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class RoyalEmeraldP : ModProjectile
    {


        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.width = 4;
            projectile.height = 4;
            projectile.tileCollide = true;
            projectile.timeLeft = 700;

        }
        public override void AI()
        {
            if (Main.rand.NextFloat() < 0.6052632f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position2 = projectile.Center;
                dust = Main.dust[Terraria.Dust.NewDust(position2, 0, 0, 57, 0f, 0f, 218, new Color(0, 255, 17), 1f)];
            }

            Vector2 position = projectile.oldPosition;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

    }
}
