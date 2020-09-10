using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class LavaBlob : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lava Blob");
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.height = 30;
            projectile.width = 30;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.aiStyle = 1;
            projectile.tileCollide = true;
            projectile.timeLeft = 1000;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 10f, ModContent.ProjectileType<LavaMine>(), 20, 1);
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            for(int i = 0; i < 15; i++)
            {
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 55, 0f, -2.894737f, 0, new Color(255, 255, 255), 1f)];
            }
            
            projectile.active = false;
            return true;
        }
        public override void AI()
        {
            Vector2 position = projectile.oldPosition;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
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

    public class LavaMine : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lava Mine");
        }
        public override void SetDefaults()
        {
            projectile.height = 5;
            projectile.width = 30;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.aiStyle = 1;
            projectile.tileCollide = true;
            projectile.timeLeft = 400;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //spawn mine
            projectile.velocity.Y = 0;
            return false;
        }
        public override void AI()
        {
            projectile.rotation = 0;
        }
    }
}
