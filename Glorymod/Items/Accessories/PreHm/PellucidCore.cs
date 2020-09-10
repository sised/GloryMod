using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
namespace Glorymod.Items.Accessories.PreHm
{
    public class PellucidCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pellucid Core");
            Tooltip.SetDefault("While in corruption, mining speed is doubled\nGlorious Drop");
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
            if(player.ZoneCorrupt)
            {
                player.pickSpeed *= 0.5f;
            }
        }
    }
}
