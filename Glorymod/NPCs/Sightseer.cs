using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Glorymod.Projectiles;
using Glorymod.Items.Weapons.Melee;
using System;

namespace Glorymod.NPCs
{
    [AutoloadBossHead]
    public class Sightseer : ModNPC
    {
        int Ltimer;
        public override void NPCLoot()
        {
            Item.NewItem(npc.Center, ItemID.EyeOfCthulhuBossBag);
            Item.NewItem(npc.Center, ItemID.TigerClimbingGear);
            Item.NewItem(npc.Center, ModContent.ItemType<TheOverwatch>());
        }
        public override bool CheckDead()
        {
            NPC.downedBoss1 = true;
            for (int i = 0; i < 12; i++)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, 43, 0f, 0f, 0, new Color(255, 255, 255), 5f)];
            }
            for (int i = 0; i < 5; i++)
            {
                
                if (i == 0)
                {
                    Gore.NewGoreDirect(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SSgore2"), 1f);
                }
                if (i == 1)
                {
                    Gore.NewGoreDirect(new Vector2(npc.Center.X + Main.rand.Next(10), npc.Center.Y + Main.rand.Next(10)), new Vector2(npc.velocity.X + Main.rand.Next(10), npc.velocity.Y + Main.rand.Next(10)), mod.GetGoreSlot("Gores/SSgore1"), 1f);
                }

                if (i == 2)
                {
                    Gore.NewGoreDirect(new Vector2(npc.Center.X + Main.rand.Next(10), npc.Center.Y + Main.rand.Next(10)), new Vector2(npc.velocity.X + Main.rand.Next(10), npc.velocity.Y + Main.rand.Next(10)), mod.GetGoreSlot("Gores/SSgore1"), 1f);
                }
                if (i == 3)
                {
                    Gore.NewGoreDirect(new Vector2(npc.Center.X + Main.rand.Next(10), npc.Center.Y + Main.rand.Next(10)), new Vector2(npc.velocity.X + Main.rand.Next(10), npc.velocity.Y + Main.rand.Next(10)), mod.GetGoreSlot("Gores/SSgore1"), 1f);
                }

                if (i == 4)
                {
                    Gore.NewGoreDirect(new Vector2(npc.Center.X + Main.rand.Next(10), npc.Center.Y + Main.rand.Next(10)), new Vector2(npc.velocity.X + Main.rand.Next(10), npc.velocity.Y + Main.rand.Next(10)), mod.GetGoreSlot("Gores/SSgore1"), 1f);
                }
            }

            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sightseer Juvenile");
            Main.npcFrameCount[npc.type] = 8;
        }
        bool Phase2 = false;
        int PhaseChangeTimer;
        int timer2;
        public override void SetDefaults()
        {
            npc.width = 65;
            npc.height = 65;
            npc.defense = 10;
            npc.damage = 40;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.aiStyle = -1;
            npc.alpha = 0;
            npc.boss = true;
            npc.lifeMax = 2000;
            npc.knockBackResist = 0;
            npc.value = 25000;
        }
        public override void FindFrame(int frameHeight)
        {
            if (!Phase2)
            {
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
                    timer2 = 0;

                }
            }
            timer2++;
            if (Phase2)
            {
                if (timer2 > 8)
                {
                    npc.frame.Y = frameHeight * 4;
                }
                if (timer2 > 16)
                {
                    npc.frame.Y = frameHeight * 5;

                }
                if (timer2 > 22)
                {
                    npc.frame.Y = frameHeight * 6;

                }
                if (timer2 > 28)
                {
                    npc.frame.Y = frameHeight * 7;
                    timer2 = 0;

                }
            }
        }
        public void Phase2A()
        {
            float dashSpeed = 50;
            Player player = Main.player[npc.target];
            Vector2 between = player.Center - npc.Center;

            PhaseChangeTimer++;
                if (PhaseChangeTimer < 200 && PhaseChangeTimer > 0)
                {
                    Ltimer++;
                    if (Ltimer > 200)
                    {
                        Vector2 betweenN = between;
                        betweenN.Normalize();
                        betweenN *= 0.5f;
                        Projectile.NewProjectile(npc.Center, Vector2.Zero, ProjectileID.CultistBossLightningOrb, 15, 1);
                        Ltimer = 0;
                    }
                    npc.velocity *= 0.95f;
                    npc.TargetClosest();
                    float speed = 10;
                    float inertia = 60f;
                    Vector2 direction = Vector2.Normalize(player.Center - npc.Center) * speed;
                    npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                    npc.rotation = between.RotatedBy(MathHelper.ToDegrees(-90)).ToRotation();
                }
                npc.velocity *= 0.95f;
                npc.rotation = between.RotatedBy(MathHelper.ToDegrees(-90)).ToRotation();
                if (PhaseChangeTimer == 300 || PhaseChangeTimer == 400)
                {
                Vector2 noscope = npc.DirectionTo(player.Center);

                noscope.Normalize();
                noscope *= dashSpeed;
                npc.velocity = noscope;
                Main.PlaySound(SoundID.Roar, (int)npc.Center.X, (int)npc.Center.Y, 0);
            }
            if (PhaseChangeTimer > 402)
                {
                    Main.PlaySound(SoundID.Item33, (int)npc.Center.X, (int)npc.Center.Y);
                    for (int i = 0; i < 10; i++)
                    {
                        Vector2 p360 = new Vector2(0, 10).RotatedBy(MathHelper.ToDegrees(i * 36));
                        Projectile.NewProjectile(npc.Center, p360, ModContent.ProjectileType<SightLaser>(), 15, 1);
                    }
                    PhaseChangeTimer = 0;
                }
            
        }
        public void Phase1A()
        {
            float dashSpeed = 50;
            Player player = Main.player[npc.target];
            Vector2 between = player.Center - npc.Center;
            

                PhaseChangeTimer++;
                if (PhaseChangeTimer < 200 && PhaseChangeTimer > 0)
                {
                    Ltimer++;
                    if (Ltimer > 200)
                    {
                        Projectile.NewProjectile(npc.Center, Vector2.Zero, ProjectileID.CultistBossLightningOrb, 20, 1);
                        Ltimer = 0;
                    }
                    npc.velocity *= 0.95f;
                    npc.TargetClosest();
                    float speed = 10;
                    float inertia = 60f;
                    Vector2 direction = Vector2.Normalize(player.Center - npc.Center) * speed;
                    npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                    npc.rotation = between.RotatedBy(MathHelper.ToDegrees(-90)).ToRotation();
                }
                if (PhaseChangeTimer > 199 && PhaseChangeTimer < 401)
                {

                    npc.velocity *= 0.95f;
                    npc.rotation = between.RotatedBy(MathHelper.ToDegrees(-90)).ToRotation();
                    if (PhaseChangeTimer == 300 || PhaseChangeTimer == 400)
                    {
                        Vector2 noscope = npc.DirectionTo(player.Center);

                        noscope.Normalize();
                        noscope *= dashSpeed;
                        npc.velocity = noscope;
                        Main.PlaySound(SoundID.Roar, (int)npc.Center.X, (int)npc.Center.Y, 0);
                    }
                }
                if (PhaseChangeTimer > 402)
                {
                    PhaseChangeTimer = 0;
                }
            
        }
        public override void AI()
        {

            
            npc.TargetClosest();
            
            Player player = Main.player[npc.target];
            Vector2 between = player.Center - npc.Center;
            
            if (npc.life < npc.lifeMax / 1.5f)
            {
                Phase2 = true;
            }
            if (!Phase2)
            {
                Phase1A();
            }
            else Phase2A();
        }
    }
}
