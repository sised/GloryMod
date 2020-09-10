using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Buffs;
using Glorymod.Projectiles;

namespace Glorymod.Items.Weapons.Ranged
{
    public class RoyalBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Bow");
            Tooltip.SetDefault("The bow of a royal archer devoured by a Hornet");
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.crit = 6;
            item.knockBack = 0f;
            item.width = 16;
            item.height = 28;
            item.useTime = 23;
            item.value = Item.buyPrice(silver: 36);
            item.useAnimation = 23;
            item.useStyle = 5;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.ranged = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 10;
            item.autoReuse = true;
        }
    }
}
