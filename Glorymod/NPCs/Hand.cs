using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Glorymod.NPCs
{
    public class Hand : ModNPC
    {
        int Degrees;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiend Viscount's Hand");
        }
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.width = 60;
            npc.height = 60;
            npc.damage = 40;
            npc.defense = 12;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lifeMax = 2000;
        }
        NPC npce;
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            return false;
        }
        public override void AI()
        {
            if (Main.player.Count(p => p.active && !p.dead) == 0 || !NPC.AnyNPCs(NPCID.SkeletronHead))
            {
                npc.active = false;
            }
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                npce = Main.npc[i];
                if (npce.type == NPCID.SkeletronHead && npce.active)
                {
                    break;
                }

            }
            if(!Main.npc[(int)npc.ai[0]].GetGlobalNPC<GlobalNPCe>().Phase2)
            {
                float speed = 20f;
                float inertia = 60f;
                Vector2 direction = new Vector2(npce.Center.X - npc.Center.X + 200, npce.Center.Y - npc.Center.Y + 100);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
            }
            else
            {
                Degrees += 2;
                if(Degrees > 360)
                {
                    Degrees = 0;
                }
                Vector2 vector = new Vector2(-500, 0).RotatedBy(MathHelper.ToRadians(Degrees));
                npc.position = (npce.Center + vector);
            }
        }
    }

    public class Hand2 : ModNPC
    {
        int Degrees;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiend Viscount's Hand");
        }
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.width = 60;
            npc.height = 60;
            npc.damage = 40;
            npc.defense = 12;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lifeMax = 2000;
        }
        NPC npce;
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            return false;
        }
        public override void AI()
        {
            if (Main.player.Count(p => p.active && !p.dead) == 0 || !NPC.AnyNPCs(NPCID.SkeletronHead))
            {
                npc.active = false;
            }
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                npce = Main.npc[i];
                if (npce.type == NPCID.SkeletronHead && npce.active)
                {
                    break;
                }

            }
            if (!Main.npc[(int)npc.ai[0]].GetGlobalNPC<GlobalNPCe>().Phase2)
            {
                float speed = 20f;
                float inertia = 60f;
                Vector2 direction = new Vector2(npce.Center.X - npc.Center.X - 200, npce.Center.Y - npc.Center.Y + 100);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
            }
            else
            {
                Degrees += 2;
                if (Degrees > 360)
                {
                    Degrees = 0;
                }
                Vector2 vector = new Vector2(500, 0).RotatedBy(MathHelper.ToRadians(Degrees));
                npc.position = (npce.Center + vector);
            }
        }
    }
}
