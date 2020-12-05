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
    public class IonExhaust : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ion Exhaust");
        }
        public override void SetDefaults()
        {
            projectile.aiStyle = 0;
            projectile.width = 46;
            projectile.height = 26;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.alpha = 240;
            projectile.tileCollide = false;
            projectile.timeLeft = 500;
        }
        public override void AI()
        {
            projectile.alpha -= 8;
        }
    }
}