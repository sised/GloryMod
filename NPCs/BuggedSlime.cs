using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Glorymod.Items.Materials;
namespace Glorymod.NPCs
{
    public class BuggedSlime : ModNPC
    {
        public override void NPCLoot()
        {
            Item.NewItem(npc.Center, ModContent.ItemType<MainBat>());
        }
        public int timer2;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bugged Slime");
            Main.npcFrameCount[npc.type] = 5;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 200;
            npc.damage = 200000000;
            npc.defense = 100;
            npc.aiStyle = 1;
            aiType = NPCID.BlueSlime;
            npc.height = 22;
            npc.width = 32;
        }
        public override void FindFrame(int frameHeight)
        {
            timer2++;

            if (timer2 > 2)
            {
                 npc.frame.Y = 0;
            }
            if (timer2 > 4)
            {
                 npc.frame.Y = frameHeight * 1;

            }
            if (timer2 > 6)
            {
                npc.frame.Y = frameHeight * 2;
            }
            if (timer2 > 8)
            {
                npc.frame.Y = frameHeight * 3;
            }
            if (timer2 > 10)
            {
                npc.frame.Y = frameHeight * 4;
                timer2 = 0;
            }

        }
        public override void AI()
        {
            int i = Main.rand.Next(7);
            switch(i)
            {
                case 1: npc.GivenName = "Npi2XUhKW5"; break;
                case 2: npc.GivenName = "Lerv0imFm6"; break;
                case 3: npc.GivenName = "B2cjbz4Ifl"; break;
                case 4: npc.GivenName = "kGnhy438wF"; break;
                case 5: npc.GivenName = "WI9JzYEfx4"; break;
                case 6: npc.GivenName = "nvEWIt8XSp"; break;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(ModContent.GetInstance<GloriousConfig>().Glitch)
            {
                return SpawnCondition.OverworldDaySlime.Chance * 0.1f;
            }
            else return SpawnCondition.OverworldDaySlime.Chance * 0.0f;
        }
    }
}
