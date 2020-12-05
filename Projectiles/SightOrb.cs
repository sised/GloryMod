using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class SightOrb : ModProjectile
    {


        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 64;
            projectile.height = 64;
            projectile.tileCollide = false;
            projectile.timeLeft = 500;

        }
        public override void AI()
        {
        }
        public override void Kill(int timeLeft)
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            for (int i = 0; i < 13; i++)
            {
                dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 16, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            }

            Main.PlaySound(SoundID.Item14);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 2f, 0f, ModContent.ProjectileType<Projectiles.SightLaser>(), 20, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 1.4f, 1.4f, ModContent.ProjectileType<Projectiles.SightLaser>(), 20, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 1.4f, -1.4f, ModContent.ProjectileType<Projectiles.SightLaser>(), 20, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 2f, ModContent.ProjectileType<Projectiles.SightLaser>(), 20, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -2f, ModContent.ProjectileType<Projectiles.SightLaser>(), 20, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -1.4f, 1.4f, ModContent.ProjectileType<Projectiles.SightLaser>(), 20, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -1.4f, -1.4f, ModContent.ProjectileType<Projectiles.SightLaser>(), 20, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -2f, 0f, ModContent.ProjectileType<Projectiles.SightLaser>(), 20, 5, Main.myPlayer);
        }
    }
}
