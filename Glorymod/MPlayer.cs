using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Glorymod;
using Microsoft.Xna.Framework;
namespace Glorymod
{
    
    // This class stores necessary player info for our custom damage class, such as damage multipliers and additions to knockback and crit.
    public class MPlayer : ModPlayer
    {
        public bool isWearingNeonCanister = false;
        
        int timer;
        public static MPlayer ModPlayer(Player player)
        {
           
            return player.GetModPlayer<MPlayer>();
            
        }

        // Vanilla only really has damage multipliers in code
        // And crit and knockback is usually just added to
        // As a modder, you could make separate variables for multipliers and simple addition bonuses
        public override void ResetEffects()
        {
            
            isWearingNeonCanister = false;
        }
        public override void PreUpdate()
        {
            
            if (player.dead)
            {
                
                player.respawnTimer -= 2;
            }
            
            if (timer < 250)
            {
                timer++;
            }
            else timer = 0;
            if(!Main.expertMode && timer > 249)
            { 
                Main.NewText("Please enter an expert mode world. ( Glory Mod )", 0, 245, 24);
                player.KillMe(PlayerDeathReason.ByOther(1), 10.0, 0);
                timer = 0;
            }
        }
    }
}
