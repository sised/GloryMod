using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Buffs;
using Glorymod.Projectiles;

namespace Glorymod.Items.Weapons.Summon
{
    public class TerrorPearl : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terror Pearl");
            Tooltip.SetDefault("Evocates a Terror Infant to slay your enemies agaisnt its will\nOnly one can exist at a time");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);


            recipe.AddIngredient(mod.ItemType("NightmareStaff"));
            recipe.AddIngredient(ItemID.TissueSample, 2);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("NightmareStaff"));
            recipe.AddIngredient(ItemID.ShadowScale, 2);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetDefaults()
        {
            item.damage = 40;
            item.knockBack = 3f;
            item.mana = 10;
            item.width = 32;
            item.height = 32;
            item.useTime = 36;
            item.value = Item.buyPrice(silver: 80);
            item.useAnimation = 36;
            item.useStyle = 1;
            item.rare = 2;
            item.UseSound = SoundID.Item44;

            // These below are needed for a minion weapon
            item.noMelee = true;
            item.summon = true;
            item.buffType = BuffType<Infanted>();
            // No buffTime because otherwise the itemtooltip would say something like "1 minute duration"
            item.shoot = ProjectileType<TerrorInfant>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (!player.HasBuff(ModContent.BuffType<Infanted>()))
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
