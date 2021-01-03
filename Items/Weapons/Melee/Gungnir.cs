using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Buffs;
using Glorymod.Projectiles;
using Steamworks;

namespace Glorymod.Items.Weapons.Melee
{
    public class Gungnir : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gungnir, Odin's Spear");
            Tooltip.SetDefault("Belongs to an unkown god from another universe\nLegendary Glorious Drop\nDrop Chance: 0.5% (Basalt Barricade)\nDedicated to AlmightyOdin");
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 115;
            item.knockBack = 0f;
            item.crit = 20;
            item.width = 90;
            item.height = 90;
            item.useTime = 20;
            item.value = Item.buyPrice(platinum: 15);
            item.useAnimation = 20;
            item.useStyle = 1;
            item.autoReuse = true;
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            item.melee = true;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<GungnirProj>();
            item.shootSpeed = 20;
        }


    }
    public class GungnirProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gungnir");
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.aiStyle = 0;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 90;
            projectile.height = 90;
            projectile.timeLeft = 400;
            projectile.tileCollide = false;

        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45);
            Dust.NewDustPerfect(projectile.Center, ModContent.DustType<GungnirDust>());
        }
        public override bool PreKill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<GungnirDust>());
            }

            return true;
        }
    }

    public class GungnirDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = 2f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.scale -= 0.1f;
            dust.alpha += 10;
            if (dust.scale < 0.1f)
            {
                dust.active = false;
            }
            return false;
        }
    }

}