using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Glorymod;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Glorymod
{
    public class GlobalIteme : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
        int timer;
        public override void SetDefaults(Item item)
        {
            if(item.type == ItemID.StarCannon)
            {
                item.damage = 25;
            }
            if(item.type == ItemID.BookofSkulls)
            {
                item.color = Color.MediumPurple;
                item.damage = 42;
                
            }
            
        }        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.BookofSkulls)
            {
                
                TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (tt != null)
                {
                    tt.text = "Shoots a Deomic Claw" + "\nDamage has been increased from the vanilla counterpart";
                }
            }
        }
        public override void HoldItem(Item item, Player player)
        {
            
            
            timer++;
            
            if(player.itemAnimation == player.itemAnimationMax - 1)
            {
                
                if (player.GetModPlayer<MPlayer>().isWearingNeonCanister && item.ranged)
                {
                    int r = Main.rand.Next(4);
                    if (r == 1 && timer > 50) //25%
                    {
                        Vector2 Cu = player.DirectionTo(Main.MouseWorld) * 10f;
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, Cu.X, Cu.Y, ModContent.ProjectileType<Projectiles.NeonBolt>(), 25, 5, Main.myPlayer);
                        timer = 0;
                        
                    }
                }
                
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.WandofSparking);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.Cloud, 15);
            recipe.AddIngredient(ItemID.Bottle, 3);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.CloudinaBottle);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.SandBlock, 15);
            recipe.AddIngredient(ItemID.Bottle, 3);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 70);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.SandstorminaBottle);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.SnowBlock, 15);
            recipe.AddIngredient(ItemID.Bottle, 3);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 50);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.BlizzardinaBottle);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.Bottle, 3);
            recipe.AddIngredient(ItemID.RainCloud, 5);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 50);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.BlizzardinaBottle);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.RedDye);
            recipe.AddIngredient(ItemID.RainCloud, 5);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 50);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.ShinyRedBalloon);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.SilverBar, 5);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 40);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.LuckyHorseshoe);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.TungstenBar, 5);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 40);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.LuckyHorseshoe);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 200);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.FlyingCarpet);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            // ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
            recipe.AddIngredient(mod.ItemType("EssenceOfGlory"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.FallenStar);
            recipe.AddRecipe();
        }
    } 
}
