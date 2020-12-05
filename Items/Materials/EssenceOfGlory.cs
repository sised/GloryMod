using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace Glorymod.Items.Materials
{
    public class EssenceOfGlory : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of Glory");
            Tooltip.SetDefault("Contains a small amount of glory earned upon battle, \nUsed to crat most of Glorymod's items, stacks up to 9999.");            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 5));
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.maxStack = 9999;
            item.value = 0;
            item.rare = 0;
        }


    }
}
