using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class Eyep : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 10;
            projectile.height = 10;
            projectile.tileCollide = false;
            projectile.timeLeft = 700;
            projectile.scale = 1.2f;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;

        }

    }
}