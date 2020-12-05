using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class WoFknife : ModProjectile
    {


        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 22;
            projectile.height = 18;
            projectile.tileCollide = false;
            projectile.timeLeft = 100;
        }
        public override void AI()
        {
            if(projectile.timeLeft < 10)
            {
                projectile.hostile = false;
            }
            if(projectile.timeLeft < 20)
            {
                projectile.alpha += 12;
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}
