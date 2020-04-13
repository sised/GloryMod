using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Glorymod;
using Microsoft.Xna.Framework;
namespace Glorymod
{
    public class GlobalIteme : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
        int timer;
        public override void HoldItem(Item item, Player player)
        {
            if(timer < 102)
            {
                timer++;
            }
            if(player.itemAnimation == player.itemAnimationMax - 1)
            {
                
                if (player.GetModPlayer<MPlayer>().isWearingNeonCanister && item.ranged)
                {
                    int r = Main.rand.Next(4);
                    
                    if (r == 1 && timer > 50) //25%
                    {
                        Vector2 Cu = player.DirectionTo(Main.MouseWorld) * 10f;
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, Cu.X, Cu.Y, ModContent.ProjectileType<Projectiles.NeonBolt>(), 25, 5, Main.myPlayer);
                        timer = 0;
                    }
                }
                
            }
        }
    } 
}
