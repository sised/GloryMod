using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace Glorymod.Items.Accessories.Hm
{
    public class PlasmaCanister : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plasma Canister");
            Tooltip.SetDefault("Deals 12 damage to all living enemies each second\nAccessory visibility = toggle Ultraluminence\nDark Rare Glorious Drop");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.value = 7000;
            item.rare = -12;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);


            recipe.AddIngredient(mod.ItemType("DarkMatter"), 25);
            recipe.AddIngredient(mod.ItemType("VoltaicCanister"));
            recipe.AddIngredient(ItemID.SoulofLight, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MPlayer>().isWearingPlasmaCanister = true;
            if (!hideVisual)
            {
                Lighting.AddLight(player.Center, 0, 255, 0);
            }
            

        }
    }
}
