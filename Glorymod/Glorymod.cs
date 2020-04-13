using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Glorymod
{
	class Glorymod : Mod
	{
		public Glorymod()
		{
		}
        public override void Load()
        {
            Main.instance.LoadNPC(50); // First load the tile texture
            Main.npcTexture[50] = GetTexture("NPCs/NeonTyrant"); // Now we change it
        }
    }
}
