using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class BrainFlame2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Flames");
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
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Dust dust;
            dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 55, 0f, 0f, 0, new Color(255, 0, 0), 1f)];
        }

    }
}

