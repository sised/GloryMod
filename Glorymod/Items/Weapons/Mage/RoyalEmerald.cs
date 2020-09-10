using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Buffs;
using Glorymod.Projectiles;

namespace Glorymod.Items.Weapons.Mage
{
    public class RoyalEmerald : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Emerald");
            Tooltip.SetDefault("Rapidly shoots green magical missiles");
            Item.staff[item.type] = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 25);
            recipe.AddIngredient(ItemID.Emerald, 10);
            recipe.AddIngredient(ItemID.WandofSparking);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetDefaults()
        {
            item.damage = 14;
            item.crit = 3;
            item.knockBack = 3f;
            item.mana = 6;
            item.width = 34;
            item.height = 34;
            item.useTime = 12;
            item.value = Item.buyPrice(silver: 36);
            item.useAnimation = 12;
            item.useStyle = 5;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item9;
            item.autoReuse = true;
            // These below are needed for a minion weapon
            item.noMelee = true;
            item.magic = true;
            // No buffTime because otherwise the itemtooltip would say something like "1 minute duration"
            item.shoot = ProjectileType<RoyalEmeraldP>();
            item.shootSpeed = 10;
        }        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1 + Main.rand.Next(2); // 2 or 3 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                                                                                                                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, type, damage, knockBack, player.whoAmI);
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }

    }
}
