using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class DemonClaw : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Claw");
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.height = 22;
            projectile.width = 22;
            projectile.hostile = true;
            projectile.friendly = false;
            aiType = ProjectileID.Skull;
            projectile.tileCollide = true;
            projectile.timeLeft = 1000;
        }
        public override void AI()
        {
            Vector2 position = projectile.oldPosition;
            projectile.rotation = projectile.velocity.ToRotation();
            if (++projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 3)
                {
                    projectile.frame = 0;
                }
            }
        }
    }    
}
