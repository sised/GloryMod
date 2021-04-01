using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Projectiles;

namespace Glorymod.Buffs
{
    public class PlasmaVoltaic : ModBuff
    {
        int idk;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Plasma Voltaic");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            idk++;
            Dust dust;
            dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, 20, 0f, 0f, 0, new Color(0, 255, 0), 0.5f)];
            if (npc.life > 1 && idk % 5 == 0 && !npc.dontTakeDamage)
            {
                npc.life--;
            }
            else if (idk % 5 == 0) 
            { 
                npc.StrikeNPCNoInteraction(1, 0, -npc.direction, false, false); 
            }
            Main.NewText(idk.ToString());
        }
    }

}