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
using Glorymod.Items.Weapons.Mage;

namespace Glorymod.NPCs
{
    [AutoloadBossHead]
    public class Brain : ModNPC
    {
        int b;
        public override string HeadTexture => "Glorymod/NPCs/Brain_Head_Boss";
        bool patternReset = false;
        int exhaustTimer;
        int teleportTimer;
        bool spawned = false;
        bool phase2 = false;
        int timer2;
        bool AssaultMode = false;
        public override void NPCLoot()
        {
            Item.NewItem(npc.Center, ItemID.BrainOfCthulhuBossBag);
            Item.NewItem(npc.Center, ItemID.TigerClimbingGear);
            Item.NewItem(npc.Center, ModContent.ItemType<AtomicPointer>());
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Altintellect");
            Main.npcFrameCount[npc.type] = 8;
        }
        public override int SpawnNPC(int tileX, int tileY)
        {

            return base.SpawnNPC(tileX, tileY);
        }
        public override bool CheckActive()
        {
            return false;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 1400;
            npc.defense = 15;
            npc.width = 114;
            npc.height = 146;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.aiStyle = -1;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.value = 35000;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.dontTakeDamage = true;
        }
        public override void FindFrame(int frameHeight)
        {
            if(!phase2)
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
            if(phase2)
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
        public override bool CheckDead()
        {
            Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<Explosion>(), 0, 2);
            for (int i = 0; i < 2; i++)
            {
                Vector2 a2 = new Vector2(npc.Center.X + Main.rand.Next(60) - Main.rand.Next(60), npc.Center.Y + Main.rand.Next(20) - Main.rand.Next(20));
                Vector2 b2 = new Vector2(Main.rand.Next(7), Main.rand.Next(7));
                Gore.NewGoreDirect(a2, b2, mod.GetGoreSlot("Gores/BoCgore1"), 1f);
            }

            Vector2 a = new Vector2(npc.Center.X + Main.rand.Next(60) - Main.rand.Next(60), npc.Center.Y + Main.rand.Next(20) - Main.rand.Next(20));
            Vector2 b = new Vector2(Main.rand.Next(7), Main.rand.Next(7));
            Gore.NewGoreDirect(a, b, mod.GetGoreSlot("Gores/BoCgore2"), 1f);
            return true;
        }
        public override void AI()
        {
            
            npc.TargetClosest();
            exhaustTimer++;
            if(exhaustTimer > 40)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 80, 0f, 15f, ModContent.ProjectileType<IonExhaust>(), 20, 1);
                exhaustTimer = 0;
            }
            if (Main.player.Count(p => p.active && !p.dead) == 0)
            {
                npc.active = false;
            }
            if (phase2)
            {
                npc.dontTakeDamage = false;
                if(!AssaultMode)
                {
                    AssaultMode = true;
                    Main.NewText("All creeper units have been eliminated, Entering assault mode", 99, 80, 117);
                }
            }
            teleportTimer++;
            
