using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Linq;
using System;
using Glorymod.Dusts;

namespace Glorymod.NPCs
{
    public class TrophyOfMenaceBB : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trophy of Menace");
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 2000;
            npc.dontTakeDamage = true;
            npc.damage = 0;
            npc.width = 20;
            npc.height = 20;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
            npc.aiStyle = -1;
        }
        int i;
        public override void AI()
        {
            if(i % 30 == 0)
            {
                Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<ScarletWine>(), 20, 0);
            }
            npc.TargetClosest();
            Player player = Main.player[npc.target];
            i++;
            npc.rotation = MathHelper.Clamp(npc.velocity.ToRotation(), MathHelper.ToRadians(-10), MathHelper.ToRadians(10));
            if(i < 120)
            {
                npc.TargetClosest();
                float speed = 45f;
                float inertia = 60f;
                Vector2 direction = new Vector2((player.Center.X - npc.Center.X) + 100, (player.Center.Y - npc.Center.Y) - 300);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
            }
            if(i > 119)
            {
                npc.TargetClosest();
                float speed = 45f;
                float inertia = 60f;
                Vector2 direction = new Vector2((player.Center.X - npc.Center.X) - 100, (player.Center.Y - npc.Center.Y) - 300);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
            }
            if(i == 240)
            {
                i = 0;
            }
            if(!NPC.AnyNPCs(NPCID.WallofFlesh))
            {
                npc.active = false;
            }
        }
    }

    public class ScarletWine : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scarlet Wine");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.aiStyle = 1;
            projectile.tileCollide = false;
            projectile.timeLeft = 75;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.PotionSickness, 1800);
        }
        public override void AI()
        {
            projectile.rotation = 0;
        }
        public override bool PreKill(int timeLeft)
        {
            for(int i = 0; i < 2; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<ScarletDust>());
            }
            return true;
        }
    }
}
