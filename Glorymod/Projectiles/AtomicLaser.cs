using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class AtomicLaser : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atomic Laser");
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 6;
            projectile.height = 6;
            projectile.timeLeft = 400;

        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

    }
}
