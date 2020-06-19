using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class EoWcrystal : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 14;
            projectile.height = 14;
            projectile.tileCollide = true;
            projectile.timeLeft = 500;

        }
        public override void AI()
        {



            Dust dust;           
            dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 18, 0f, 0f, 0, new Color(255, 255, 255), 1f)]; 
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;

        }

    }
}
