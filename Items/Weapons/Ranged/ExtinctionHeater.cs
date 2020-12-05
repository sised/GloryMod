using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Buffs;
using Glorymod.Projectiles;
using Microsoft.Xna.Framework.Graphics;

namespace Glorymod.Items.Weapons.Ranged
{
    public class DemonSemen : ModItem
    {
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, 0);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Extinction Heater");
            Tooltip.SetDefault("Left click shoots, Right click uses grapple hook\nThe hook damages enemies and sets them on fire\nGlorious Drop");
        }
        public override void SetDefaults()
        {
            item.damage = 12;
            item.crit = 6;
            item.knockBack = 0f;
            item.width = 16;
            item.height = 28;
            item.value = Item.buyPrice(silver: 36);
            item.useStyle = 5;
            item.rare = -12;
            item.UseSound = SoundID.Item36;
            item.noMelee = true;
            item.ranged = true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.shootSpeed = 30;
                item.damage = 12;                
                item.useAnimation = 12;
                item.useTime = 12;
                item.shoot = ProjectileType<Hook>();
                item.UseSound = SoundID.Item5;
                item.useAmmo = AmmoID.None;
                item.autoReuse = false;
            }
            else
            { 
                item.shootSpeed = 10;
                item.damage = 12;
                item.useAnimation = 30;
                item.useTime = 30;
                item.UseSound = SoundID.Item36;
                item.useAmmo = AmmoID.Bullet;
                item.shoot = ProjectileID.Bullet;
                item.autoReuse = true;
            }
            return true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (player.altFunctionUse == 2)
            {
                target.AddBuff(BuffID.OnFire, 60);
            }
            else
            {
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(player.altFunctionUse == 2)
            {
                return true;

            }
            else
            {
                int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7)); // 30 degree spread.
                                                                                                                   // If you want to randomize the speed to stagger the projectiles
                                                                                                                   // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                   // perturbedSpeed = perturbedSpeed * scale; 
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
                return false; // return false because we don't want tmodloader to shoot projectile
            }
        }
        internal class Hook : ModProjectile
        {

            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("${ProjectileName.GemHookAmethyst}");
            }
            public override void SetDefaults()
            {
                    projectile.penetrate = -1;
                
                projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
            }

            // Use this hook for hooks that can have multiple hooks mid-flight: Dual Hook, Web Slinger, Fish Hook, Static Hook, Lunar Hook
            public override bool? CanUseGrapple(Player player)
            {
                int hooksOut = 0;
                for (int l = 0; l < 1000; l++)
                {
                    if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == projectile.type)
                    {
                        hooksOut++;
                    }
                }
                if (hooksOut > 0) // This hook can have 1 hook out.
                {
                    return false;
                }
                return true;
            }

            // Return true if it is like: Hook, CandyCaneHook, BatHook, GemHooks

            // Use this to kill oldest hook. For hooks that kill the oldest when shot, not when the newest latches on: Like SkeletronHand
            // You can also change the projectile like: Dual Hook, Lunar Hook
            public override void UseGrapple(Player player, ref int type)
            {
            	int hooksOut = 0;
            	int oldestHookIndex = -1;
            	int oldestHookTimeLeft = 100000;
            	for (int i = 0; i < 1000; i++)
            	{
            		if (Main.projectile[i].active && Main.projectile[i].owner == projectile.whoAmI && Main.projectile[i].type == projectile.type)
            		{
            			hooksOut++;
            			if (Main.projectile[i].timeLeft < oldestHookTimeLeft)
            			{
            				oldestHookIndex = i;
            				oldestHookTimeLeft = Main.projectile[i].timeLeft;
            			}
            		}
            	}
            	if (hooksOut > 0)
            	{
            		Main.projectile[oldestHookIndex].Kill();
            	}
            }

            // Amethyst Hook is 300, Static Hook is 600
            public override float GrappleRange()
            {
                return 700f;
            }
            public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
            {
                target.AddBuff(BuffID.OnFire, 300);
            }
            public override void NumGrappleHooks(Player player, ref int numHooks)
            {
                numHooks = 2;
            }

            // default is 11, Lunar is 24
            public override void GrappleRetreatSpeed(Player player, ref float speed)
            {
                speed = 14f;
            }

            public override void GrapplePullSpeed(Player player, ref float speed)
            {
                speed = 12;
            }
            public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
            {
                Vector2 playerCenter = Main.player[projectile.owner].MountedCenter;
                Vector2 center = projectile.Center;
                Vector2 distToProj = playerCenter - projectile.Center;
                float projRotation = distToProj.ToRotation() - 1.57f;
                float distance = distToProj.Length();
                while (distance > 30f && !float.IsNaN(distance))
                {
                    distToProj.Normalize();                 //get unit vector
                    distToProj *= 24f;                      //speed = 24
                    center += distToProj;                   //update draw position
                    distToProj = playerCenter - center;    //update distance
                    distance = distToProj.Length();
                    Color drawColor = lightColor;

                    //Draw chain
                    spriteBatch.Draw(mod.GetTexture("Items/Weapons/Ranged/Chain"), new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y),
                        new Rectangle(0, 0, Main.chain30Texture.Width, Main.chain30Texture.Height), drawColor, projRotation,
                        new Vector2(Main.chain30Texture.Width * 0.5f, Main.chain30Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                }
                return true;
            }
        }
    }
}
