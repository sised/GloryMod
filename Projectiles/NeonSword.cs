using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class NeonSword : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Sword");
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
            projectile.timeLeft = 400;

        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
        }
    }
}
