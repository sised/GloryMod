using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace Glorymod.Items.Materials
{
    public class DarkMatter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Matter");
            Tooltip.SetDefault("Not scientifically accurate at all\nUsed to upgrade boss drops\nObtained if a boss is killed while all players had 100% hp for the whole fight\nQuantity depends on the boss");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.maxStack = 9999;
            item.value = 0;
            item.rare = 8;
        }


    }
}
