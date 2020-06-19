using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class NeonBeam2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Beam");
            
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
            projectile.tileCollide = true;
            projectile.timeLeft = 400;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

    }
}
