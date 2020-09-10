using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Projectiles;

namespace Glorymod.Buffs
{
    public class TheBurden : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("The Burden");
            Description.SetDefault("'A heavy burden'");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = player.lifeRegen - player.lifeRegen;
        }
    }

}