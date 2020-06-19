using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace Glorymod.Projectiles
{
    public class SuperOrb : ModProjectile
    {


        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 60;
            projectile.height = 60;
            projectile.tileCollide = false;
            projectile.timeLeft = 500;
            projectile.alpha = 255;
        }
        public override void AI()
        {
            projectile.alpha -= 20;
            if (projectile.timeLeft == 400 || projectile.timeLeft == 300 || projectile.timeLeft == 200 || projectile.timeLeft == 100)
            {


                Vector2 noscope = Main.player[0].Center - projectile.Center;

                noscope.Normalize();
                noscope *= 20;
                
                Projectile.NewProjectile(projectile.Center, noscope, ModContent.ProjectileType<SuperVortex>(), 69420, 0);
                
                Main.PlaySound(SoundID.Item9, projectile.Center);
            }
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
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 2f, 0f, ModContent.ProjectileType<Projectiles.SightLaser>(), 69420, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 1.4f, 1.4f, ModContent.ProjectileType<Projectiles.SightLaser>(), 69420, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 1.4f, -1.4f, ModContent.ProjectileType<Projectiles.SightLaser>(), 69420, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 2f, ModContent.ProjectileType<Projectiles.SightLaser>(), 69420, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -2f, ModContent.ProjectileType<Projectiles.SightLaser>(), 69420, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -1.4f, 1.4f, ModContent.ProjectileType<Projectiles.SightLaser>(), 69420, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -1.4f, -1.4f, ModContent.ProjectileType<Projectiles.SightLaser>(), 69420, 5, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -2f, 0f, ModContent.ProjectileType<Projectiles.SightLaser>(), 69420, 5, Main.myPlayer);
        }
    }
}
