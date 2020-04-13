using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
namespace Glorymod.Items.Accessories.PreHm
{
    public class Aerogel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aerogel");
            Tooltip.SetDefault("Boosts jump speed and slightly reduces fall speed\n'World's lightest solid!'");
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 28;
            item.value = 5000;
            item.rare = 1;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.jumpSpeedBoost += 2f;
            player.maxFallSpeed -= 0.6f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddIngredient(ItemID.Feather, 3);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
