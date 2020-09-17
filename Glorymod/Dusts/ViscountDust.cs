using Terraria;
using Terraria.ModLoader;

namespace Glorymod.Dusts
{
	public class ViscountCyan : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale = 2f;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.scale -= 0.1f;
			dust.alpha += 10;
			if (dust.scale < 0.1f)
			{
				dust.active = false;
			}
			return false;
		}
	}

	public class ViscountRed : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale = 2f;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.scale -= 0.1f;
			dust.alpha += 10;
			if (dust.scale < 0.1f)
			{
				dust.active = false;
			}
			return false;
		}
	}

	public class ViscountPurple : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale = 2f;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.scale -= 0.1f;
			dust.alpha += 10;
			if (dust.scale < 0.1f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}