using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Glorymod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class NeonBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Neon Breastplate");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;

            item.rare = 2;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.blockRange += 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);


            recipe.AddIngredient(mod.ItemType("NeonGel"), 15);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}