using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Glorymod.Buffs;
using Microsoft.Xna.Framework;
namespace Glorymod.Projectiles
{
    public class NightmareSpawn : ModProjectile
    {
        int timer;
        public override void SetStaticDefaults()
        {
            // Denotes that this projectile is a pet or minion
            Main.projPet[projectile.type] = true;
            // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            // Don't mistake this with "if this is true, then it will automatically home". It is just for damage reduction for certain NPCs
            ProjectileID.Sets.Homing[projectile.type] = true;
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            // Only controls if it deals damage to enemies on contact (more on that later)
            projectile.friendly = true;
            // Only determines the damage type
            projectile.minion = true;
            // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
            projectile.minionSlots = 1f;
            // Needed so the minion doesn't despawn on collision with enemies or tiles
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
            projectile.timeLeft = 10;

            Player player = Main.player[projectile.owner];
            if (!player.HasBuff(ModContent.BuffType<Spawned>()))
            {
                projectile.timeLeft = 0;
            }
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<Spawned>());
            }
            if (player.HasBuff(ModContent.BuffType<Spawned>()))
            {
                projectile.timeLeft = 2;
            }
            Vector2 idlePosition = player.Center;
            idlePosition.Y -= 48f;
            float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
            idlePosition.X += minionPositionOffsetX;
            Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
            float distanceToIdlePosition = vectorToIdlePosition.Length();
            // Starting search distance
            float distanceFromTarget = 700f;
            Vector2 targetCenter = projectile.position;
            bool foundTarget = false;
            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, projectile.Center);
                // Reasonable distance away so it doesn't target across multiple screens
                if (between < 2000f)
                {
                    distanceFromTarget = between;
                    targetCenter = npc.Center;
                    foundTarget = true;
                    if (timer > 50)
                    {
                        Vector2 noscope = npc.Center - projectile.Center;
                        noscope.Normalize();
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, noscope.X * 10f, noscope.Y * 10f, ModContent.ProjectileType<NightmareProjectile>(), projectile.damage, 5, Main.myPlayer);
                        timer = 0;
                    }
                }
            }
            if (timer < 500)
            {
                timer++;
            }
            
            if (!foundTarget)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, projectile.Center);
                        bool closest = Vector2.Distance(projectile.Center, npc.Center) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
                        if (((closest && inRange) || !foundTarget) && lineOfSight)
                        {
                            
                            if (timer > 50)
                            {
                                Vector2 noscope = npc.Center - projectile.Center;
                                noscope.Normalize();
                                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, noscope.X * 10f, noscope.Y * 10f, ModContent.ProjectileType<NightmareProjectile>(), projectile.damage, 5, Main.myPlayer);
                                timer = 0;
                            }
                        }
                    }
                }
            }
            float speed = 8f;
            float inertia = 60f;
            Vector2 direction = idlePosition - projectile.Center;
            direction.Normalize();
            direction *= speed;
            projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
        }
    }
    public class TerrorInfant : ModProjectile
    {
        int timer;
        public override void SetStaticDefaults()
        {
            // Denotes that this projectile is a pet or minion
            Main.projPet[projectile.type] = true;
            // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            // Don't mistake this with "if this is true, then it will automatically home". It is just for damage reduction for certain NPCs
            ProjectileID.Sets.Homing[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            // Only controls if it deals damage to enemies on contact (more on that later)
            projectile.friendly = true;
            // Only determines the damage type
            projectile.minion = true;
            // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
            projectile.minionSlots = 1f;
            // Needed so the minion doesn't despawn on collision with enemies or tiles
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            projectile.timeLeft = 10;

            Player player = Main.player[projectile.owner];
            if (!player.HasBuff(ModContent.BuffType<Infanted>()))
            {
                projectile.timeLeft = 0;
            }
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<Infanted>());
            }
            if (player.HasBuff(ModContent.BuffType<Infanted>()))
            {
                projectile.timeLeft = 2;
            }
            Vector2 idlePosition = player.Center;
            idlePosition.Y -= 70f;
            float minionPositionOffsetX = 0;
            idlePosition.X += minionPositionOffsetX;
            Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
            float distanceToIdlePosition = vectorToIdlePosition.Length();
            // Starting search distance
            float distanceFromTarget = 700f;
            Vector2 targetCenter = projectile.position;
            bool foundTarget = false;
            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, projectile.Center);
                // Reasonable distance away so it doesn't target across multiple screens
                if (between < 2000f)
                {
                    distanceFromTarget = between;
                    targetCenter = npc.Center;
                    foundTarget = true;
                    if (timer > 50)
                    {
                        Vector2 noscope = npc.Center - projectile.Center;
                        noscope.Normalize();
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, noscope.X * 10f, noscope.Y * 10f, ModContent.ProjectileType<TerrorBeam>(), projectile.damage, 5, Main.myPlayer);
                        timer = 0;
                    }
                }
            }
            if (timer < 500)
            {
                timer++;
            }

            if (!foundTarget)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {

                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, projectile.Center);
                        bool closest = Vector2.Distance(projectile.Center, npc.Center) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
                        if (((closest && inRange) || !foundTarget) && lineOfSight)
                        {

                            if (timer > 50)
                            {
                                Vector2 noscope = npc.Center - projectile.Center;
                                noscope.Normalize();
                                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, noscope.X * 10f, noscope.Y * 10f, ModContent.ProjectileType<TerrorBeam>(), projectile.damage, 5, Main.myPlayer);
                                timer = 0;
                            }
                        }
                    }
                }
            }
            float speed = 8f;
            float inertia = 60f;
            Vector2 direction = idlePosition - projectile.Center;
            direction.Normalize();
            direction *= speed;
            projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
        }
    }

}
