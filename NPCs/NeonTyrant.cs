using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Threading;
using Glorymod.Projectiles;
using System.Dynamic;
using Glorymod.Items.Materials;
using System.Linq;
using Glorymod.Items.Accessories.PreHm;
using System.Data.SqlTypes;

namespace Glorymod.NPCs
{
    [AutoloadBossHead]
    public class NeonTyrant : ModNPC
    {
        int ypos = -600;
        public override void NPCLoot()
        {
            Item.NewItem(npc.Center, ItemID.KingSlimeBossBag);
            Item.NewItem(npc.Center, ItemID.TigerClimbingGear);
            Item.NewItem(npc.Center, ModContent.ItemType<NeonCanister>());
        }
        public override string HeadTexture => "Eathermod/NPCs/NeonTyrant_Head_Boss";
        bool alreadyExploded = false;
        int SubphaseChangeTimer;
        int timer2;
        bool dead = false;
        int subphase = 1;
        int timer3;
        bool shot;
        bool AIdead = false;
        int timerAbove;
        bool P2begin = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Tyrant");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 1500;
            npc.damage = 40;
            npc.defense = 15;
            npc.width = 168;
            npc.height = 112;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.aiStyle = -1;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.value = 25000;
        }
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
            player.AddBuff(BuffID.WitheredWeapon, 300, true);
            player.AddBuff(BuffID.WitheredArmor, 300, true);
        }
        
        public override void FindFrame(int frameHeight)
        {
            if(timer2 > 28)
            {
                timer2 = 0; //it will reset regardless if the npc is on the ground or not
            }
            if(npc.velocity.Y == 0) //if its 0 that means its not airborne
            {
                timer2++;
                if (timer2 > 8)
                {
                    npc.frame.Y = 0;
                }
                if (timer2 > 16)
                {
                    npc.frame.Y = frameHeight * 1;
                    
                }
                if (timer2 > 22)
                {
                    npc.frame.Y = frameHeight * 2;
                    
                }
                if (timer2 > 28)
                {
                    npc.frame.Y = frameHeight * 3;
                    
                }
            }
            else
            {
                npc.frame.Y = frameHeight * 3;
            }
            
        }
        
        public override void AI()
        {
            if(dead)
            {
                npc.velocity = Vector2.Zero;
                npc.life = 10000;
                npc.dontTakeDamage = true;
                npc.scale -= 0.005f;
                if(npc.scale < 0.5f)
                {
                    AIdead = true;
                    npc.dontTakeDamage = true;
                    npc.life = 0;
                    npc.checkDead();
                }
            }
            if(!dead)
            {
                npc.scale = 0.8f + (1 - npc.life * 0.0003f);
                if (Main.player.Count(p => p.active && !p.dead) == 0)
                {
                    npc.active = false;
                }
                Player player = Main.player[npc.target];
                SubphaseChangeTimer++;
                npc.TargetClosest();
                Vector2 between = npc.Center - Main.player[npc.target].Center;
                between.Normalize();
                if (npc.velocity.Y == 0)
                {
                    npc.velocity.X = 0f;
                }
                if (subphase == 1)
                {
                    if (SubphaseChangeTimer > 600)
                    {
                        subphase = 2;
                        timer3 = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            NPC.NewNPC((int)npc.Center.X + Main.rand.Next(160), (int)npc.Center.Y + Main.rand.Next(160), ModContent.NPCType<NeonSlime>());
                        }

                    }
                    timer3++;
                    if (timer3 > 120 && npc.velocity.Y == 0)
                    {
                        if (npc.Center.X > Main.player[npc.target].Center.X)
                        {
                            npc.velocity.X = -6;
                        }
                        if (npc.Center.X < Main.player[npc.target].Center.X)
                        {
                            npc.velocity.X = +6;
                        }
                        npc.velocity.Y = -15;
                        timer3 = 0;
                    }
                }
                if (Mworld.Menace == false)
                {
                    npc.active = false;
                    Main.NewText("This ain't menace mode, neon tyrant is outta here.", 0, 221, 114);
                }
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

                if (subphase == 2)
                {
                    if (P2begin)
                    {
                        timer3++;
                        if (timer3 > 115 && timer3 < 130)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                float adada = Main.rand.NextFloat(0, 5);
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.NextFloat(12.5f) - Main.rand.NextFloat(12.5f), -25f, ModContent.ProjectileType<NeonBeam>(), 20, 5, Main.myPlayer);
                            }
                            if (npc.life < npc.lifeMax / 2)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    float adada = Main.rand.NextFloat(0, 5);
                                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.NextFloat(12.5f) - Main.rand.NextFloat(12.5f), -25f, ModContent.ProjectileType<NeonBeam>(), 20, 5, Main.myPlayer);
                                }
                            }
                        }
                    }

                    if (npc.velocity.Y == 0 && !P2begin)
                    {
                        timer3++;
                        if (timer3 == 100)
                        {
                            npc.velocity.Y = -15;
                            Main.PlaySound(29, (int)npc.Center.X, (int)npc.Center.Y, 105);
                            P2begin = true;
                        }

                    }
                    if (timer3 > 210)
                    {
                        int rand = Main.rand.Next(10);
                        switch (rand) //jokes
                        {
                            case 1: Main.NewText("Show U236 some support, he has been very unstable as of late", 255, 191, 55); break;
                            case 2: Main.NewText("No doc i'm telling you it's not a cough, i googled it!", 255, 191, 55); break;
                            case 3: Main.NewText("Fusion ain't 30 years away, i'm pretty sure it's 8 minutes and 20 seconds", 255, 191, 55); break;
                            case 4: Main.NewText("I wish i was made of Radon instead, i could lose half of my weight in 3.8 days!", 255, 191, 55); break;
                            case 5: Main.NewText("No grandpa, you don't have to close the router before going to sleep", 255, 191, 55); break;
                            case 6: Main.NewText("Atoms when they lose an electron: i'm positive i lost an electron", 255, 191, 55); break;
                            case 7: Main.NewText("Fahrenheit is so dumb that you even have to copy paste it's name from google", 255, 191, 55); break;
                            case 8: Main.NewText("I lost my shoe, i have to buy a Neo one", 255, 191, 55); break;
                            case 9: Main.NewText("Wait, what do you mean Mendeleev wasn't a precognitor?", 255, 191, 55); break;
                        }
                        for (int i = 0; i < 28; i++)
                        {

                            Projectile.NewProjectile(player.Center.X + 500, player.Center.Y + ypos, 0f, 0f, ModContent.ProjectileType<NeonVortex>(), 20, 5, Main.myPlayer);
                            Projectile.NewProjectile(player.Center.X - 500, player.Center.Y + ypos, 0f, 0f, ModContent.ProjectileType<NeonVortex>(), 20, 5, Main.myPlayer);
                            ypos += 50;
                        }
                        ypos = -600;
                        subphase = 3;
                        timer3 = 0;
                        SubphaseChangeTimer = 0;
                        P2begin = false;
                    }
                }
                if (subphase == 3)
                {
                    timer3++;
                    if (timer3 > 120 && npc.velocity.Y == 0)
                    {
                        if (npc.Center.X > Main.player[npc.target].Center.X)
                        {
                            npc.velocity.X = -6;
                        }
                        if (npc.Center.X < Main.player[npc.target].Center.X)
                        {
                            npc.velocity.X = +6;
                        }
                        npc.velocity.Y = -15;
                        timer3 = 0;
                    }
                    if (SubphaseChangeTimer > 600)
                    {
                        subphase = 4;
                        timer3 = 0;
                    }
                }
                if (subphase == 4)
                {

                    if (!alreadyExploded)
                    {
                        npc.noTileCollide = true;
                        npc.position.Y = Main.player[npc.target].Center.Y - 600f;
                        npc.position.X = Main.player[npc.target].Center.X - npc.width * 0.5f;
                        npc.velocity.X = 0;
                        for (int z = 0; z < 30; z++)
                        {
                            Dust dust;
                            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                            Vector2 position = npc.position;
                            dust = Main.dust[Terraria.Dust.NewDust(position, npc.width, npc.height, 43, 0f, 0f, 0, new Color(255, 255, 255), 5f)];
                        }
                        shot = true;
                        alreadyExploded = true;
                        Main.PlaySound(SoundID.Item14);
                    }
                    if (timer3 < 30)
                    {
                        npc.velocity.Y = 0;
                    }
                    if (timer3 > 30 && npc.velocity.Y == 0 && shot)
                    {
                        if (npc.life < 2250)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                Projectile.NewProjectile(npc.Center.X + npc.width / 2, npc.Center.Y + npc.height / 2 - i * npc.height * 0.25f, 8, (i - 2) * 1.3f, ModContent.ProjectileType<NeonSword>(), 20, 1);
                                Projectile.NewProjectile(npc.Center.X - npc.width / 2, npc.Center.Y + npc.height / 2 - i * npc.height * 0.25f, -8, (i - 2) * 1.3f, ModContent.ProjectileType<NeonSword>(), 20, 1);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                Projectile.NewProjectile(npc.Center.X + npc.width / 2, npc.Center.Y + npc.height / 2 - i * npc.height * 0.25f, 6, 0, ModContent.ProjectileType<NeonSword>(), 20, 1);
                                Projectile.NewProjectile(npc.Center.X - npc.width / 2, npc.Center.Y + npc.height / 2 - i * npc.height * 0.25f, -6, 0, ModContent.ProjectileType<NeonSword>(), 20, 1);
                            }
                        }
                        shot = false;

                    }
                    timer3++;
                    if (timer3 > 200)
                    {
                        alreadyExploded = false;
                        timer3 = 0;
                        SubphaseChangeTimer = 0;
                        subphase = 1;
                        int rand = Main.rand.Next(10);
                        switch (rand) //more jokes
                        {
                            case 1: Main.NewText("When i was little i ate some battery now i'm like this pls help me", 255, 191, 55); break;
                            case 2: Main.NewText("FeMales, ironman?", 255, 191, 55); break;
                            case 3: Main.NewText("Electrons be like: Hey the physicist is coming! act cool!", 255, 191, 55); break;
                            case 4: Main.NewText("I think these jokes are sodium funny. In fact, I slapped my neon that one!", 255, 191, 55); break;
                            case 5: Main.NewText("Want to hear a joke about nitrogen oxide? NO!", 255, 191, 55); break;
                            case 6: Main.NewText("What happens when you lower your body temperature to -273°C?  Nothing, you're perfectly 0K!", 255, 191, 55); break;
                            case 7: Main.NewText("Did you know that fahrenheit, celsius and kelvin are not the only temperature units?", 255, 191, 55); break;
                            case 8: Main.NewText("Gold is Ausome, wouldn't you agree?", 255, 191, 55); break;
                            case 9: Main.NewText("Wait, what do you mean silver's symbol ain't Si? No, not argentum, i said silver", 255, 191, 55); break;
                        }
                    }
                }
            }
            
        }
        public override bool CheckDead()
        {
            if (dead && AIdead)
            {
                NPC.downedSlimeKing = true;
                for (int i = 0; i < 12; i++)
                {
                    Dust dust;
                    dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, 43, 0f, 0f, 0, new Color(255, 255, 255), 5f)];
                }
                for (int i = 0; i < 3; i++)
                {
                    Vector2 a = new Vector2(npc.Center.X + Main.rand.Next(20) - Main.rand.Next(20), npc.Center.Y + Main.rand.Next(20) - Main.rand.Next(20));
                    Vector2 b = new Vector2(Main.rand.Next(3), Main.rand.Next(3));
                    if (i == 0)
                    {
                        Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/NeonGore"), 1f);
                    }
                    if (i == 1)
                    {
                        Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/NeonGore"), 1f);
                    }
                    if (i == 2)
                    {
                        Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/NeonGore"), 1f);
                    }
                    NPC.NewNPC((int)a.X, (int)a.Y, ModContent.NPCType<NeonSlime>());
                }
                return true;
            }
            else
            {
                npc.life = 10000;
                npc.dontTakeDamage = true;
                npc.active = true;
                dead = true;
                return false;
            }
        }
    }
}
