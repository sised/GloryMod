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
    public class FrigidShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frigid Shard");
            Tooltip.SetDefault("Once equiped, a Frigidflake will fight on your side\n10 damage, is affected by summon damage multiplier\nDoesn't take up any minion slots");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 30;
            item.value = 7000;
            item.rare = 2;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MPlayer>().isWearingFrigidShard = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.IceBlock, 20);
            recipe.AddIngredient(ItemID.SnowBlock, 15);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
