using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Buffs;
using Glorymod.Projectiles;

namespace Glorymod.Items.Weapons.Mage
{
    public class AtomicPointer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atomic Pointer");
            Tooltip.SetDefault("Shoots a burst of face-melting lasers\nHigh mana usage\nGlorious Drop");
        }
        public override void SetDefaults()
        {
            item.useAnimation = 12;
            item.useTime = 2;
            item.reuseDelay = 17;

            item.damage = 15;
            item.crit = 12;
            item.knockBack = 0f;
            item.mana = 20;
            item.width = 34;
            item.height = 34;
            item.value = Item.buyPrice(silver: 36);
            item.useStyle = 5;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = -12;
            item.UseSound = SoundID.Item12;
            item.autoReuse = true;
            // These below are needed for a minion weapon
            item.noMelee = true;
            item.magic = true;
            // No buffTime because otherwise the itemtooltip would say something like "1 minute duration"
            item.shoot = ProjectileType<AtomicLaser>();
            item.shootSpeed = 25;
        }
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        
    }
}
