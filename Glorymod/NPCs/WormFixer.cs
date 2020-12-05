using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Glorymod.Projectiles;
namespace Glorymod.NPCs
{
    public class WormFixer : ModNPC
    {
        public bool Exist = false;
        public NPC npce;
        int TimeLeft;
        public int iCarry;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Worm Fixer");
        }
        int CrystalTimer;
        public override void SetDefaults()
        {
            npc.width = 1;
            npc.height = 1;
            npc.aiStyle = -1;
            //npc.dontTakeDamage = true;
            npc.damage = 0;
            npc.lifeMax = 10;
            npc.dontTakeDamage = true;
            
        }
        public void Despawn()
        {
            Main.npc[iCarry].GetGlobalNPC<GlobalNPCe>().FixerAttached = false;
            npc.active = false;
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
                if (npce.type == ModContent.NPCType<EoW3>() && npce.active && !Main.npc[i].GetGlobalNPC<GlobalNPCe>().FixerAttached)
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
            if(TimeLeft > 300)
            {
                Despawn();
            }
            if(Exist)
            {
                Main.npc[iCarry].GetGlobalNPC<GlobalNPCe>().FixerAttached = true;
                npce = Main.npc[iCarry];
                npc.position.X = npce.position.X - npc.width / 2;
                npc.position.Y = npce.position.Y - npc.height / 2;
            }
            
            
            CrystalTimer++;
            if (CrystalTimer > 50)
            {
                Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 4);
                Vector2 up = new Vector2(0, 3);
                for (int i = 0; i < 11; i++)
                {
                    Vector2 Projectile360 = new Vector2(0, 3).RotatedBy(i * 36);
                    Projectile.NewProjectile(npc.Center, Projectile360, ModContent.ProjectileType<EoWcrystal>(), 20, 1);
                }
                CrystalTimer = 0;
            }
        }
    }
}
