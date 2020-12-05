using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace Glorymod.Items.Materials
{
    public class ShadowFile : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ShadowFile.bat");
            Tooltip.SetDefault("~1kb");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 42;
            item.maxStack = 2147483647;
        }
    }
}
