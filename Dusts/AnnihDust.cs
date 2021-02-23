using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Glorymod.Dusts
{
	public class AnnihDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.alpha = 1;
			dust.scale = 1.2f;
			dust.noGravity = true;
		}

		public override bool Update(Dust dust)
		{
			dust.rotation += 0.3f;
			dust.position += dust.velocity;
			dust.alpha += 2;
			return false;
		}
	}
}