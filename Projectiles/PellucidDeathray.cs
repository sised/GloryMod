using Glorymod.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Win32;

namespace Glorymod.Projectiles
{
	// The following laser shows a channeled ability, after charging up the laser will be fired
	// Using custom drawing, dust effects, and custom collision checks for tiles
	public class PellucidDeathray : ModProjectile
	{
		int iCarry;
		int warning;
		bool Exist = false;
		float size = 0.3f;
		bool Fade = false;
		NPC npce;
		// This is literally example mod code
		// Use a different style for constant so it is very clear in code when a constant is used

		// The maximum charge value
		private const float MAX_CHARGE = 50f;
		//The distance charge particle from the player center
		private const float MOVE_DISTANCE = 22f;

		// The actual distance is stored in the ai0 field
		// By making a property to handle this it makes our life easier, and the accessibility more readable
		public float Distance
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;	
		}

		// The actual charge value is stored in the localAI0 field
		public float Charge
		{
			get => projectile.localAI[0];
			set => projectile.localAI[0] = value;
		}

		// Are we at max charge? With c#6 you can simply use => which indicates this is a get only property
		public bool IsAtMaxCharge => Charge == MAX_CHARGE;

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.alpha = 150;
			projectile.timeLeft = 310;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			if (projectile.active)
			{
				DrawLaser(spriteBatch, Main.projectileTexture[projectile.type], projectile.Center,
				projectile.velocity, 10, projectile.damage, -1.57f, 1f, 1000f, Color.White, (int)MOVE_DISTANCE);

				return false;
			}
			else return false;
		}

		// The core function of drawing a laser
		public void DrawLaser(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maxDist = 2000f, Color color = default(Color), int transDist = 50)
		{
			if(projectile.active)
			{
				float r = unit.ToRotation() + rotation;

				//Draws the laser 'body'
				for (float i = transDist; i <= Distance; i += step)
				{
					Color c = Color.White;
					var origin = start + i * unit;
					spriteBatch.Draw(texture, origin - Main.screenPosition,
						new Rectangle(0, 40, 26, 44), i < transDist ? Color.Transparent : c, r,
						new Vector2(28 * .5f, 26 * .5f), size, 0, 0);
				}

				// Draws the laser 'head'
				spriteBatch.Draw(texture, start + unit * (transDist - step) - Main.screenPosition,
					new Rectangle(0, 0, 26, 38), Color.White, r, new Vector2(28 * .5f, 26 * .5f), size, 0, 0);
				// Draws the laser 'tail'
				spriteBatch.Draw(texture, start + (Distance + step) * unit - Main.screenPosition,
					new Rectangle(0, 86, 26, 38), Color.White, r, new Vector2(28 * .5f, 26 * .5f), size, 0, 0);
			}
			
		}
		public override bool PreKill(int timeLeft)
		{
			Exist = false;
			Main.npc[iCarry].GetGlobalNPC<GlobalNPCe>().LaserAttached = false;
			projectile.active = false;
			return false;
		}
		// Change the way of collision check of the projectile
		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (projectile.active)
			{
				Player player = Main.player[projectile.owner];
				Vector2 unit = projectile.velocity;
				float point = 0f;
				// Run an AABB versus Line check to look for collisions, look up AABB collision first to see how it works
				// It will look for collisions on the given line using AABB
				return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.Center,
					npce.Center + unit * Distance, 22, ref point);
			}
			else return false;
			// We can only collide if we are at max charge, which is when the laser is actually fired

			
		}

		// Set custom immunity time on hitting an NPC
		// The AI of the projectile
		public override void AI()
		{
			if (projectile.active)
			{
				warning++;
				if (warning > 120)
				{
					if(projectile.hostile == false && !Fade)
					{
						Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 122);
					}
					if(!Fade)
					{
						projectile.hostile = true;
						size = 1;
						if(projectile.timeLeft == 10)
						{
							Fade = true;
						}
					}
					if(Fade)
					{
						size -= 0.1f;
						projectile.hostile = false;
					}
					
				}
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					if (!Exist)
					{
						npce = Main.npc[i];
					}
					else break;
					if (npce.type == ModContent.NPCType<EoW1>() && npce.active && !Main.npc[i].GetGlobalNPC<GlobalNPCe>().LaserAttached)
					{
						if(!Exist)
						{
							Exist = true;
							iCarry = i;
							Main.npc[i].GetGlobalNPC<GlobalNPCe>().LaserAttached = true;
						}
						
						break;
					}

				}
				if(Exist)
				{
					Main.npc[iCarry].GetGlobalNPC<GlobalNPCe>().LaserAttached = true;
					npce = Main.npc[iCarry];
				}
				if(!npce.active)
				{
					projectile.active = false;
				}
				projectile.position.X = npce.position.X + (npce.width / 2) - (projectile.width / 3) - 4;
				projectile.position.Y = npce.position.Y + (npce.height / 2) - (projectile.height / 3) - 4;
				Player player = Main.player[projectile.owner];
				//projectile.position = projectile.Center + projectile.velocity * MOVE_DISTANCE;

				projectile.velocity = new Vector2(0, 1).RotatedBy(npce.rotation + 3.14159f);
				// By separating large AI into methods it becomes very easy to see the flow of the AI in a broader sense
				// First we update player variables that are needed to channel the laser
				// Then we run our charging laser logic
				// If we are fully charged, we proceed to update the laser's position
				// Finally we spawn some effects like dusts and light

				UpdatePlayer(player);

				// If laser is not charged yet, stop the AI here.

				SetLaserPosition(player);
				SpawnDusts(player);
				CastLights();
			}
			
		}

		private void SpawnDusts(Player player)
		{
			if(projectile.active)
			{
				Vector2 unit = projectile.velocity * -1;
				Vector2 dustPos = player.Center + projectile.velocity * Distance;

				for (int i = 0; i < 2; ++i)
				{
					float num1 = projectile.velocity.ToRotation() + (Main.rand.Next(2) == 1 ? -1.0f : 1.0f) * 1.57f;
					float num2 = (float)(Main.rand.NextDouble() * 0.8f + 1.0f);
					Vector2 dustVel = new Vector2((float)Math.Cos(num1) * num2, (float)Math.Sin(num1) * num2);
					Dust dust = Main.dust[Dust.NewDust(dustPos, 0, 0, 226, dustVel.X, dustVel.Y)];
					dust.noGravity = true;
					dust.scale = 1.2f;
					dust = Dust.NewDustDirect(Main.player[projectile.owner].Center, 0, 0, 31,
						-unit.X * Distance, -unit.Y * Distance);
					dust.fadeIn = 0f;
					dust.noGravity = true;
					dust.scale = 0.88f;
					dust.color = Color.Cyan;
				}

				if (Main.rand.NextBool(5))
				{
					Vector2 offset = projectile.velocity.RotatedBy(1.57f) * ((float)Main.rand.NextDouble() - 0.5f) * projectile.width;
					Dust dust = Main.dust[Dust.NewDust(dustPos + offset - Vector2.One * 4f, 8, 8, 31, 0.0f, 0.0f, 100, new Color(), 1.5f)];
					dust.velocity *= 0.5f;
					dust.velocity.Y = -Math.Abs(dust.velocity.Y);
					unit = dustPos - Main.player[projectile.owner].Center;
					unit.Normalize();
					dust = Main.dust[Dust.NewDust(Main.player[projectile.owner].Center + 55 * unit, 8, 8, 31, 0.0f, 0.0f, 100, new Color(), 1.5f)];
					dust.velocity = dust.velocity * 0.5f;
					dust.velocity.Y = -Math.Abs(dust.velocity.Y);
				}
			}
			
		}

		/*
		 * Sets the end of the laser position based on where it collides with something
		 */
		private void SetLaserPosition(Player player)
		{
			if(projectile.active)
			{
				for (Distance = MOVE_DISTANCE; Distance <= 2200f; Distance += 5f)
				{
					var start = projectile.Center + projectile.velocity * Distance;
					if (!Collision.CanHit(projectile.Center, 1, 1, start, 1, 1))
					{
						Distance -= 5f;
						break;
					}
				}
			}
			
		}

		
		private void UpdatePlayer(Player player)
		{
			
			
		}

		private void CastLights()
		{
			if(projectile.active)
			{
				// Cast a light along the line of the laser
				DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
				Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * (Distance - MOVE_DISTANCE), 26, DelegateMethods.CastLight);
			}
			
		}

		public override bool ShouldUpdatePosition() => false;
		/*
		 * Update CutTiles so the laser will cut tiles (like grass)
		 */
		public override void CutTiles()
		{
			if(projectile.active)
			{
				DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
				Vector2 unit = projectile.velocity;
				Utils.PlotTileLine(projectile.Center, projectile.Center + unit * Distance, (projectile.width + 16) * projectile.scale, DelegateMethods.CutTiles);
			}
			
		}
	}
}