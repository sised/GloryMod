using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Glorymod.Projectiles;

namespace Glorymod.NPCs
{
    public class NeonGellatin : ModNPC
    {
        int timer;
        int timer2;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Gellatin");
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 125;
            npc.defense = 10;
            npc.aiStyle = -1;
            npc.height = 32;
            npc.width = 32;
            npc.damage = 40;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0f;
            npc.dontTakeDamage = true;
            npc.alpha = 165;
            npc.noGravity = true;
            npc.friendly = true;
            npc.value = 112;
        }
        public override bool CheckDead()
        {
            for (int i = 0; i < 30; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = npc.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 87, 0f, 0f, 0, new Color(255, 176, 0), 1.118421f)];
            }
            return true;
        }
        public override void AI()
        {
            timer++;
            if(timer > 200)
            {
                npc.friendly = false;
                npc.alpha = 0;
                npc.dontTakeDamage = false;
                timer2++;
                if(timer2 > 60)
                {
                    npc.life -= 4;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, ModContent.ProjectileType<NeonBeam>(), 20, 2);
                    timer2 = 0;
                }
            }
        }
    }
}
