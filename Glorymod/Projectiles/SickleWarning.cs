using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class SickleWarning : ModProjectile
    {


        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 14;
            projectile.height = 14;
            projectile.tileCollide = false;
            projectile.timeLeft = 300;

        }
        public override void AI()
        {
            
            
            Dust dust;
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 20, new Vector2(0f, 0f), 0, new Color(209, 0, 255), 1f);
            

        }

    }
}
