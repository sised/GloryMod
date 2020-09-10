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
    public class RadiatedOdor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radiated Odor");
            Tooltip.SetDefault("Fires a beam of neon");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 28;
            item.knockBack = 5f;
            item.crit = 4;
            item.width = 52;
            item.height = 52;
            item.useTime = 20;
            item.value = Item.buyPrice(silver: 61);
            item.useAnimation = 20;
            item.useStyle = 1;
            item.autoReuse = true;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            item.shoot = ModContent.ProjectileType<NeonBeam2>();
            item.shootSpeed = 10;
            // These below are needed for a minion weapon
            item.melee = true;

            // No buffTime because otherwise the itemtooltip would say something like "1 minute duration"

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);


            recipe.AddIngredient(mod.ItemType("NeonGel"), 12);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            Main.PlaySound(SoundID.Item8);
            

            return true;

        }

    }
}
