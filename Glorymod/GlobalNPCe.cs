using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Glorymod.NPCs;
using Glorymod.Projectiles;
namespace Glorymod
{
    
    public class GlobalNPCe : GlobalNPC
    {
        public static bool deadp;
        public override bool InstancePerEntity => true;
        int KStimer;
        int KStimer2;
        int KStimer3;
        int Ypos = -300;
        public override void NPCLoot(NPC npc)
        {
            
           if (Main.rand.Next(4) < 1) //33.3333...%
           {
                Item.NewItem(npc.getRect(), mod.ItemType("EssenceOfGlory")); //every enemy has a 1/3 chance to drop essence of glory
           }
           if (npc.type == 50)
           {
                Item.NewItem(npc.getRect(), mod.ItemType("NeonCanister"));
           }


        }
        public override void SetDefaults(NPC npc) //NEON TYRANT: REDUX OF KING SLIME
        {
            if (npc.type == 50) //King Slime
            {
                npc.GivenName = "Neon Tyrant";
                npc.damage = 100;
                npc.lifeMax = 3100;
            }
        }
        public override void AI(NPC npc) //NEON TYRANT: REDUX OF KING SLIME
        {
            if (npc.type == 50) //King Slime
            {
                if (Main.LocalPlayer.dead)
                {
                    npc.active = false;
                }
                Vector2 PlayerPosition = Main.player[npc.target].Center;
                KStimer++;
                if (KStimer > 350)
                {
                    NPC.NewNPC((int)PlayerPosition.X, (int)PlayerPosition.Y - 800, ModContent.NPCType<NeonSlime>());
                    KStimer = 0;
                }
                KStimer2++;
                if (KStimer2 > 1000)
                {

                    for (int i = 0; i < 14; i++)
                    {
                        Projectile.NewProjectile(PlayerPosition.X + 500, PlayerPosition.Y + Ypos, 0f, 0f, ModContent.ProjectileType<NeonVortex>(), 20, 5, Main.myPlayer);
                        Projectile.NewProjectile(PlayerPosition.X - 500, PlayerPosition.Y + Ypos, 0f, 0f, ModContent.ProjectileType<NeonVortex>(), 20, 5, Main.myPlayer);
                        Ypos += 50;
                    }
                    KStimer2 = 0;
                    Ypos = -300;
                }
                KStimer3++;
                
                if (KStimer3 == 610)
                {
                        Main.PlaySound(29, (int)npc.Center.X, (int)npc.Center.Y, 105);
                }
                if (KStimer3 > 680)
                {
                    
                    float adada = Main.rand.NextFloat(0, 5);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.NextFloat(12.5f) - Main.rand.NextFloat(12.5f), -25f, ModContent.ProjectileType<NeonBeam>(), 20, 5, Main.myPlayer);

                }
                if (KStimer3 > 730)
                {
                    KStimer3 = 0;
                }

            }

            if (npc.type == NPCID.BlueSlime)
            {
                if (NPC.AnyNPCs(NPCID.KingSlime))
                {
                    
                    npc.active = false;
                }
            }
            else if (npc.type == NPCID.SlimeSpiked)
            {
                if (NPC.AnyNPCs(NPCID.KingSlime))
                {
                    
                    npc.active = false;
                }
            }

        }
        
    }
}