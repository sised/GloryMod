using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class FiendBolt : ModProjectile
    {
        bool spawn = true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiend Bolt");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 6;
            projectile.height = 6;
            projectile.timeLeft = 200;
            projectile.width = 26;
            projectile.height = 26;
            projectile.tileCollide = false;

        }
        public override void AI()
        {
            if(spawn)
            {
                for(int i = 0; i < 15; i++)
                {
                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = projectile.position;
                    dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 15, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                }
                spawn = false;
            }
            

        }

    }
}