            if (!spawned)
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SuperCreeper>());
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SuperCreeper2>());
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SuperCreeper3>());
                spawned = true;
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<SuperCreeper>()) && !NPC.AnyNPCs(ModContent.NPCType<SuperCreeper2>()) && !NPC.AnyNPCs(ModContent.NPCType<SuperCreeper3>()))
            {

                phase2 = true;
                if(!patternReset)
                {
                    teleportTimer = 0;
                    patternReset = true;
                }
            }
            Player player = Main.player[npc.target];
           
            Vector2 between = player.Center - npc.Center;
            between.Normalize();
            between = between * 1.1f;

            npc.velocity = between;
            
            if(teleportTimer == 300 || teleportTimer == 330 || teleportTimer == 360 || teleportTimer == 900 || teleportTimer == 1100 || teleportTimer == 1110 || teleportTimer == 1120)
            {
                Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<PhantomIntellect>(), 0, 0);
                int r = Main.rand.Next(4);
                switch(r)
                {
                    case 0: npc.position.X = player.position.X + 500 + Main.rand.Next(200) - Main.rand.Next(200); npc.position.Y = player.position.Y + 500 + Main.rand.Next(200) - Main.rand.Next(200); break;
                    case 1: npc.position.X = player.position.X + 500 + Main.rand.Next(200) - Main.rand.Next(200); npc.position.Y = player.position.Y - 500 + Main.rand.Next(200) - Main.rand.Next(200); break;
                    case 3: npc.position.X = player.position.X - 500 + Main.rand.Next(200) - Main.rand.Next(200); npc.position.Y = player.position.Y + 500 + Main.rand.Next(200) - Main.rand.Next(200); break;
                    case 4: npc.position.X = player.position.X - 500 + Main.rand.Next(200) - Main.rand.Next(200); npc.position.Y = player.position.Y - 500 + Main.rand.Next(200) - Main.rand.Next(200); break;
                }
                if (teleportTimer == 300 || teleportTimer == 330 || teleportTimer == 1100 || teleportTimer == 1110 || teleportTimer == 600 || teleportTimer == 900)
                {
                    Main.PlaySound(SoundID.Item14, (int)npc.Center.X, (int)npc.Center.Y);
                }
                else if(!phase2)
                {
                    if(teleportTimer == 360 || teleportTimer == 1120)
                    {
                        Main.PlaySound(SoundID.Item14, (int)npc.Center.X, (int)npc.Center.Y);
                    }
                }
            }
            if(teleportTimer == 600)
            {
                Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<PhantomIntellect>(), 0, 0);
                int r = Main.rand.Next(4);
                switch (r)
                {
                    case 0: npc.position.X = player.position.X + 700 + Main.rand.Next(200) - Main.rand.Next(200); npc.position.Y = player.position.Y + 700 + Main.rand.Next(200) - Main.rand.Next(200); break;
                    case 1: npc.position.X = player.position.X + 700 + Main.rand.Next(200) - Main.rand.Next(200); npc.position.Y = player.position.Y - 700 + Main.rand.Next(200) - Main.rand.Next(200); break;
                    case 3: npc.position.X = player.position.X - 700 + Main.rand.Next(200) - Main.rand.Next(200); npc.position.Y = player.position.Y + 700 + Main.rand.Next(200) - Main.rand.Next(200); break;
                    case 4: npc.position.X = player.position.X - 700 + Main.rand.Next(200) - Main.rand.Next(200); npc.position.Y = player.position.Y - 700 + Main.rand.Next(200) - Main.rand.Next(200); break;
                }
                Main.PlaySound(SoundID.Item14, (int)npc.Center.X, (int)npc.Center.Y);
            }
            //ROCKET BARRAGE
            if(teleportTimer == 360 && phase2 || teleportTimer == 1120 && phase2)
            {
                Main.PlaySound(SoundID.NPCKilled, -1, -1, mod.GetSoundSlot(SoundType.NPCKilled, "Sounds/NPCKilled/755__elmomo__missile01"));
                for (int i = 0; i < 25; i++)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Missile>());
                }
            }
            //LASER CYCLONE VORTEX
            if(teleportTimer > 600 && teleportTimer < 800 && phase2)
            {
                Vector2 pp = new Vector2(0, 4).RotatedBy((teleportTimer) * 3.6f * 2);
                Projectile.NewProjectile(npc.Center, pp, ProjectileID.DeathLaser, 20, 1);
            }
            if(teleportTimer > 1120)
            {
                teleportTimer = 0;
            }
            //PLASMA WAVE
            if(teleportTimer == 400 || teleportTimer == 900)
            {
                
                if(!NPC.AnyNPCs(ModContent.NPCType<SuperCreeper2>()))
                {
                    for (int i = 0; i < 15; i++)
                    {
                        Vector2 pp = new Vector2(0, 4).RotatedBy(i * 24);
                        Projectile.NewProjectile(npc.Center, pp, ModContent.ProjectileType<CreeperProj>(), 20, 1);
                        Main.PlaySound(SoundID.Item33, (int)npc.Center.X, (int)npc.Center.Y);
                    }
                }
                
                
            }
        }
    }
}
