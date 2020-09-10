using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace Glorymod.NPCs
{
    public class NeonSlime : ModNPC
    {
        int timerAbove;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Slime");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 100;
            npc.defense = 5;
            npc.aiStyle = 1;
            npc.height = 30;
            npc.width = 44;
            npc.damage = 40;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 1f;
            animationType = NPCID.BlueSlime;
            npc.value = 111;
            
            
            

            npc.buffImmune[BuffID.Confused] = false;


        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(NPC.downedSlimeKing)
            {
                return SpawnCondition.OverworldDaySlime.Chance * 0.1f;
            }
            else return SpawnCondition.OverworldDaySlime.Chance * 0.0f;
        }
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {


            player.AddBuff(BuffID.WitheredWeapon, 300, true);
            player.AddBuff(BuffID.WitheredArmor, 300, true);
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(4) < 1)
            {
                if (npc.lifeMax > 15)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("NeonGel"));
                }
            }
            if (Main.rand.Next(4) < 1)
            {
                if (npc.lifeMax > 15)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("NeonGel"));
                }
            }
            if (Main.rand.Next(4) < 1)
            {
                if (npc.lifeMax > 15)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("NeonGel"));
                }
            }
        }
        public override void AI()
        {
            timerAbove++;
            if (Main.player[npc.target].Center.Y <= npc.Center.Y)
            {
                timerAbove = 0;
                npc.noTileCollide = false;
            }
            else if (timerAbove > 250)
            {
                npc.noTileCollide = true;
            }
        }
        public override bool CheckDead()
        {
            for (int i = 0; i < 30; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = npc.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 87, 0f, 0f, 0, new Color(255, 176, 0), 1.118421f)];
            }
            return true;
        }
        

    }
}