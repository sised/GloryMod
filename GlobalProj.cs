using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Glorymod;
using Microsoft.Xna.Framework;
using Glorymod.Projectiles;
namespace Glorymod
{
    public class GlobalProj : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
        bool oneframe = true;
        public override void SetDefaults(Projectile projectile)
        {
            if (Mworld.Menace)
            {
                if (projectile.type == 44) //demon sickle
                {
                    projectile.tileCollide = false;
                    projectile.friendly = false;
                    projectile.hostile = true;
                }
                if (projectile.type == ProjectileID.DeathLaser)
                {
                    projectile.timeLeft = 750;
                    projectile.tileCollide = false;
                }
            }
            if (projectile.type == 466) //lunatic cultist's lightning strikes
            {
                projectile.tileCollide = false;
            }
            
        }
        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            if(Mworld.Menace)
            {
                if (projectile.type == ProjectileID.DeathLaser)
                {
                    target.AddBuff(BuffID.Confused, 10);
                }
            }

        }
        public override void AI(Projectile projectile)
        {
            if(oneframe && projectile.type == 44)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * 100, projectile.velocity.Y * 100, ModContent.ProjectileType<SickleWarning>(), 20, 5, Main.myPlayer);
            }
            oneframe = false;
        }
    }
}