/*using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Glorymod.Projectiles;

namespace Glorymod.NPCs
{
    public class Basaltite : ModNPC
    {
        public NPC npce;
        public bool Exist;
        public int iCarry;
        int TimeLeft = 0;
        public override void SetDefaults()
        {
            npc.dontTakeDamage = true;
            npc.lifeMax = 10;
            npc.width = 40;
            npc.height = 40;
            npc.damage = 40;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.aiStyle = -1;
            npc.knockBackResist = 0;
        }
        public override void AI()
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (!Exist)
                {
                    npce = Main.npc[i];
                }
                else break;
                if (npce.type == NPCID.WallofFlesh && npce.active && !Main.npc[i].GetGlobalNPC<GlobalNPCe>().FixerAttached)
                {
                    if (!Exist)
                    {
                        Exist = true;
                        iCarry = i;
                        Main.npc[i].GetGlobalNPC<GlobalNPCe>().FixerAttached = true;
                    }

                    break;
                }

            }
            TimeLeft++;
            if (TimeLeft > 200)
            {
                Despawn();
            }
            if(TimeLeft == 10)
            {
                int D1 = Projectile.NewProjectile(npc.Center, npc.velocity, ModContent.ProjectileType<MoltenDeathray2>(), 20, 1);
                Main.projectile[D1].ai[0] = 0;
                int D2 = Projectile.NewProjectile(npc.Center, npc.velocity, ModContent.ProjectileType<MoltenDeathray2>(), 20, 1);
                Main.projectile[D2].ai[0] = 45;
                int D3 = Projectile.NewProjectile(npc.Center, npc.velocity, ModContent.ProjectileType<MoltenDeathray2>(), 20, 1);
                Main.projectile[D3].ai[0] = -45;
            }
            if (Exist)
            {
                Main.npc[iCarry].GetGlobalNPC<GlobalNPCe>().FixerAttached = true;
                npce = Main.npc[iCarry];
                
                npc.position.X = npce.position.X - npc.width / 2;
                
                
                npc.position.Y = npce.position.Y - npc.height / 2;
            }

            
        }
        public void Despawn()
        {
            Main.npc[iCarry].GetGlobalNPC<GlobalNPCe>().FixerAttached = false;
            npc.active = false;
        }
    }
}*/
