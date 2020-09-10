using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Glorymod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class NeonLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Leggings");
            Tooltip.SetDefault("5% increased movement speed");
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
            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);


            recipe.AddIngredient(mod.ItemType("NeonGel"), 12);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}