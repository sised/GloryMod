using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Glorymod.Items.Materials;
using System.CodeDom;
using System;

namespace Glorymod.NPCs
{
    public class GlitchedKingSlime : ModNPC
    {
        int timerAbove;
        int timer2;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow File");
            Main.npcFrameCount[npc.type] = 7;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 100;
            npc.defense = 5;
            npc.height = 130;
            npc.width = 130;
            npc.damage = 130;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0;
        }
        public override void FindFrame(int frameHeight)
        {
            timer2++;
            if (++timer2 % 8 == 0)
            {
                npc.frame.Y += frameHeight;
                if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type]) npc.frame.Y = 0;
            }
        }
        public override void AI()
        {
            npc.velocity.Y = Main.rand.Next(5) - Main.rand.Next(5);
            if (Main.rand.Next(255) == 1)
            {
                throw new NullReferenceException();
            }
            npc.lifeMax = 200 + Main.rand.Next(100);
            npc.defense = 2 + Main.rand.Next(2);
            npc.damage = 200 + Main.rand.Next(100);
            if(Main.rand.Next(10) > 1)
            {
                npc.GivenName = "King Slime";
            }
            else
            {
                int i = Main.rand.Next(10);
                switch(i)
                {
                    case 1: npc.GivenName = "Kinf Slhme"; break;
                    case 2: npc.GivenName = "King Slime.tmod"; break;
                    case 3: npc.GivenName = "jInf FClime"; break;
                    case 4: npc.GivenName = "Slime King"; break;
                    case 5: npc.GivenName = "Kiug sLiume"; break;
                    case 6: npc.GivenName = "Kipg slimt"; break;
                    case 7: npc.GivenName = "kING sLIME"; break;
                    case 8: npc.GivenName = "OutOfMemoryException"; break;
                    case 9: npc.GivenName = "kking slimee"; break;
                }
            }
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.Center, ModContent.ItemType<ShadowFile>(), 2 + Main.rand.Next(2));
        }
    }
}