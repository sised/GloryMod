using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Projectiles;

namespace Glorymod.Buffs
{
    public class Infanted : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Infanted");
            Description.SetDefault("A Terror Infant is cursed to slay your enemies");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ProjectileType<TerrorInfant>()] > 0)
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