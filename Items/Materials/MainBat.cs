using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Glorymod.NPCs;

namespace Glorymod.Items.Materials
{
    public class MainBat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Main.Bat");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
        }


    }

    public class MainSys : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Main.Sys");
            Tooltip.SetDefault("Useable at all times and biomes");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.useStyle = 4;
            item.useTime = 1;
            item.useAnimation = 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);


            recipe.AddIngredient(mod.ItemType("MainBat"), 35);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool CanUseItem(Player player)
        {
            // "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
            return !NPC.AnyNPCs(ModContent.NPCType<Corruption>());
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Corruption>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
    }

}
