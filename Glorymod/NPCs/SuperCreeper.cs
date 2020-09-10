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
using System.Runtime.Remoting.Messaging;
using MonoMod.Utils;
using System;

namespace Glorymod.NPCs
{
    public class SuperCreeper : ModNPC
    {

        int shootTimer;
        NPC npce;
        int timer2;
        int Phase = 1;
        int PhaseTimer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scarlet Creeper");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override bool CheckDead()
        {
            Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<Explosion>(), 0, 2);
            return true;
        }
        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 30;
            npc.lifeMax = 420;
            npc.damage = 40;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
            npc.defense = 12;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.aiStyle = -1;
            npc.knockBackResist = 0;
        }
        public override bool CheckActive()
        {
            return false;
        }
        public override void FindFrame(int frameHeight)
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
                timer2 = 0;

            }
        }
        public override void AI()
        {
            if (Main.player.Count(p => p.active && !p.dead) == 0)
            {
                npc.active = false;
            }
            for (int i = 0; i < Main.maxNPCs; i++)
            {

                npce = Main.npc[i];
                if (NPC.AnyNPCs(ModContent.NPCType<SuperCreeper3>()))
                {
                    if (npce.type == ModContent.NPCType<SuperCreeper3>() && npce.active)
                    {
                        Vector2 betweenBrain = npc.Center - npce.Center;
                        betweenBrain.Normalize();
                        break;
                    }
                }
                else
                {
                    if (npce.type == ModContent.NPCType<Brain>() && npce.active)
                    {
                        Vector2 betweenBrain = npc.Center - npce.Center;
                        betweenBrain.Normalize();
                        break;
                    }
                }
            }
            npc.TargetClosest();
            PhaseTimer++;
            if(PhaseTimer > 300 && Phase == 1)
            {
                Phase = 2;
                PhaseTimer = 0;
            }
            if (PhaseTimer > 300 && Phase == 2)
            {
                Phase = 3;
                PhaseTimer = 0;
                shootTimer = 0;
            }
            if (PhaseTimer > 300 && Phase == 3)
            {
                Phase = 1;
                PhaseTimer = 0;
            }
            Player player = Main.player[npc.target];
            if (Phase == 1)
            {
                float speed = 23f;
                float inertia = 60f;
                Vector2 direction = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                npc.rotation = npc.velocity.ToRotation();
            }
            if (Phase == 2)
            {
                float speed = 23f;
                float inertia = 60f;
                Vector2 direction = new Vector2(npce.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                npc.rotation = npc.velocity.ToRotation();
                shootTimer++;
                if(shootTimer > 40)
                {
                    Vector2 between = player.Center - npc.Center;
                    between.Normalize();
                    Projectile.NewProjectile(npc.Center,between * 10, ModContent.ProjectileType<BrainFlame2>(), 20, 1);
                    shootTimer = 0;
                }
            }
            if (Phase == 3)
            {
                shootTimer++;
                npc.velocity *= 0.95f;
                Vector2 between = player.Center - npc.Center;
                between.Normalize();
                between *= 30;
                if(shootTimer == 1)
                {
                    npc.velocity = between;
                    
                }
                if (shootTimer == 120)
                {
                    npc.velocity = between;
                    shootTimer = 0;
                }
            }

        }
    }



    public class SuperCreeper2 : ModNPC
    {
        int shootTimer;
        NPC npce;
        int timer2;
        int Phase = 1;
        int PhaseTimer;
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plasma Creeper");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override bool CheckDead()
        {
            Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<Explosion>(), 0, 2);
            return true;
        }
        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 30;
            npc.lifeMax = 400;
            npc.damage = 40;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
            npc.defense = 12;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.aiStyle = -1;
            npc.knockBackResist = 0;
        }
        public override bool CheckActive()
        {
            return false;
        }
        public override void FindFrame(int frameHeight)
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
                timer2 = 0;

            }
        }
        public override void AI()
        {
            if (Main.player.Count(p => p.active && !p.dead) == 0)
            {
                npc.active = false;
            }
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                npce = Main.npc[i];
                if (NPC.AnyNPCs(ModContent.NPCType<SuperCreeper3>()))
                {
                    if (npce.type == ModContent.NPCType<SuperCreeper3>() && npce.active)
                    {
                        Vector2 betweenBrain = npc.Center - npce.Center;
                        betweenBrain.Normalize();
                        break;
                    }
                }
                else
                {
                    if (npce.type == ModContent.NPCType<Brain>() && npce.active)
                    {
                        Vector2 betweenBrain = npc.Center - npce.Center;
                        betweenBrain.Normalize();
                        break;
                    }
                }
                
                

            }
            npc.TargetClosest();
            PhaseTimer++;
            if (PhaseTimer > 300 && Phase == 1)
            {
                Phase = 2;
                PhaseTimer = 0;
            }
            if (PhaseTimer > 300 && Phase == 2)
            {
                Phase = 3;
                PhaseTimer = 0;
                shootTimer = 0;
            }
            if (PhaseTimer > 300 && Phase == 3)
            {
                Phase = 1;
                PhaseTimer = 0;
            }
            Player player = Main.player[npc.target];
            if (Phase == 1)
            {
                float speed = 14f;
                float inertia = 60f;
                Vector2 direction = new Vector2(npce.Center.X - npc.Center.X, npce.Center.Y - npc.Center.Y);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                npc.rotation = npc.velocity.ToRotation() - MathHelper.ToDegrees(180);
            }
            if (Phase == 2)
            {
                float speed = 14f;
                float inertia = 60f;
                Vector2 direction = new Vector2(npce.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                npc.rotation = npc.velocity.ToRotation() - MathHelper.ToDegrees(180);
                shootTimer++;
                if (shootTimer > 20)
                {
                    Main.PlaySound(SoundID.Item33, (int)npc.Center.X, (int)npc.Center.Y);
                    Vector2 between = player.Center - npc.Center;
                    between.Normalize();
                    Projectile.NewProjectile(npc.Center, between * 2, ModContent.ProjectileType<CreeperProj>(), 20, 1);
                    shootTimer = 0;
                }
            }
            if (Phase == 3)
            {
                float speed = 14f;
                float inertia = 60f;
                Vector2 direction = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                npc.rotation = npc.velocity.ToRotation() - MathHelper.ToDegrees(180);
            }

        }
    }


    //SHIELD CREEPER
    public class SuperCreeper3 : ModNPC
    {
        int shootTimer;
        NPC npce;
        int timer2;
        int Phase = 1;
        int PhaseTimer;
        int CooldownTimer;
        int b;
        public bool Cooldown = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shield Creeper");
            Main.npcFrameCount[npc.type] = 5;
        }
        public override bool CheckDead()
        {
            Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<Explosion>(), 0, 2);
            return true;
        }
        private int center
        {
            get => (int)npc.ai[0];
            set => npc.ai[0] = value;
        }
        public override void SetDefaults()
        {
            npc.width = 35;
            npc.height = 35;
            npc.lifeMax = 400;
            npc.damage = 40;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
            npc.defense = 12;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.aiStyle = -1;
            npc.knockBackResist = 0;
        }
        public void StartCooldown()
        {
            Cooldown = true;
        }
        public override bool CheckActive()
        {
            return false;
        }
        public override void FindFrame(int frameHeight)
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
            if (timer2 > 36)
            {
                npc.frame.Y = frameHeight * 4;
                timer2 = 0;

            }
        }
        bool ShieldExist;
        public override void AI()
        {
            
            if (Cooldown)
            {
                CooldownTimer++;
                if(CooldownTimer > 300)
                {
                    CooldownTimer = 0;
                    Cooldown = false;   
                }
            }
            if (Main.player.Count(p => p.active && !p.dead) == 0)
            {
                npc.active = false;
            }
            for (int i = 0; i < Main.maxNPCs; i++)
            {

                npce = Main.npc[i];
                if (npce.type == ModContent.NPCType<Brain>() && npce.active)
                {
                    Vector2 betweenBrain = npc.Center - npce.Center;
                    betweenBrain.Normalize();
                    break;
                }

            }
            npc.TargetClosest();
            PhaseTimer++;
            if (PhaseTimer > 300 && Phase == 1)
            {
                ShieldExist = false;
                NPC npcee;
                for (int i = 0; i < Main.maxNPCs; i++)
                {

                    npcee = Main.npc[i];
                    if (npcee.type == ModContent.NPCType<ForceShield>() && npcee.active)
                    {
                        ShieldExist = true;
                        
                        break;
                    }

                }
                if(!ShieldExist && !Cooldown)
                {
                    int Shield = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<ForceShield>());
                    Main.npc[Shield].ai[0] = npc.whoAmI;
                }
                Phase = 2;
                PhaseTimer = 0;
            }
            if (PhaseTimer > 300 && Phase == 2)
            {
                ShieldExist = false;
                NPC npcee;
                for (int i = 0; i < Main.maxNPCs; i++)
                {

                    npcee = Main.npc[i];
                    if (npcee.type == ModContent.NPCType<ForceShield>() && npcee.active)
                    {
                        ShieldExist = true;
                        
                        break;
                    }

                }
                if (!ShieldExist && !Cooldown)
                {
                    int Shield = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<ForceShield>());
                    Main.npc[Shield].ai[0] = npc.whoAmI;
                }
                Phase = 3;
                PhaseTimer = 0;
                shootTimer = 0;
            }
            if (PhaseTimer > 300 && Phase == 3)
            {
                ShieldExist = false;
                NPC npcee;
                for (int i = 0; i < Main.maxNPCs; i++)
                {

                    npcee = Main.npc[i];
                    if (npcee.type != ModContent.NPCType<ForceShield>())
                    {
                        ShieldExist = true;
                        
                        break;
                    }

                }
                if (!ShieldExist && NPC.AnyNPCs(ModContent.NPCType<SuperCreeper>()) || !ShieldExist && NPC.AnyNPCs(ModContent.NPCType<SuperCreeper2>()) && !Cooldown)
                {
                    int Shield = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<ForceShield>());
                    Main.npc[Shield].ai[0] = npc.whoAmI;
                }
                Phase = 1;
                PhaseTimer = 0;
            }
            Player player = Main.player[npc.target];
            if(NPC.AnyNPCs(ModContent.NPCType<SuperCreeper>()) || NPC.AnyNPCs(ModContent.NPCType<SuperCreeper2>()))
            {
                if (Phase == 1)
                {
                    float speed = 7f;
                    float inertia = 60f;
                    Vector2 direction = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                    direction.Normalize();
                    direction *= speed;
                    npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                    npc.rotation = npc.velocity.ToRotation() - MathHelper.ToDegrees(90);
                }
                if (Phase == 2)
                {
                    float speed = 7f;
                    float inertia = 60f;
                    Vector2 direction = new Vector2(npce.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                    direction.Normalize();
                    direction *= speed;
                    npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                    npc.rotation = npc.velocity.ToRotation() - MathHelper.ToDegrees(90);
                    shootTimer++;
                    if (shootTimer > 40)
                    {
                        Vector2 between = player.Center - npc.Center;
                        between.Normalize();

                        shootTimer = 0;
                    }
                }
                if (Phase == 3)
                {
                    shootTimer++;
                    npc.velocity *= 0.95f;
                    Vector2 between = player.Center - npc.Center;
                    between.Normalize();
                    between *= 10;
                    if (shootTimer == 1)
                    {
                        npc.velocity = between;

                    }
                    if (shootTimer == 120)
                    {
                        npc.velocity = between;
                        shootTimer = 0;
                    }
                }
            }
            else
            {
                if (Phase == 1)
                {
                    npc.defense = -4;
                    float speed = 50f;
                    float inertia = 120f;
                    Vector2 direction = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                    direction.Normalize();
                    direction *= speed;
                    npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                    npc.rotation = npc.velocity.ToRotation() - MathHelper.ToDegrees(90);
                }
                if (Phase == 2)
                {
                    npc.defense = -4;
                    float speed = 50f;
                    float inertia = 120f;
                    Vector2 direction = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                    direction.Normalize();
                    direction *= speed;
                    npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                    npc.rotation = npc.velocity.ToRotation() - MathHelper.ToDegrees(90);
                    shootTimer++;
                    if (shootTimer > 40)
                    {
                        Vector2 between = player.Center - npc.Center;
                        between.Normalize();

                        shootTimer = 0;
                    }
                }
                if (Phase == 3)
                {
                    npc.defense = -4;
                    float speed = 50f;
                    float inertia = 120f;
                    Vector2 direction = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y);
                    direction.Normalize();
                    direction *= speed;
                    npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                    npc.rotation = npc.velocity.ToRotation() - MathHelper.ToDegrees(90);
                    shootTimer++;
                    if (shootTimer > 40)
                    {
                        Vector2 between = player.Center - npc.Center;
                        between.Normalize();

                        shootTimer = 0;
                    }
                }
            }
            

        }
    }


    // SHIELD
    public class ForceShield : ModNPC
    {
        
        NPC npce;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force Shield");
        }
        public override void SetDefaults()
        {
            npc.HitSound = SoundID.Item15;
            npc.DeathSound = SoundID.Item100;
            npc.width = 140;
            npc.height = 140;
            npc.aiStyle = -1;
            npc.knockBackResist = 0;
            npc.lifeMax = 400;
            npc.scale = 1.5f;
            npc.noTileCollide = true;
        }
        bool Exist;
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            projectile.active = false;
        }
        public override void AI()
        {

            
            
            if (Main.player.Count(p => p.active && !p.dead) == 0)
            {
                npc.active = false;
            }
            Exist = false;
            
            for (int i = 0; i < Main.maxNPCs; i++)
            {

                npce = Main.npc[i];
                if (npce.type == ModContent.NPCType<SuperCreeper3>() && npce.active)
                {
                    Exist = true;
                    
                    break;
                }

            }
            npc.position.X = npce.position.X - npc.width / 2;
            npc.position.Y = npce.position.Y - npc.height / 2;
            if (!Exist)
            {
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<SuperCreeper>()) && !NPC.AnyNPCs(ModContent.NPCType<SuperCreeper2>()))
            {
                npc.active = false;
            }
        }
        public override bool CheckDead()
        {
            for(int i = 0; i < 20; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = npc.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, npc.width, npc.height, 110, 0f, 0f, 0, new Color(255, 255, 255), 5f)];
                
            }
            SuperCreeper3 forceshield = Main.npc[(int)npc.ai[0]].modNPC as SuperCreeper3;
            forceshield.StartCooldown();
            return true;
        }




    }
}
