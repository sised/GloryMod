using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
namespace Glorymod.Items.Accessories.PreHm
{
    public class NaturalCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Natural Core");
            Tooltip.SetDefault("Attacks inflict poison for 10 seconds");
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 28;
            item.value = 4000;
            item.rare = 1;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MPlayer>().isWearingNaturalCore = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.JungleSpores, 14);
            recipe.AddIngredient(ItemID.JungleGrassSeeds, 4);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
