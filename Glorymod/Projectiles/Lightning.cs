using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Mono.CompilerServices.SymbolWriter;

namespace Glorymod.Projectiles
{
    public class Line
    {
        public Vector2 A;
        public Vector2 B;
        public float Thickness;

        public Line() { }
        public Line(Vector2 a, Vector2 b, float thickness = 1)
        {
            A = a;
            B = b;
            Thickness = thickness;
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {

            Vector2 tangent = B - A;
            float rotation = (float)Math.Atan2(tangent.Y, tangent.X);

            const float ImageThickness = 8;
            float thicknessScale = Thickness / ImageThickness;

            Texture2D HalfCircle = ModContent.GetTexture("Glorymod/Projectiles/HalfCircle");
            Texture2D LightningSegment = ModContent.GetTexture("Glorymod/Projectiles/LightningSegment");

            Vector2 capOrigin = new Vector2(HalfCircle.Width, HalfCircle.Height / 2f);
            Vector2 middleOrigin = new Vector2(0, LightningSegment.Height / 2f);
            Vector2 middleScale = new Vector2(tangent.Length(), thicknessScale);

            spriteBatch.Draw(LightningSegment, A, null, color, rotation, middleOrigin, middleScale, SpriteEffects.None, 0f);
            spriteBatch.Draw(HalfCircle, A, null, color, rotation, capOrigin, thicknessScale, SpriteEffects.None, 0f);
            spriteBatch.Draw(HalfCircle, B, null, color, rotation + MathHelper.Pi, capOrigin, thicknessScale, SpriteEffects.None, 0f);

            Player player = Main.LocalPlayer;
            Rectangle rectangle = new Rectangle((int)(A.X + Main.screenPosition.X), (int)(A.Y + Main.screenPosition.Y), (int)tangent.X, (int)Thickness);
            if (rectangle.Intersects(player.Hitbox)) 
            {
                Main.LocalPlayer.Hurt(PlayerDeathReason.ByCustomReason(player.name + " rode the lightning"), 80, -Main.LocalPlayer.direction);
            }
        }
    }

    public class Lightning
    {
        public List<Line> Segments = new List<Line>();
        public float Alpha { get; set; }
        public float FadeOutRate { get; set; }
        public Color Tint { get; set; }
        public Rectangle hitbox;
        Vector2 Source;
        Vector2 Dest;


        public bool IsComplete { get { return Alpha <= 0; } }

        static Random rand = new Random();

        public Lightning(Vector2 source, Vector2 dest, Color color)
        {
            Segments = CreateBolt(source, dest, 3);
            Tint = color;
            Alpha = 1f;
            FadeOutRate = 0.03f;
            Source = source + Main.screenPosition;
            Dest = Main.MouseWorld;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Alpha <= 0)
                return;

            foreach (var segment in Segments)
            {
                segment.Draw(spriteBatch, Tint * (Alpha * 0.6f));
            }
        }

        public virtual void Update()
        {
            Alpha -= FadeOutRate;
        }
        protected static List<Line> CreateBolt(Vector2 source, Vector2 dest, float thickness)
        {
            var results = new List<Line>();
            Vector2 tangent = dest - source;
            Vector2 normal = Vector2.Normalize(new Vector2(tangent.Y, -tangent.X));
            float length = tangent.Length();

            List<float> positions = new List<float>();
            positions.Add(0);

            for (int i = 0; i < length / 4; i++)
                positions.Add(Rand(0, 1));

            positions.Sort();

            const float Sway = 60;
            const float Jaggedness = 1 / Sway;

            Vector2 prevPoint = source;
            float prevDisplacement = 0;
            for (int i = 1; i < positions.Count; i++)
            {
                float pos = positions[i];

                // used to prevent sharp angles by ensuring very close positions also have small perpendicular variation.
                float scale = (length * Jaggedness) * (pos - positions[i - 1]);

                // defines an envelope. Points near the middle of the bolt can be further from the central line.
                float envelope = pos > 0.95f ? 20 * (1 - pos) : 1;

                float displacement = Rand(-Sway, Sway);
                displacement -= (displacement - prevDisplacement) * (1 - scale);
                displacement *= envelope;

                Vector2 point = source + pos * tangent + displacement * normal;
                results.Add(new Line(prevPoint, point, thickness));
                prevPoint = point;
                prevDisplacement = displacement;
            }

            results.Add(new Line(prevPoint, dest, thickness));

            return results;
        }

        private static float Rand(float min, float max)
        {
            return (float)rand.NextDouble() * (max - min) + min;
        }
    }


    public class LightningProjectile : ModProjectile
    {
        public override string Texture => "Glorymod/NPCs/WormFixer";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Voltaic Lightning");
        }
        public override void SetDefaults()
        {
            projectile.tileCollide = false;
            projectile.aiStyle = 0;
            projectile.timeLeft = 200;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.damage = 10;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 destination = new Vector2(projectile.ai[0], projectile.ai[1]);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, null, Main.GameViewMatrix.ZoomMatrix);
            Lightning lightning = new Lightning(projectile.Center - Main.screenPosition, destination - Main.screenPosition, Color.Yellow);
            lightning.Draw(spriteBatch);
        }
    }
}