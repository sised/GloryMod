using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Glorymod.NPCs;
using Glorymod.Projectiles;
using Glorymod.Buffs;
using System.Linq;
using Glorymod.Items.Weapons.Melee;
using Glorymod.Items.Accessories.Hm;
using System.Collections.Generic;
using Glorymod.Items.Materials;

namespace Glorymod
{
    
    public class GlobalNPCe : GlobalNPC
    {
        public float BlazingRadiusOffset = 10;
        public static bool deadp;
        public override bool InstancePerEntity => true;
        public float BlazingRadious = 1500;
        bool Enter = true;
        public bool DarkMatterEligible = true;
        public float PhaseChange;
        Vector2 Prediction;
        public bool LaserAttached = false;
        public bool FixerAttached = false;
        public float targetX = 0;
        public int PhaseChange2;
        public float targetY = 0;
        public int HP;
        public bool Phase2 = false;
        public int MinionIdentity;

        bool Exist = false;
        int Ypos = -300;
        public override void NPCLoot(NPC npc)
        {
            if(npc.CanBeChasedBy() && Main.rand.Next(3) == 2)
            {
                Item.NewItem(npc.Center, ModContent.ItemType<EssenceOfGlory>());
            }
            if(npc.type == NPCID.WallofFlesh)
            {
                if (Main.rand.Next(200) == 5)
                {
                    Item.NewItem(npc.Center, ModContent.ItemType<Gungnir>());
                }
                Item.NewItem(npc.Center, ModContent.ItemType<TrophyOfMenace>());
            }
            if(DarkMatterEligible)
            {
                if(npc.type == ModContent.NPCType<NeonTyrant>())
                {
                    Item.NewItem(npc.Center, ModContent.ItemType<DarkMatter>());
                }
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    Item.NewItem(npc.Center, ModContent.ItemType<DarkMatter>());
                }
                if (npc.type == ModContent.NPCType<Brain>() || npc.type == ModContent.NPCType<EoW>())
                {
                    Item.NewItem(npc.Center, ModContent.ItemType<DarkMatter>(), 2);
                }
                if (npc.type == NPCID.QueenBee)
                {
                    Item.NewItem(npc.Center, ModContent.ItemType<DarkMatter>(), 1);
                }
                if (npc.type == NPCID.SkeletronHead)
                {
                    Item.NewItem(npc.Center, ModContent.ItemType<DarkMatter>(), 2);
                }
                if (npc.type == NPCID.WallofFlesh)
                {
                    Item.NewItem(npc.Center, ModContent.ItemType<DarkMatter>(), 5);
                }
            }
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {

        }
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                Exist = false;
                NPC npc;
                if (!Exist)
                {
                    npc = Main.npc[i];
                }
                else break;
                if (npc.boss && npc.active)
                {
                    if (!Exist)
                    {
                        Exist = true;
                        Main.npc[i].GetGlobalNPC<GlobalNPCe>().LaserAttached = true;
                    }

                    break;
                }
                


            }
            if (Exist)
            {
                pool.Clear();
            }
        }
        public override void SetDefaults(NPC npc)
        {
            if(Mworld.Menace)
            {
                if(npc.type == NPCID.WallofFlesh)
                {
                    npc.HitSound = SoundID.NPCHit2;
                    npc.GivenName = "Basalt Barricade";
                    npc.lifeMax = 17000;
                    npc.defense = 15;
                }
            }
            
        }
        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            if(npc.active)
            {
                if (npc.type == 4)
                {
                    damage = 60;
                }
                if (npc.type == 34 || npc.type == 36)
                {
                    target.AddBuff(BuffID.OnFire, 200);
                }
            }
            
        }
        public override void AI(NPC npc)
        {

            
            if (npc.active)
            {
                if(npc.boss)
                {
                    for(int i = 0; i < Main.player.Count(); i++)
                    {
                        if(Main.player[i].statLife < Main.player[i].statLifeMax2)
                        {
                            DarkMatterEligible = false;
                        }
                    }
                }


                #region Special Effects
                // Voltaic canister debuff giver
                for (int i = 0; i < Main.maxPlayers; i++)
                {
                    float a = (npc.position - Main.player[npc.target].position).Length();
                    Player p = Main.player[i];
                    if (p.active && p.GetModPlayer<MPlayer>().isWearingVoltaicCanister && a < 600 && npc.CanBeChasedBy())
                    {
                        npc.AddBuff(ModContent.BuffType<Voltaic>(), 2, false);
                        break;
                    }
                }
                // Plasma canister debuff giver
                for (int i = 0; i < Main.maxPlayers; i++)
                {
                    Player p = Main.player[i];
                    if (p.active && p.GetModPlayer<MPlayer>().isWearingPlasmaCanister && npc.CanBeChasedBy())
                    {
                        npc.AddBuff(ModContent.BuffType<PlasmaVoltaic>(), 2, false);
                        break;
                    }
                }
                #endregion
                #region Main Changes menace mode
                if (Mworld.Menace)
                {
                    //neon tyrant spawn
                    if (npc.type == NPCID.KingSlime)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<NeonTyrant>());
                        npc.active = false;
                    }
                    //altintellect spawn
                    if (npc.type == NPCID.BrainofCthulhu)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Brain>());
                        npc.active = false;
                    }
                    //pellucid wolfer spawn
                    if (npc.type == NPCID.EaterofWorldsHead)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<EoW1>());
                        npc.active = false;
                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            if (Main.npc[i].type == NPCID.EaterofWorldsBody || Main.npc[i].type == NPCID.EaterofWorldsTail)
                            {
                                Main.npc[i].active = false;
                            }
                        }
                    }
                    //annihilator spawn
                    if (npc.type == NPCID.TheDestroyer)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Annih1>());
                        npc.active = false;
                    }
                    if (npc.type == NPCID.TheDestroyerBody)
                    {
                        npc.active = false;
                    }
                    if (npc.type == NPCID.TheDestroyerTail)
                    {
                        npc.active = false;
                    }
                    //creepers despawn when altintellect spawns
                    if (npc.type == NPCID.Creeper)
                    {
                        npc.active = false;
                    }
                    //boss despawns if all players are dead
                    if (npc.boss)
                    {
                        if (Main.player.Count(p => p.active && !p.dead) == 0)
                        {
                            npc.active = false;
                        }
                    }
                }
                #endregion
                #region Basalt Barricade
                // Mouth
                
                if (Mworld.Menace && npc.type == NPCID.WallofFlesh)
                {
                    npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -2f, +2f);
                    for (int i = 0; i < 360; i++)
                    {

                        Dust dust;

                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = npc.Center + new Vector2(BlazingRadious + BlazingRadiusOffset, 0).RotatedBy(MathHelper.ToDegrees(i));
                        int r = Main.rand.Next(3);
                        if (r == 2)
                        {
                            dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 6, 0, 0, 0, new Color(255, 255, 255), 1f)];
                            dust.noGravity = true;
                        }


                    }
                    if (!Phase2)
                    {
                        
                        PhaseChange++;
                        if (PhaseChange > 275 && Enter)
                        {
                            Enter = false;
                            PhaseChange = 0;
                            npc.defense = 15;
                        }
                        if (Enter)
                        {
                            npc.defense = 75;
                            BlazingRadious -= 5;
                        }

                        if (!Enter)
                        {
                            if (PhaseChange < 300)
                            {
                                BlazingRadious = 125;
                            }
                            if (PhaseChange > 300 && PhaseChange < 351)
                            {
                                BlazingRadious += 17.5f;
                            }
                            if (PhaseChange == 351)
                            {
                                Projectile.NewProjectile(npc.Center, npc.velocity, ModContent.ProjectileType<MoltenDeathray>(), 40, 1);

                            }
                            if (PhaseChange == 471)
                            {
                                for (int i = 0; i < 30; i++)
                                {
                                    if (npc.velocity.X > 0)
                                    {
                                        Projectile.NewProjectile(npc.Center.X + i * 75, npc.Center.Y, 0f, 4f, ModContent.ProjectileType<WoFshard>(), 30, 1);
                                        Projectile.NewProjectile(npc.Center.X + i * 75, npc.Center.Y, 0f, -4f, ModContent.ProjectileType<WoFshard>(), 30, 1);
                                    }
                                    if (npc.velocity.X < 0)
                                    {
                                        Projectile.NewProjectile(npc.Center.X - i * 75, npc.Center.Y, 0f, 4f, ModContent.ProjectileType<WoFshard>(), 30, 1);
                                        Projectile.NewProjectile(npc.Center.X - i * 75, npc.Center.Y, 0f, -4f, ModContent.ProjectileType<WoFshard>(), 30, 1);
                                    }
                                }
                            }
                            if (PhaseChange > 350 && PhaseChange < 700)
                            {
                                if (npc.velocity.X > 0)
                                {
                                    npc.rotation = npc.velocity.ToRotation();
                                }
                                else
                                {
                                    npc.rotation = npc.velocity.RotatedBy(MathHelper.PiOver2 * 2).ToRotation();
                                }
                            }
                            if (PhaseChange > 700 && PhaseChange < 751)
                            {
                                BlazingRadious += 10;
                            }
                            if (PhaseChange == 751)
                            {
                                Main.PlaySound(29, (int)npc.Center.X, (int)npc.Center.Y, 105);
                            }
                            if (PhaseChange == 800)
                            {
                                Main.PlaySound(15, (int)npc.Center.X, (int)npc.Center.Y, 0);
                                if (npc.velocity.X > 0)
                                {
                                    npc.velocity.X = 35;
                                }
                                if (npc.velocity.X < 0)
                                {
                                    npc.velocity.X = -35;
                                }
                            }
                            if (PhaseChange > 800 && PhaseChange < 900)
                            {
                                if (PhaseChange % 10 == 0 && npc.life < npc.lifeMax / 3 && npc.velocity.X > 0)
                                {
                                    Main.PlaySound(SoundID.Item33, (int)npc.Center.X, (int)npc.Center.Y);
                                    Vector2 a = new Vector2(0, 5).RotatedBy(MathHelper.ToRadians(PhaseChange - 900 * 2 + 130)) * 3;
                                    Projectile.NewProjectile(npc.Center, a, ModContent.ProjectileType<BasaltLaser>(), 30, 1);
                                }
                                if (PhaseChange % 10 == 0 && npc.life < npc.lifeMax / 3 && npc.velocity.X < 0)
                                {
                                    Main.PlaySound(SoundID.Item33, (int)npc.Center.X, (int)npc.Center.Y);
                                    Vector2 a = new Vector2(0, 5).RotatedBy(MathHelper.ToRadians(PhaseChange - 900 * 2 - 50)) * 3;
                                    Projectile.NewProjectile(npc.Center, a, ModContent.ProjectileType<BasaltLaser>(), 30, 1);
                                }
                                if (npc.velocity.X > 0)
                                {
                                    npc.velocity.X = 35 - ((PhaseChange - 800) * 0.33f);
                                }
                                if (npc.velocity.X < 0)
                                {
                                    npc.velocity.X = -35 + ((PhaseChange - 800) * 0.33f);
                                }
                            }
                            if (PhaseChange > 900 && PhaseChange < 951)
                            {
                                BlazingRadious -= 10;
                            }
                            if (PhaseChange == 951 || PhaseChange == 1000 || PhaseChange == 1050 || PhaseChange == 1100 || PhaseChange == 1150)
                            {

                                if (npc.velocity.X > 0)
                                {
                                    if (Main.player[npc.target].velocity.X > 0)
                                    {
                                        Prediction = (Main.player[npc.target].Center - npc.Center).RotatedBy(MathHelper.ToRadians(-Main.player[npc.target].velocity.X + Main.player[npc.target].velocity.Y));
                                    }
                                    if (Main.player[npc.target].velocity.X < 0)
                                    {
                                        Prediction = (Main.player[npc.target].Center - npc.Center).RotatedBy(MathHelper.ToRadians(-Main.player[npc.target].velocity.X * 3 + Main.player[npc.target].velocity.Y));
                                    }
                                }
                                if (npc.velocity.X < 0)
                                {
                                    if (Main.player[npc.target].velocity.X > 0)
                                    {
                                        Prediction = (Main.player[npc.target].Center - npc.Center).RotatedBy(MathHelper.ToRadians(-Main.player[npc.target].velocity.X * 3));
                                    }
                                    if (Main.player[npc.target].velocity.X < 0)
                                    {
                                        Prediction = (Main.player[npc.target].Center - npc.Center).RotatedBy(MathHelper.ToRadians(-Main.player[npc.target].velocity.X * 3));
                                    }
                                }
                                Projectile.NewProjectile(npc.Center, Prediction, ModContent.ProjectileType<LavaBlob>(), 30, 0);
                            }
                            if (PhaseChange > 1199)
                            {

                                BlazingRadious -= 8.5f;
                            }
                            if (PhaseChange == 1300)
                            {
                                PhaseChange = 0;
                            }
                        }
                        
                    }
                    else
                    {
                        PhaseChange++;
                        
                        if(PhaseChange > 400)
                        {
                            PhaseChange = 0;
                        }
                        if (!NPC.AnyNPCs(ModContent.NPCType<BasaltBarricade>()))
                        {
                            
                        }
                        if (Main.npc[MinionIdentity].life > Main.npc[MinionIdentity].lifeMax / 4f)
                        {
                            if (BlazingRadious < 1400)
                            {
                                BlazingRadious += 5;
                            }
                            if (BlazingRadious < 1500)
                            {
                                BlazingRadious++;
                            }
                            if (BlazingRadious > 1500)
                            {
                                BlazingRadious--;
                            }
                        }
                        if(Main.npc[MinionIdentity].life < Main.npc[MinionIdentity].lifeMax / 1.5f)
                        {
                            if (PhaseChange > 300 && PhaseChange < 400)
                            {
                                if (PhaseChange % 10 == 0 && npc.velocity.X < 0)
                                {
                                    Main.PlaySound(SoundID.Item33, (int)npc.Center.X, (int)npc.Center.Y);
                                    Vector2 a = new Vector2(0, 5).RotatedBy(MathHelper.ToRadians(PhaseChange - 900 * 2 + 130)) * 3;
                                    Projectile.NewProjectile(npc.Center, a, ModContent.ProjectileType<BasaltLaser>(), 30, 1);
                                }
                                if (PhaseChange % 10 == 0 && npc.velocity.X > 0)
                                {
                                    Main.PlaySound(SoundID.Item33, (int)npc.Center.X, (int)npc.Center.Y);
                                    Vector2 a = new Vector2(0, 5).RotatedBy(MathHelper.ToRadians(PhaseChange - 900 * 2 - 50)) * 3;
                                    Projectile.NewProjectile(npc.Center, a, ModContent.ProjectileType<BasaltLaser>(), 30, 1);
                                }
                            }
                        }
                        if (Main.npc[MinionIdentity].life < Main.npc[MinionIdentity].lifeMax / 4f)
                        {
                            if(BlazingRadious > 0)
                            {
                                BlazingRadious -= 0.8f;
                            }
                        }
                        if (Main.npc[MinionIdentity].active == false)
                        {
                            npc.StrikeNPC(69420, 0, 0);
                        }
                    }
                }
                // Wall of Flesh stuff despawns
                BasaltBarricadeUnneededNPCDespawn(npc);
                // Hungry Despawn
                if(Mworld.Menace && npc.type == NPCID.TheHungry) { npc.active = false; }

                
                if (npc.type == ModContent.NPCType<EoW>())
                {
                }
                #endregion
            }
        }
        public void BasaltBarricadeUnneededNPCDespawn(NPC npc)
        {
            if (Mworld.Menace && (npc.type == NPCID.WallofFleshEye || npc.type == NPCID.TheHungry || npc.type == NPCID.LeechBody || npc.type == NPCID.LeechTail || npc.type == NPCID.LeechHead)) { npc.active = false; }
        }
        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
            if(npc.active)
            {
                if (npc.type == 114 && npc.life <= 0)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<WoFeye1>());
                }
            }
            
        }
        public override bool CheckDead(NPC npc)
        {
            if(npc.type == NPCID.WallofFlesh && !Phase2)
            {
                MinionIdentity = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<BasaltBarricade>());
                Phase2 = true;
                PhaseChange = 0;
                npc.alpha = 255;
                npc.damage = 0;
                npc.dontTakeDamage = true;
                npc.life = 100;
                return false;
            }
            else return true;
        }
        

    }


    
    public class BasaltLaser : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 14;
            projectile.height = 14;
            projectile.tileCollide = false;
            projectile.timeLeft = 700;

        }
        public override void AI()
        {
            Vector2 position = projectile.oldPosition;
            projectile.rotation = projectile.velocity.ToRotation();
        }
    }
}