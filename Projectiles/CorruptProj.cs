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
    public class CorruptProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("%%%%%%%%%%%%%%%");
        }
        public override void SetDefaults()
        {
            projectile.aiStyle = 0;
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 500;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            if(projectile.timeLeft < 300)
            {
                projectile.velocity *= 1.07f;
            }
            
        }
    }
    
}
