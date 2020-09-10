using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
using Glorymod;
using Glorymod.Buffs;
using System.Linq;

namespace Glorymod.Items.Accessories.Hm
{
    public class TrophyOfMenace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trophy of Menace");
            Tooltip.SetDefault("Life regeneration disabled and permanent potion sickness\nEquiping during a bossfight or unequping while not at max health will instantly kill you.\n'A heavy burden'\nGlorious Drop");
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
            player.GetModPlayer<MPlayer>().Burden = true;
            if (!player.HasBuff(ModContent.BuffType<TheBurden>()))
            {
                if (Main.npc.Any(n => n.active && n.boss && n.whoAmI != 200))
                {
                    player.KillMe(PlayerDeathReason.ByOther(1), 10.0, 0);
                }
            }
            player.AddBuff(ModContent.BuffType<TheBurden>(), 3);
            player.AddBuff(BuffID.PotionSickness, 4);
        }
    }
}
