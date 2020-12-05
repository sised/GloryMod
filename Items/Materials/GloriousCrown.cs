using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Glorymod;
using System.Diagnostics;

namespace Glorymod.Items.Materials
{
    
    public class GloriousCrown : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glorious Crown");
            Tooltip.SetDefault("Enables/Disables Menace mode\nReplaces Vanilla bosses with much more difficult, glorious bosses\nThe guide immediately respawns in your spawn location\nMost bosses (with the exeption of WoF, LC and ML) Won't drop other Mod's Drops");
        }
        public override void SetDefaults()
        {
            item.useStyle = 4;
            item.width = 18;
            item.height = 12;
            item.rare = -12;
            item.useAnimation = 20;
            item.useTime = 20;
            item.UseSound = SoundID.Item113;
        }

        public override bool UseItem(Player player)
        {
            
            
            if (Main.expertMode && !player.GetModPlayer<MPlayer>().bossalive)
            {
                switch (Mworld.Menace)
                {
                    case false:
                        {
                            Mworld.Menace = true;
                            Main.NewText("Menace mode is now active, reload mods for the game to function properly", 237, 221, 114);
                            break;
                        }
                    case true:
                        {
                            Mworld.Menace = false;
                            Main.NewText("Menace mode is no longer active,  reload mods for the game to function properly", 237, 221, 114);
                            break;
                        }
                }
            }
            else if(!Main.expertMode)
            {
                Main.NewText("Menace mode cannot be activated in puny normal mode", 237, 221, 114);
            }
            else if(player.GetModPlayer<MPlayer>().bossalive)
            {
                Main.NewText("Did you seriously expect this to work when a boss is alive?", 237, 221, 114);
            }
            return true;
        }
    }
}
