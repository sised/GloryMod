using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
namespace Glorymod.Items.Accessories.PreHm
{
    public class LifeforceArmor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lifeforce Armor");
            Tooltip.SetDefault("Increases max life by 60, but reduces life regen by 1\nAccessory");
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 36;
            item.value = 6000;
            item.rare = 2;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 60;
            player.lifeRegen -= 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.LifeCrystal, 2);
            recipe.AddIngredient(ItemID.GoldBar, 4);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 2);
            recipe.AddIngredient(ItemID.PlatinumBar, 4);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
