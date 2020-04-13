using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glorymod.NPCs
{
    public class NeonSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Slime");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 70;
            npc.defense = 5;
            npc.aiStyle = 1;
            npc.height = 30;
            npc.width = 44;
            npc.damage = 50;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 1f;
            animationType = NPCID.BlueSlime;
            
            

            

            npc.buffImmune[BuffID.Confused] = false;


        }
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {


            player.AddBuff(BuffID.WitheredWeapon, 300, true);
            player.AddBuff(BuffID.WitheredArmor, 300, true);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (NPC.downedMoonlord)
            {
                return SpawnCondition.Underworld.Chance * 0.2f;
            }
            else return SpawnCondition.Underworld.Chance * 0.0f;
        }


        

    }
}