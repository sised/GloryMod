using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Glorymod.Projectiles;
namespace Glorymod.NPCs
{
    public class WoFeye1 : ModNPC
    {
        int timer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazing Bombora");
        }
        public override void NPCLoot()
        {
            int rand = Main.rand.Next(8);
            if (rand == 1)
            {
                Item.NewItem(npc.getRect(), ItemID.RangerEmblem);
            }
            if (rand == 2)
            {
                Item.NewItem(npc.getRect(), ItemID.SorcererEmblem);
            }
            if (rand == 3)
            {
                Item.NewItem(npc.getRect(), ItemID.SummonerEmblem);
            }
            if (rand == 4)
            {
                Item.NewItem(npc.getRect(), ItemID.WarriorEmblem);
            }

        }
        public override void SetDefaults()
        {
            npc.scale = 1.2f;
            npc.aiStyle = 5;
            aiType = NPCID.EaterofSouls;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
            npc.lifeMax = 600;
            npc.damage = 50;
            npc.width = 106;
            npc.height = 106;
            npc.defense = 15;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath5;
            npc.value = 6720;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return SpawnCondition.Underworld.Chance * 0.01f;
            }
            else return SpawnCondition.Underworld.Chance * 0.00f;
        }
        public override void AI()
        {
            timer++;
            if (timer > 60)
            {
                for (int i = 0; i < 10; i++)
                {
                    Vector2 noscope = Main.player[npc.target].Center - npc.Center;
                    noscope.Normalize();
                    noscope *= 10f + Main.rand.Next(30) * 0.1f; // velocity
                    noscope = noscope.RotatedByRandom(MathHelper.ToRadians(15));
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, noscope.X, noscope.Y, ModContent.ProjectileType<SFireball>(), 20, 5, Main.myPlayer);
                    noscope = Main.player[npc.target].Center - npc.Center;
                }
                timer = 0;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width + 5), Main.rand.Next(npc.height + 5));
                Vector2 pos2 = npc.position + new Vector2(Main.rand.Next(npc.width + 5), Main.rand.Next(npc.height + 5));
                int gore = Gore.NewGore(pos, npc.velocity = -npc.velocity, mod.GetGoreSlot("Gores/WoFgore1"));
                int gore2 = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoFgore3"));
                int gore3 = Gore.NewGore(pos2, npc.velocity, mod.GetGoreSlot("Gores/WoFgore3"));
                int gore4 = Gore.NewGore(pos2, npc.velocity, mod.GetGoreSlot("Gores/WoFgore4"));
                Main.gore[gore].timeLeft = 240;
                Main.gore[gore2].timeLeft = 240;
                Main.gore[gore3].timeLeft = 240;

                for (int k = 0; k < 9; k++)
                {
                    Dust dust;
                    Vector2 position = npc.Center;
                    dust = Terraria.Dust.NewDustDirect(position, 60, 60, 174, 0f, 0f, 0, new Color(255, 0, 0), 2f);
                }
            }
            else
            {
                for (int k = 0; k < 9; k++)
                {
                    Dust dust;
                    Vector2 position = npc.Center;
                    dust = Terraria.Dust.NewDustDirect(position, 60, 60, 174, 0f, 0f, 0, new Color(255, 0, 0), 1f);
                }
            }


        }
    }
}

