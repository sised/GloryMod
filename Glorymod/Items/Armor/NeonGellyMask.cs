using Glorymod.Items;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Glorymod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class NeonGellyMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Gelly Mask");
            Tooltip.SetDefault("+10% increased ranged critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;

            item.rare = 2;
            item.defense = 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<NeonBreastplate>() && legs.type == ItemType<NeonLeggings>();
        }
        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 10;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased ranged damage by 10%";
            player.rangedDamage *= 1.1f;
            /* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);


            recipe.AddIngredient(mod.ItemType("NeonGel"), 8);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}