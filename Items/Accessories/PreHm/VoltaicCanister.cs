using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace Glorymod.Items.Accessories.PreHm
{
    public class VoltaicCanister : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Voltaic Canister");
            Tooltip.SetDefault("Slowly damages enemies in a massive radius\nCan also help in cave exploration since its particles provide light\n'RIP Thunderstrung, you will be remembered'\nRare Glorious Drop");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(3, 3));
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 5000;
            item.rare = -12;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MPlayer>().isWearingVoltaicCanister = true;
        }
    }
}
