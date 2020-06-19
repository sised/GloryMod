using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class NeonVortex : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Vortex");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 32;
            projectile.height = 32;
            projectile.tileCollide = false;
            projectile.timeLeft = 1000;
            
        }
        public override void AI()
        {
            projectile.rotation += 0.03f;
            
        }

    }
}