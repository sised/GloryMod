using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Buffs;
using Glorymod.Projectiles;
using Steamworks;

namespace Glorymod.Items.Weapons.Melee
{
    public class EnigmasPlanetaryExcavator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enigma's Planetary Excavator");
            Tooltip.SetDefault("Another one of Enigma's Experiments\nThis unbelievably powerful tool can destroy planets whole.\nUnobtainable Item");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 4000;
            item.knockBack = 20f;
            item.crit = 20;
            item.width = 133;
            item.height = 133;
            item.useTime = 1;
            item.value = Item.buyPrice(platinum: 9999);
            item.useAnimation = 1;
            item.useStyle = 1;
            item.autoReuse = true;
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            item.pick = 200000000;
            // These below are needed for a minion weapon
            item.melee = true;

            // No buffTime because otherwise the itemtooltip would say something like "1 minute duration"

        }


    }
}
