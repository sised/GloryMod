﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Glorymod.Projectiles
{
    public class EoWfire : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.width = 14;
            projectile.height = 14;
            projectile.tileCollide = false;
            projectile.timeLeft = 700;

        }
        public override void AI()
        {


            Vector2 position = projectile.oldPosition;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (++projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 2)
                {
                    projectile.frame = 0;
                }
            }
        }

    }
}
