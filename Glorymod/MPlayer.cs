using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Glorymod;
using Microsoft.Xna.Framework;
using Glorymod.Buffs;
using Glorymod.Projectiles;
using System;
using Glorymod.NPCs;

namespace Glorymod
{
    
    // This class stores necessary player info for our custom damage class, such as damage multipliers and additions to knockback and crit.
    public class MPlayer : ModPlayer
    {
        public bool bossalive;
        public bool isWearingNeonCanister = false;
        public bool isWearingNaturalCore = false;
        public bool isWearingSandstoneMedallion = false;
        public bool isWearingFrigidShard = false;
        public bool isWearingVoltaicCanister = false;
        public bool Burden = false;
        bool HasFrigidflakeSpawned = false;
        int spawnX;
        int spawnY;
        
        public static MPlayer ModPlayer(Player player)
        {
           
            return player.GetModPlayer<MPlayer>();
            
        }
        public override void PostUpdate()
        {
            if (Mworld.Menace)
            {
                spawnX = Main.spawnTileX - 1;
                spawnY = Main.spawnTileY - 1;
                if (player.SpawnX != -1 && player.SpawnY != -1)
                {
                    spawnX = player.SpawnX;
                    spawnY = player.SpawnY;
                }
                if (!NPC.AnyNPCs(NPCID.Guide))
                {
                    Main.NewText("The guide has respawned at your spawn point because of Menace mode", Color.Orange);
                    NPC.NewNPC(spawnX * 16, spawnY * 16, NPCID.Guide); //multiplied by 16 since NewNPC uses tile cords and spawnpoint uses pixel cords
                }
            }
            if (isWearingVoltaicCanister)
            {
                for (int i = 0; i < 180; i++)
                {
                    Vector2 dustPos = player.Center + new Vector2(600, 0).RotatedBy(MathHelper.ToRadians(i * 2));
                    Dust dust = Dust.NewDustPerfect(dustPos, 20, null, 0, new Color(255, 255, 255), 0.5f);
                    dust.noGravity = true;
                }
            }            
            if (isWearingFrigidShard && !HasFrigidflakeSpawned)
            {
                HasFrigidflakeSpawned = true;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, ModContent.ProjectileType<Frigidflake>(), (int)(10 * player.minionDamage), 5, Main.myPlayer);
            }
            if (!isWearingFrigidShard)
            {
                HasFrigidflakeSpawned = false;
            }
        }
        // Vanilla only really has damage multipliers in code
        // And crit and knockback is usually just added to
        // As a modder, you could make separate variables for multipliers and simple addition bonuses
        public override void ResetEffects()
        {
            isWearingSandstoneMedallion = false;
            isWearingNaturalCore = false;
            isWearingNeonCanister = false;
            isWearingFrigidShard = false;
            isWearingVoltaicCanister = false;
            Burden = false;
            
        }
        public override void UpdateBadLifeRegen()
        {
            if (Burden)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
            }
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if(Burden)
            {
                damageSource = PlayerDeathReason.ByCustomReason(player.name + " got freed of the burden");
            }
            if(player.HasBuff(ModContent.BuffType<Buffs.BlazingInferno>()))
            {
                damageSource = PlayerDeathReason.ByCustomReason(player.name + " was disintigratede into fine creep dust"); //Reference to Kingdom Rush
            }
            return true;
        }
        public override void PreUpdate()
        {
            if(NPC.AnyNPCs(ModContent.NPCType<Sightseer>()))
            {
                player.ZoneTowerStardust = true;
            }
            for (int i = 0; i < Main.maxNPCs; i++)
            {

                NPC npc = Main.npc[i];
                if (npc.boss && npc.active)
                {
                    bossalive = true;
                    break;
                }
                else bossalive = false;
            }
            if (player.statLife < player.statLifeMax && player.HasBuff(ModContent.BuffType<TheBurden>()) && !Burden)
            {
                player.KillMe(PlayerDeathReason.ByOther(1), 10.0, 0);
            }
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if(npc.type == NPCID.WallofFlesh && Mworld.Menace && npc.active)
                {
                    

                    float distance = (float)(Math.Sqrt((npc.Center.X - player.Center.X) * (npc.Center.X - player.Center.X) + (npc.Center.Y - player.Center.Y) * (npc.Center.Y - player.Center.Y)));
                    if(distance > Main.npc[npc.whoAmI].GetGlobalNPC<GlobalNPCe>().BlazingRadious && player.ZoneUnderworldHeight)
                    {
                        if (player.statLife <= 0)
                        {
                            player.KillMe(PlayerDeathReason.ByOther(1), 10.0, 0);
                        }
                        player.AddBuff(ModContent.BuffType<BlazingInferno>(), 2);
                    }
                }
            }
            if (player.dead)
            {
                
                player.respawnTimer -= 2;
            }
            
            
        }
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (isWearingSandstoneMedallion)
            {
                player.minionDamage = (int)(player.minionDamage * 1.1f);
            }
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (isWearingNaturalCore)
            {
                target.AddBuff(BuffID.Poisoned, 1000);
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if(isWearingNaturalCore)
            {
                target.AddBuff(BuffID.Poisoned, 1000);
            }
        }
        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (isWearingSandstoneMedallion)
            {
                damage = (int)(damage * 1.2f);
            }
        }     
    }
}
