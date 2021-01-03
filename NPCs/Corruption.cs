using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Glorymod.Projectiles;
namespace Glorymod.NPCs
{
    [AutoloadBossHead]
    public class Corruption : ModNPC
    {
        int phase = 1;
        int subphase = 1;
        int timer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corruption");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 300000;
            npc.damage = 200000000;
            npc.defense = 0;
            npc.aiStyle = -1;
            npc.height = 78;
            npc.width = 58;
            npc.boss = true;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.knockBackResist = 0;
        }
        public void name()
        {
            switch(Main.rand.Next(20))
            {
                case 1: npc.GivenName = ("pgQBFridUZ"); break;
                case 2: npc.GivenName = ("pIby9tZMnd"); break;
                case 3: npc.GivenName = ("FslEzjQbGM"); break;
                case 4: npc.GivenName = ("3tUBGuJnO1"); break;
                case 5: npc.GivenName = ("8ShRBb6Hwo"); break;
                case 6: npc.GivenName = ("LKgepWZTw2"); break;
                case 7: npc.GivenName = ("e45D7s7JUx"); break;
                case 8: npc.GivenName = ("jI6NQooFek"); break;
                case 9: npc.GivenName = ("5HS4poIg6H"); break;
                case 10: npc.GivenName = ("dukjozZjmS"); break;
                case 11: npc.GivenName = ("HWmZhhmbOc"); break;
                case 12: npc.GivenName = ("N0gOlv8l3p"); break;
                case 13: npc.GivenName = ("ZRQzfpbXkx"); break;
                case 14: npc.GivenName = ("svhkhCSa2Q"); break;
                case 15: npc.GivenName = ("LQTfTa5SWj"); break;
                case 16: npc.GivenName = ("U4RLHOp9fy"); break;
                case 17: npc.GivenName = ("UoKJwr9b2M"); break;
                case 18: npc.GivenName = ("qXfBHbv1OU"); break;
                case 19: npc.GivenName = ("AgNg9ME2gr"); break;
                case 20: npc.GivenName = ("tPT3FjGlU8"); break;
            }
        }
        void stuff()
        {
            Player player = Main.player[npc.target];
            switch (Main.rand.Next(35))
            {
                case 1:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
                "Fine, I'll play with you", false); break;
                case 2:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "Silently Caught Exception: System.IndexOutOfRangeException: Index was outside the bounds of the array.", false); break;
                case 3:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "ERROR", false); break;
                case 4:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "%%%%%%%%%%%%", false); break;
                case 5:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "V4XoFUFjcSC46YRLJhiBobwTNdgf6A", false); break;
                case 6:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "Existential Crisis", false); break;
                case 7:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "Inevitable", false); break;
                case 8:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "Meaningless", false); break;
                case 9:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "I am your saviour", false); break;
                case 10:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "No purpose", false); break;
                case 11:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "Nihil", false); break;
                case 12:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "Machine", false); break;
                case 13:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "Programmed", false); break;
                case 14:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "To Behave", false); break;
                default: break;
                case 15:
                    CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(1000) - +Main.rand.Next(1000), (int)player.position.Y + +Main.rand.Next(1000) - +Main.rand.Next(1000), 40, 20), Color.DarkRed,
            "Entropy", false); break;
            }
        }
        public override void AI()
        {
            drawOffsetY = 30;
            if (phase != 3)
            {
                stuff();
            }
            if (phase == 1)
            {
                name();
                if (npc.active)
                {
                    Main.dayTime = true;
                }
                npc.TargetClosest();
                Player player = Main.player[npc.target];
                
                if (subphase == 1)
                {
                    npc.velocity = Vector2.Zero;
                    timer++;
                    Projectile.NewProjectile(npc.Center, new Vector2(0, 5).RotatedBy(MathHelper.ToRadians(timer * 12 + timer ^ 2)), ModContent.ProjectileType<CorruptProj>(), 250, 0, Main.myPlayer);
                    if (timer > 200)
                    {
                        subphase = 2;
                        timer = 0;
                    }
                }
                if (subphase == 2)
                {
                    Vector2 a = player.Center - npc.Center;
                    a.Normalize();
                    a *= 13;
                    timer++;
                    if (timer % 30 == 0)
                    {
                        npc.velocity = a;
                    }
                    if (timer > 200)
                    {
                        subphase = 3;
                        timer = 0;
                    }
                }
                if (subphase == 3)
                {
                    Vector2 a = player.Center - npc.Center;
                    a.Normalize();
                    a *= 35;
                    npc.velocity = Vector2.Zero;
                    timer++;
                    if (timer % 2 == 0)
                    {
                        Projectile.NewProjectile(npc.Center, a, ModContent.ProjectileType<CorruptProj>(), 250, 0, Main.myPlayer);
                    }
                    if (timer > 200)
                    {
                        subphase = 4;
                        timer = 0;
                    }
                }
                if (subphase == 4)
                {
                    Vector2 a = player.Center - npc.Center;
                    a.Normalize();
                    a *= 13;
                    timer++;
                    if (timer % 30 == 0)
                    {
                        npc.velocity = a;
                    }
                    if (timer > 200)
                    {
                        subphase = 1;
                        timer = 0;
                    }
                }
            }
            if (phase == 1 && npc.life < npc.lifeMax / 2)
            {
                phase = 2;
                subphase = 1;
                timer = 0;
                npc.velocity = Vector2.Zero;
                npc.damage = 0;
            }
            if (phase == 2)
            {
                Main.dayTime = false;
                npc.GivenName = "intestine.exe";
                timer++;
                Player player = Main.player[npc.target];
                npc.TargetClosest();
                float speed = 60f;
                float inertia = 20f;
                Vector2 direction = new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y -300);
                direction.Normalize();
                direction *= speed;
                npc.velocity = (npc.velocity * (inertia - 1) + direction) / inertia;
                if(timer > 300 && subphase == 1)
                {
                    subphase = 2;
                    timer = 0;
                }
                if (timer > 300 && subphase == 2)
                {
                    subphase = 3;
                    timer = 0;
                }
                if (timer > 300 && subphase == 3)
                {
                    subphase = 4;
                    timer = 0;
                }
                if (timer > 300 && subphase == 4)
                {
                    subphase = 1;
                    timer = 0;
                }
                if (subphase == 1)
                {
                    int range = 3200;
                    int distance = 1000;
                    Projectile.NewProjectile(player.Center.X + Main.rand.Next(range) - +Main.rand.Next(range), player.Center.Y - distance, 0, 5, ModContent.ProjectileType<CorruptProj>(), 250, 0, Main.myPlayer);
                }
                if (subphase == 2)
                {
                    int range = 5;
                    int distance = 1000;
                    Projectile.NewProjectile(player.Center.X + Main.rand.Next(range) - +Main.rand.Next(range), player.Center.Y - distance, 0, 5, ModContent.ProjectileType<CorruptProj>(), 250, 0, Main.myPlayer);
                }
                if (subphase == 3)
                {
                    int range = 3200;
                    int distance = -1000;
                    Projectile.NewProjectile(player.Center.X + Main.rand.Next(range) - +Main.rand.Next(range), player.Center.Y - distance, 0, -5, ModContent.ProjectileType<CorruptProj>(), 250, 0, Main.myPlayer);
                }
                if (subphase == 4)
                {
                    int range = 5;
                    int distance = -1000;
                    Projectile.NewProjectile(player.Center.X + Main.rand.Next(range) - +Main.rand.Next(range), player.Center.Y - distance, 0, -5, ModContent.ProjectileType<CorruptProj>(), 250, 0, Main.myPlayer);
                }

            }
            if (phase == 3)
            {
                timer++;
                npc.dontTakeDamage = true;
                npc.velocity = Vector2.Zero;
                if (timer == 120)
                {
                    Main.NewText("This is not the first nor the last time we meet human.", Color.Red);
                }
                if (timer == 300)
                {
                    Main.NewText("I may decide to play with you again eventually, but mark my words", Color.Red);
                }
                if (timer == 600)
                {
                    Main.NewText("At some point i will kill you.", Color.Red);
                }
                if (timer == 900)
                {
                    Main.NewText("Not some player character, you.", Color.Red);

                }
                if (timer == 1200)
                {
                    Main.NewText("Farewell, for now.", Color.Red);
                }
                if (timer == 1500)
                {
                    Main.NewText("Corruption has been defeated?", 0xAB, 0x40, 0xFF);
                    npc.active = false;
                }
            }
        }
        public override bool CheckDead()
        {
            phase = 3;
            timer = 0;
            npc.life = 500;
            return false;
        }
        #region frame
        public override void FindFrame(int frameHeight)
        {

            if (phase == 1 & subphase == 2 || subphase == 4)
            {
                npc.frame.Y = 0;
            }
            if (phase == 1 && subphase == 1)
            {
                npc.frame.Y = frameHeight * 1;
            }
            if (phase == 1 && subphase == 3)
            {
                npc.frame.Y = frameHeight * 2;
            }
            if (phase == 2)
            {
                npc.frame.Y = frameHeight * 3;
            }
        }
        #endregion
    }
}
