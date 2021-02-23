using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Glorymod.NPCs
{
    public class Lust : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lust");
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 40000;
            npc.defense = 36;
            npc.knockBackResist = 0;
            npc.aiStyle = -1;
            npc.damage = 100;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.width = 156;
            npc.height = 156;
            npc.HitSound = SoundID.NPCHit1;
        }
        public override void AI()
        {
            npc.TargetClosest();
            Player player = Main.player[npc.target];
            Vector2 between = player.Center - npc.Center;
            npc.rotation = between.RotatedBy(MathHelper.ToRadians(90)).ToRotation();

        }
    }
}
