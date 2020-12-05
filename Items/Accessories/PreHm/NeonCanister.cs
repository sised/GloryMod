using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
using Glorymod;
namespace Glorymod.Items.Accessories.PreHm
{
    public class NeonCanister : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Canister");
            Tooltip.SetDefault("Every ranged weapon has a 25% chance to fire a neon bolt\nThe neon bolt deals 25 true damage\nHas a cooldown of 5/6ths of a second\nGoes through walls\nGlorious drop");
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
            player.GetModPlayer<MPlayer>().isWearingNeonCanister = true;
        }
    }
}
