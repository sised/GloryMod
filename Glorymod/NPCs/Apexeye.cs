using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Glorymod.NPCs;
using Glorymod.Projectiles;
using System;
using Glorymod.Buffs;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using IL.Terraria.DataStructures;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader.IO;
using Glorymod;

namespace Glorymod.NPCs
{
    public class Apexeye : ModNPC
    {
        bool oneframe = false;
        int BoCframe;
        int BoCframeD;
        int SS;
        int phase = 2;
        int timer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Sightseer");
            Main.npcFrameCount[npc.type] = 6;
        }
        public override void SetDefaults()
        {
            animationType = NPCID.EyeofCthulhu;
            base.SetDefaults();
            npc.damage = 69420; 
            npc.lifeMax = 3000; 
            npc.aiStyle = -1;
            npc.defense = 69420;
            npc.boss = true;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.width = 90;
            npc.height = 90;
            npc.scale = 1.5f;
            npc.knockBackResist = 0f;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[BuffID.Daybreak] = true;
        }
        public override bool CheckDead()
        {
            
            for (int i = 0; i < 8; i++)
            {
                Vector2 a = new Vector2(npc.Center.X + Main.rand.Next(60) - Main.rand.Next(60), npc.Center.Y + Main.rand.Next(20) - Main.rand.Next(20));
                Vector2 b = new Vector2(Main.rand.Next(7), Main.rand.Next(7));
                switch (i)
                {
                    case 0:
                        Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/apgore1"), 1f);
                        break;

                    case 1:
                        Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/apgore2"), 1f);
                        break;

                    case 2:
                        Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/apgore3"), 1f);
                        break;

                    case 3:
                        Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/apgore4"), 1f);
                        break;

                    case 4:
                        Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/apgore5"), 1f);
                        break;

                    case 5:
                        Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/apgore5"), 1f);
                        break;

                    case 6:
                        Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/apgore1"), 1f);
                        break;

                    case 7:
                        Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/apgore2"), 1f);
                        break;
                }

            }
            return true;
        }
        public override void AI()
        {

            if (npc.life < npc.lifeMax * 0.5)
            {
                SS++;
                if (SS > 500)
                {
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.EyeofCthulhu);
                    SS = 0;
                }
            }
            if(npc.life < npc.lifeMax * 0.25)
            {
                SS++;
            }
            if (Main.player.Count(p => p.active && !p.dead) == 0)
            {
                npc.active = false;
            }
            Player player = Main.player[npc.target];
            npc.TargetClosest(true);
            float distance = Main.player[npc.target].Distance(npc.Center);
            if(distance > 1500 && npc.life < npc.lifeMax)
            {
                npc.life++;
            }
            timer++;
            if(phase == 1)
            {

                npc.velocity = npc.velocity *= 0.98f;
                if(timer == 100 || timer == 200 || timer == 300 || timer == 400)
                {
                    for (int i = 0; i < 18; i++)
                    {
                        Vector2 noscope2 = new Vector2(-8, 0).RotatedBy(npc.rotation + MathHelper.ToRadians(i * 20 - 40));
                        noscope2.Normalize();
                        noscope2 *= 15f; // velocity
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, noscope2.X, noscope2.Y, ModContent.ProjectileType<Eyep>(), 69420, 5, Main.myPlayer);
                        noscope2 = Main.player[npc.target].Center - npc.Center;
                    }
                    
                    Main.PlaySound(SoundID.Item33, (int)npc.Center.X, (int)npc.Center.Y);
                    Vector2 noscope = Main.player[npc.target].Center - npc.Center;
                    noscope.Normalize();
                    noscope *= 40f; // velocity
                    npc.velocity = noscope;
                    Main.PlaySound(15, (int)npc.Center.X, (int)npc.Center.Y, 0);
                    
                }
                if(timer == 500)
                {
                    phase = 2;
                    timer = 0;
                }
                
            }
            if (phase == 2)
            {
                float speed = 15f;
                float inertia = 80f;
                Vector2 direction = player.Center - npc.Center;
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                if(timer == 100 || timer == 200 || timer == 300 || timer == 400)
                {

                    for (int i = 0; i < 6; i++)
                    {
                        Vector2 noscope = Main.player[npc.target].Center - npc.Center;
                        noscope.Normalize();
                        noscope *= 17f + Main.rand.Next(40) * 0.1f; // velocity
                        noscope = noscope.RotatedByRandom(MathHelper.ToRadians(15));
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, noscope.X, noscope.Y, ModContent.ProjectileType<SightLaser>(), 69420, 5, Main.myPlayer);
                        noscope = Main.player[npc.target].Center - npc.Center;
                    }
                }
                if(timer == 500)
                {
                    phase = 3;
                    timer = 0;
                }
            }
            if (phase == 3)
            {
                npc.velocity = Vector2.Zero;
                if(timer == 1)
                {
                    Vector2 noscope = Main.player[npc.target].Center - npc.Center;
                    noscope.Normalize();
                    noscope *= 4f;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, noscope.X, noscope.Y, ModContent.ProjectileType<SuperOrb>(), 69420, 5, Main.myPlayer);
                    noscope = Main.player[npc.target].Center - npc.Center;
                }
                if(timer == 25)
                {
                    Vector2 noscope = Main.player[npc.target].Center - npc.Center;
                    noscope.Normalize();
                    noscope *= 4f;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, noscope.X, noscope.Y, ModContent.ProjectileType<SuperOrb>(), 69420, 5, Main.myPlayer);
                    noscope = Main.player[npc.target].Center - npc.Center;
                }
                if (timer == 50)
                {
                    Vector2 noscope = Main.player[npc.target].Center - npc.Center;
                    noscope.Normalize();
                    noscope *= 4f;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, noscope.X, noscope.Y, ModContent.ProjectileType<SuperOrb>(), 69420, 5, Main.myPlayer);
                    noscope = Main.player[npc.target].Center - npc.Center;
                }
                if (timer == 100)
                {
                    phase = 1;
                    timer = 0;
                }
            }
            Vector2 between = Main.player[npc.target].Center - npc.Center; //the direction between the player and the npc
            npc.rotation = between.ToRotation() - MathHelper.PiOver2;
            if (!oneframe)
            {
                Main.PlaySound(15, (int)npc.Center.X, (int)npc.Center.Y, 0);
            }
            oneframe = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            bossLifeScale = 1;
            npc.lifeMax = 3000;
        }
    }
}
