using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
namespace Glorymod.Items.BossHelpers
{
    public class AnnihGuide : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Annihilator Boss Guide Handbook");
            Tooltip.SetDefault("Contains Tips and hints on how to defeat the \nanimate machine of mass destruction\nIf you feel like you can figure out his attack pattern on your own\nfeel free to not use this item");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.rare = ItemRarityID.LightRed;
            item.useStyle = 4;
            item.useTime = 20;
            item.useAnimation = 20;
        }
        public override bool UseItem(Player player)
        {
            switch(player.GetModPlayer<MPlayer>().AnnihGuideNum)
            {
                case 1: 
                    Main.NewText("Annihilator Boss Guide Handbook (1/5)", Color.Red);
                    Main.NewText("When Annihilator fires his laser, keep a 90 degree angle off of the", Color.IndianRed);
                    Main.NewText("laser's direction, if the angle is too much annihilator will turn significantly", Color.IndianRed);
                    Main.NewText("faster and you'll stand no chance of dodging the laser", Color.IndianRed);
                    break;
                case 2:
                    Main.NewText("Annihilator Boss Guide Handbook (2/5)", Color.Red);
                    Main.NewText("If you feel trapped don't be afraid to use rod of discord", Color.IndianRed);
                    break;
                case 3:
                    Main.NewText("Annihilator Boss Guide Handbook (3/5)", Color.Red);
                    Main.NewText("Don't use mounts, they will cause annihilator to enrage", Color.IndianRed);
                    break;
                case 4:
                    Main.NewText("Annihilator Boss Guide Handbook (4/5)", Color.Red);
                    Main.NewText("When annihilator supercharges you in phase 2", Color.IndianRed);
                    Main.NewText("RoD and run as far away as you can to gain as much distance as possible", Color.IndianRed);
                    Main.NewText("With the proper setup you should be able to outrun him", Color.IndianRed);
                    Main.NewText("when he's done supercharging go back to dodging him normally.", Color.IndianRed);
                    break;
                case 5:
                    Main.NewText("Annihilator Boss Guide Handbook (5/5)", Color.Red);
                    Main.NewText("Don't try to outrun his continious dashes on phase 2, you wont be able to.", Color.IndianRed);
                    break;
            }
            player.GetModPlayer<MPlayer>().AnnihGuideNum++;
            if (player.GetModPlayer<MPlayer>().AnnihGuideNum > 5) 
                player.GetModPlayer<MPlayer>().AnnihGuideNum = 1;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 1);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
