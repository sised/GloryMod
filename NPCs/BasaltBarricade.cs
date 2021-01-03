using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Glorymod.NPCs
{
    public class BasaltBarricade : ModNPC
    {
        int timer;
        int subphase = 1;
        public override bool CheckDead()
        {
            Gore.NewGore(new Vector2(npc.Center.X + Main.rand.Next(50) - Main.rand.Next(50), npc.Center.Y + Main.rand.Next(50) - Main.rand.Next(50)),
                new Vector2(npc.velocity.X, npc.velocity.Y), mod.GetGoreSlot("Gores/WoFgore1"));
            Gore.NewGore(new Vector2(npc.Center.X + Main.rand.Next(50) - Main.rand.Next(50), npc.Center.Y + Main.rand.Next(50) - Main.rand.Next(50)),
                new Vector2(npc.velocity.X, npc.velocity.Y), mod.GetGoreSlot("Gores/WoFgore1"));
            Gore.NewGore(new Vector2(npc.Center.X + Main.rand.Next(50) - Main.rand.Next(50), npc.Center.Y + Main.rand.Next(50) - Main.rand.Next(50)),
                new Vector2(npc.velocity.X, npc.velocity.Y), mod.GetGoreSlot("Gores/WoFgore2"));
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Basalt Barricade");
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 2000;
            npc.damage = 120;
            npc.defense = 15;
            npc.aiStyle = -1;
            npc.height = 70;
            npc.width = 70;
            npc.boss = true;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
            npc.scale = 1.2f;
            npc.HitSound = SoundID.NPCHit2;
            npc.noGravity = true;
            npc.knockBackResist = 0;
        }
        public override void AI()
        {
            npc.TargetClosest();
            Player player = Main.player[npc.target];
            Vector2 between = npc.Center - player.Center;
            between.Normalize();
            npc.rotation = between.ToRotation();
            timer++;
            if(subphase == 1 && timer > 300)
            {
                subphase = 2;
                timer = 0;
            }
            if(subphase == 2 && timer > 300)
            {
                subphase = 1;
                timer = 0;
            }
            if(subphase == 1 && timer % 100 == 0)
            {
                npc.velocity = between.RotatedBy(MathHelper.Pi) * 10;
            }
            if(subphase == 2)
            {
                float speed = 20f;
                float inertia = 60f;
                Vector2 direction = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
            }
        }
    }
}
