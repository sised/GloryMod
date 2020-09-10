using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class NeonVortex : ModProjectile
    {
        bool alreadyboom = false;
        int timer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Vortex");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 150;
            projectile.width = 32;
            projectile.height = 32;
            projectile.tileCollide = false;
            projectile.timeLeft = 1000;
            
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 87, 0f, 0f, 0, new Color(255, 176, 0), 1.118421f)];
            }
        }
        public override void AI()
        {
            projectile.rotation += 0.03f;
            timer++;
            if(timer > 120)
            {
                if(!alreadyboom)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = projectile.position;
                        dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 87, 0f, 0f, 0, new Color(255, 176, 0), 1.118421f)];
                    }
                    alreadyboom = true;
                }
                projectile.alpha = 0;
                projectile.hostile = true;
            }
        }

    }
}