using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Buffs;
using Glorymod.Projectiles;

namespace Glorymod.Items.Weapons.Melee
{
    public class TheOverwatch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Overwatch");
            Tooltip.SetDefault("Watches your enemies\n`RIP gazing darkness, you will be remembered`\nRare Glorious Drop");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 28;
            item.knockBack = 14f;
            item.crit = 10;
            item.width = 54;
            item.height = 54;
            item.useTime = 25;
            item.value = Item.buyPrice(silver: 72);
            item.useAnimation = 25;
            item.useStyle = 1;
            item.autoReuse = true;
            item.rare = -12;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            // These below are needed for a minion weapon
            item.melee = true;
            
            // No buffTime because otherwise the itemtooltip would say something like "1 minute duration"
            
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (!player.HasBuff(ModContent.BuffType<Spawned>()))
            {
                // This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
                player.AddBuff(item.buffType, 2);

                // Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
                position = Main.MouseWorld;
                return true;
            }
            else return false;

        }

    }
}
