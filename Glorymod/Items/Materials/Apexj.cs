using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Data.SqlTypes;
using Glorymod.NPCs;

namespace Glorymod.Items.Materials
{
    public class Apexj : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultimate Jellyfish");
            Tooltip.SetDefault("Challenge Rules:\nGetting hit by the boss will instantly kill you\nThe boss only takes 1 damage\nNo map icon\n---------\nSummons the Apex Sightseer, the supreme jellyfish.");
        }
        public override void SetDefaults()
        {
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = -12;
            item.value = 425;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.maxStack = 20;
        }
        public override bool CanUseItem(Player player)
        {
            // "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
            return player.ZoneOverworldHeight && !NPC.AnyNPCs(ModContent.NPCType<Apexeye>());
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Apexeye>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SuspiciousLookingEye);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
