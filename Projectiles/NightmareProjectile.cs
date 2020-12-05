using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class NightmareProjectile : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightmare Beam");
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
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustDirect(position, 30, 30, 6, -2.105263f, 10f, 0, new Color(255, 0, 50), 2.368421f);
            dust.noGravity = true;

        }

    }
}
