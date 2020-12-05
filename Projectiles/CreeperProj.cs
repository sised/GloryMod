using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Threading;
using Glorymod.Projectiles;
using System.Dynamic;
using Glorymod.Items.Materials;
using System.Linq;
using Glorymod.Items.Accessories.PreHm;
using System.Data.SqlTypes;

namespace Glorymod.Projectiles
{
    public class CreeperProj : ModProjectile
    {
        int TimeLeft = 500;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plasma Shot");
        }
        public override void SetDefaults()
        {
            projectile.aiStyle = 0;
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 515;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            TimeLeft--;
            if(TimeLeft < 0)
            {
                projectile.hostile = false;
                projectile.alpha += 25;
            }
            projectile.rotation = projectile.velocity.ToRotation() - MathHelper.ToRadians(90);
        }
    }
}
