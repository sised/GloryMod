using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using System.Linq;
using Terraria.DataStructures;
using Glorymod.Dusts;
namespace Glorymod.Projectiles
{
    public class AnnihBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Bolt");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 20;
            projectile.height = 20;
            projectile.tileCollide = true;
            projectile.timeLeft = 400;

        }
        public override void AI()
        {
            if (Main.rand.NextFloat() < 0.1184211f)
            {
                Dust dust2;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.Center;
                dust2 = Terraria.Dust.NewDustPerfect(position, ModContent.DustType<AnnihDust>());
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
    public class AnnihCrystal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Fragment");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 10;
            projectile.height = 10;
            projectile.tileCollide = true;
            projectile.timeLeft = 500;
            projectile.penetrate = 2;

        }
        public override void AI()
        {
            projectile.rotation += 0.3f;
        }

    }
    public class AmplifiedCrystal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amplified Crystal");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 10;
            projectile.height = 10;
            projectile.tileCollide = true;
            projectile.timeLeft = 500;
            projectile.penetrate = 2;

        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

    }
    public class OverdriveSeal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overdrive Seal");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.aiStyle = -1;
            projectile.light = 1f;
            projectile.alpha = 200;
            projectile.width = 87;
            projectile.height = 87;
            projectile.tileCollide = true;
            projectile.timeLeft = 500;
            projectile.penetrate = 2;

        }
        public override void AI()
        {
            if (projectile.timeLeft < 440)
            {
                projectile.alpha = 0;
                projectile.hostile = true;
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

    }
    public class AmplifiedCore : ModNPC
    {
        int lifetime;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amplified Core");
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 2000;
            npc.aiStyle = -1;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            int r = Main.rand.Next(360);
            npc.rotation = MathHelper.ToRadians(r);
            npc.width = 52;
            npc.height = 52;
            npc.knockBackResist = 0;
        }
        public override void AI()
        {
            if (lifetime < 20)
            {
                npc.alpha = 255 - lifetime * 12;
            }
            lifetime++;
            float change = 4f - lifetime * 0.003f;
            if (change < 0)
            {
                change = 0;
            }
            npc.rotation += MathHelper.ToRadians(change);
            if (lifetime == 400)
            {
                Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 4);
                CircularBullethell(10, ModContent.ProjectileType<AmplifiedCrystal>(), 10, 40, 0, npc.Center);
                npc.active = false; 
            }
            npc.TargetClosest();
            Player player = Main.player[npc.target];
            if(lifetime == 1)
            {
                Vector2 dash = player.Center - npc.Center;
                dash.Normalize();
                dash *= 10;
                npc.velocity = dash;
            }
            npc.velocity *= 0.98f;
        }
        public override bool CheckDead()
        {
            CircularBullethell(10, ModContent.ProjectileType<AmplifiedCrystal>(), 10, 40, 0, npc.Center);
            return true;
        }
        public void CircularBullethell(int ProjectileCount, int ProjectileType, float ProjectileVelocity, int ProjectileDamage, int ProjectileKnockback, Vector2 CenterPosition, float ai0 = 0, float ai1 = 0)
        {
            Vector2 circle = new Vector2(0, ProjectileVelocity);
            for (int i = 0; i < ProjectileCount; i++)
            {
                Vector2 circle2 = circle.RotatedBy(MathHelper.ToRadians(i * (360f / ProjectileCount)));
                Projectile.NewProjectile(CenterPosition, circle2, ProjectileType, ProjectileDamage, ProjectileKnockback, Main.myPlayer, ai0, ai1);
            }
        }
    }

    
    public class OFlameProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amplified Fireball");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 10;
            projectile.scale = 1.2f;
            projectile.height = 10;
            projectile.tileCollide = true;
            projectile.timeLeft = 400;
            projectile.penetrate = 2;

        }
        public override void AI()
        {
            if(Main.rand.Next(3) == 2)
            Dust.NewDust(projectile.Center, projectile.width, projectile.height, ModContent.DustType<AnnihDustO>() , 0, 0);  
            projectile.rotation += 0.3f;
        }

    }

    public class AnnihScythe : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Scythe");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 40;
            projectile.height = 40;
            projectile.tileCollide = true;
            projectile.timeLeft = 1000;

        }
        public override void AI()
        {
            if(projectile.timeLeft < 50)
            {
                projectile.hostile = false;
                projectile.alpha += 6;
            }
            projectile.rotation += 0.3f;
        }

    }
    public class JapanBanger69 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Nuke");
            Main.projFrames[projectile.type] = 9;
        }
        int radius = 700;
        int countdown = 4;
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 76;
            projectile.height = 76;
            projectile.tileCollide = true;
            projectile.timeLeft = 225;

        }
        public override void AI()
        {
            Dust dust2;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust2 = Terraria.Dust.NewDustPerfect(position, ModContent.DustType<AnnihDust>());

            if (projectile.timeLeft % 45 == 0)
            {
                CombatText.NewText(new Rectangle((int)projectile.Center.X, (int)projectile.Center.Y, 40, 20), Color.Red, countdown, false);
                countdown--;
            }
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 9)
                {
                    projectile.frame = 0;
                }
            }
            if (projectile.timeLeft == 199)
            {
                //spawn helper;
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if(projectile.timeLeft == 20)
            {
                if(projectile.ai[0] == 2)
                {
                    Projectile.NewProjectile(projectile.Center, Vector2.Zero, ModContent.ProjectileType<NuclearExplosion>(), 0, 0, Main.myPlayer, 2);
                } else
                Projectile.NewProjectile(projectile.Center, Vector2.Zero, ModContent.ProjectileType<NuclearExplosion>(), 0, 0, Main.myPlayer);
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 360; i++)
            {

                Dust dust;

                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.Center + new Vector2(radius, 0).RotatedBy(MathHelper.ToDegrees(i));
                int r = Main.rand.Next(3);
                if (r == 2)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, ModContent.DustType<AnnihDust>(), 0, 0, 0, new Color(255, 255, 255), 1f)];
                    dust.noGravity = true;
                }


            }
            Main.PlaySound(SoundID.NPCKilled, -1, -1, mod.GetSoundSlot(SoundType.NPCKilled, "Sounds/NPCKilled/398283__flashtrauma__explosion"));
        }
    }
    public class NuclearExplosion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("NuclearExplosion");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 1;
            projectile.height = 1;
            projectile.tileCollide = true;
            projectile.timeLeft = 200;

        }
        int radius = 700;
        public override void AI()
        {
            if(projectile.timeLeft == 180)
            {
                for (int i = 0; i < Main.player.Count(); i++)
                {
                    Vector2 distance = Main.player[i].Center - projectile.Center;
                    if (distance.Length() < radius)
                    {
                        Main.player[i].Hurt(PlayerDeathReason.ByCustomReason(Main.player[i].name + " got nuked"), 350, -Main.LocalPlayer.direction);
                    }
                }
            }

        }
    }
}
