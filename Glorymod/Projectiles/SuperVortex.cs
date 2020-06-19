using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class SuperVortex : ModProjectile
    {


        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.light = 1f;
            projectile.width = 8;
            projectile.height = 8;
            projectile.tileCollide = true;
            projectile.timeLeft = 240;
            projectile.aiStyle = 107;
            aiType = ProjectileID.NebulaSphere;
            projectile.alpha = 255;
        }
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 20; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position2 = projectile.Center;
                dust = Main.dust[Terraria.Dust.NewDust(position2, 8, 8, 57, 0f, 0f, 218, new Color(0, 255, 17), 1f)];
            }
        }
        public override void AI()
        {
            projectile.alpha -= 20;
            if (Main.rand.NextFloat() < 0.6052632f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position2 = projectile.Center;
                dust = Main.dust[Terraria.Dust.NewDust(position2, 8, 8, 57, 0f, 0f, 218, new Color(0, 255, 17), 1f)];
            }

            Vector2 position = projectile.oldPosition;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

    }
}
