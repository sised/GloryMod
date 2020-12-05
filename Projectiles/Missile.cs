using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Threading;
using Glorymod.Projectiles;
using System.Dynamic;
using Glorymod.Items.Materials;
using System.Linq;
using Glorymod.Items.Accessories.PreHm;
using System.Data.SqlTypes;
using System.Runtime.Remoting.Messaging;

namespace Glorymod.Projectiles
{
    public class Missile : ModNPC
    {
        int timer;
        bool spawned;
        int timer2;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Homing Compact Explosive Missile");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.width = 25;
            npc.height = 25;
            npc.lifeMax = 1;
            npc.knockBackResist = 0;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.damage = 80;
            npc.buffImmune[BuffID.OnFire] = true;
        }
        Vector2 direction = new Vector2(5, 5).RotatedBy(MathHelper.ToDegrees(Main.rand.Next(360)));
        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<Explosion>(), 0, 2);
            npc.active = false;
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<Explosion>(), 0, 2);
            npc.active = false;
        }
        public override void AI()
        {
            if(timer < 50)
            {
                npc.velocity = direction;
                npc.rotation = npc.velocity.ToRotation() - MathHelper.ToDegrees(90);
            }
            timer++;
            if(timer > 50 )
            {
                npc.rotation = npc.velocity.ToRotation() - MathHelper.ToDegrees(90);
                Player player = Main.player[npc.target];
                npc.TargetClosest();
                float speed = 15f;
                float inertia = 60f;
                Vector2 direction = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
            }
            if(timer == 190)
            {
                Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<Explosion>(), 0, 2);
                npc.active = false;
            }
            
        }
        public override void FindFrame(int frameHeight)
        {
            timer2++;
            if (timer2 > 8)
            {
                npc.frame.Y = 0;
            }
            if (timer2 > 16)
            {
                npc.frame.Y = frameHeight * 1;

            }
            if (timer2 > 22)
            {
                npc.frame.Y = frameHeight * 2;

            }
            if (timer2 > 28)
            {
                npc.frame.Y = frameHeight * 3;
                timer2 = 0;

            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<Explosion>(), 0, 2);
            npc.active = false;
        }
    }
}
