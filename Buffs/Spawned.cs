using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Projectiles;

namespace Glorymod.Buffs
{
    public class Spawned : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Spawned");
            Description.SetDefault("A Nightmare spawn is cursed to protect you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ProjectileType<NightmareSpawn>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            
        }
    }

}