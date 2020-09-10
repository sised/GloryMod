using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Projectiles;
using IL.Terraria.DataStructures;

namespace Glorymod.Buffs
{
    public class BlazingInferno : ModBuff
    {
        int timer;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blazing Inferno");
            Description.SetDefault("You are too far away from the Basalt Barricade!");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = Main.LocalPlayer.Center;
            dust = Main.dust[Terraria.Dust.NewDust(player.position, player.width, player.height, 91, 0f, 0f, 0, new Color(255, 176, 0), 1.644737f)];

            timer++;
            if(timer > 3)
            {
                player.statLife--;
                timer = 0;
            }
        }
    }

}