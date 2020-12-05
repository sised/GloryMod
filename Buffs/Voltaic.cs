using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Projectiles;

namespace Glorymod.Buffs
{
    public class Voltaic : ModBuff
    {
        int idk;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Voltaic");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            Dust dust;
            dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, 20, 0f, 0f, 0, new Color(255, 255, 255), 0.5f)];
            idk++;
            if (idk > 5)
            {
                if (npc.life > 1)
                {
                    npc.life --;
                }
                else npc.StrikeNPCNoInteraction(1, 0, -npc.direction, false, false);
                idk = 0;
            }
        }
    }

}