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
using System.Runtime.Remoting.Messaging;

namespace Glorymod.Projectiles
{
    public class PhantomIntellect : ModProjectile
    {
        int timer;
        bool spawned;
        int timer2;
        public override void SetStaticDefaults()
        {
            
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.width = 114;
            projectile.height = 146;

            projectile.aiStyle = -1;
            projectile.tileCollide = false;
        }
        Vector2 direction = new Vector2(5, 5).RotatedBy(MathHelper.ToDegrees(Main.rand.Next(360)));
        public override void AI()
        {
            projectile.alpha += 5;
            if(projectile.alpha >= 255)
            {
                projectile.active = false;
            }
            if (++projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }
        
    }
}
