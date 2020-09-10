using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace Glorymod.Items.Materials
{
    public class NeonGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Gel");
            Tooltip.SetDefault("Looks unbelievably cool");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.maxStack = 999;
            item.value = 27;
            item.rare = 0;
        }


    }
}
