using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class Explosion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Explosion");
        }
        public override void SetDefaults()
        {
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.width = 75;
            projectile.height = 75;
            projectile.timeLeft = 1;
        }
        public override void AI()
        {
            for(int i = 0; i < 5; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 75, 75, 104, 0f, 0f, 0, new Color(255, 255, 255), 5f)];
                dust.noGravity = true;
                Dust dust2;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                dust2 = Terraria.Dust.NewDustDirect(position, 75, 75, 35, 0f, 0f, 0, new Color(255, 255, 255), 2.631579f);
                dust2.noGravity = true;

            }
            Main.PlaySound(SoundID.Item14, (int)projectile.Center.X, (int)projectile.Center.Y);

        }
    }
}
