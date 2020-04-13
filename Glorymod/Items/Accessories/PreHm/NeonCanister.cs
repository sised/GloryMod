using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
using Glorymod;
namespace Glorymod.Items.Accessories.PreHm
{
    public class NeonCanister : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Canister");
            Tooltip.SetDefault("Every ranged weapon has a 25% chance to fire a neon bolt\nThe neon bolt deals 25 true damage\nHas a cooldown of 5/6ths of a second\nGoes through walls\nGlorious drop");
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 28;
            item.value = 5000;
            item.rare = -12;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MPlayer>().isWearingNeonCanister = true;
            
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
