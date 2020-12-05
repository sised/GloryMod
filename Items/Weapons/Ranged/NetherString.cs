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
    public class NetheriteBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nether String");
            Tooltip.SetDefault("Fires 2 Arrows and 2 Lasers\nGlorious Drop");
        }
        public override void SetDefaults()
        {
            item.damage = 66;
            item.crit = 0;
            item.knockBack = 1f;
            item.width = 32;
            item.height = 74;
            item.useTime = 23;
            item.value = Item.buyPrice(silver: 36);
            item.useAnimation = 23;
            item.useStyle = 5;
            item.rare = -12;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.ranged = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 10;
            item.autoReuse = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1; //1 shot
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX + Main.rand.Next(2), speedY + Main.rand.Next(2)).RotatedByRandom(MathHelper.ToRadians(4)); // 30 degree spread.
                                                                                                                                                       // If you want to randomize the speed to stagger the projectiles
                Vector2 perturbedSpeed2 = new Vector2(speedX + Main.rand.Next(2), speedY + Main.rand.Next(2)).RotatedByRandom(MathHelper.ToRadians(4)); // 30 degree spread.                                                                                        // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                                                       // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.MiniRetinaLaser, damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, ProjectileID.MiniRetinaLaser, damage, knockBack, player.whoAmI);
            }
            return true; // return false because we don't want tmodloader to shoot projectile
        }
    }
}
