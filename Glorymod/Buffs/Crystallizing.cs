using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Glorymod.Projectiles;
using IL.Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.Graphics.Effects;
namespace Glorymod.Buffs
{
    public class Crystallizing : ModBuff
    {
        int timer;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Crystallizing");
            Description.SetDefault("You are turning pellucid\nMelee and movement speed decreased");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeSpeed *= 0.5f;
            player.moveSpeed *= 0.5f;
        }
    }

}