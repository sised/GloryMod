using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Glorymod;
using Steamworks;
using Glorymod.NPCs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.ModLoader.Config;

namespace Glorymod
{
	class Glorymod : Mod
	{
        
		public Glorymod()
		{
		}
        public override void Close()
        {
            // Fix a tModLoader bug.
            var slots = new int[] {
                GetSoundSlot(SoundType.Music, "Sounds/Music/EoCt"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/IncreasedEfficency"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/UpgradeToIntellect"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/ClearAsGlass"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/FromTheCore"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/Existential"),
            };
            foreach (var slot in slots) // Other mods crashing during loading can leave Main.music in a weird state.
            {
                if (Main.music.IndexInRange(slot) && Main.music[slot]?.IsPlaying == true)
                {
                    Main.music[slot].Stop(Microsoft.Xna.Framework.Audio.AudioStopOptions.Immediate);
                }
            }

            base.Close();
        }
        public static Texture2D vanillaWOFTexture;
        public static Texture2D vanillaWOFHeadTexture;
        public static Texture2D boneArmTexture;
        public static Texture2D boneArm2Texture;
        public override void Unload()
        {
            boneArmTexture = null;
            boneArm2Texture = null;
            vanillaWOFTexture = null;
            vanillaWOFHeadTexture = null;
        }
        public override void PreUpdateEntities()
        {
            
            if (Main.netMode != NetmodeID.Server)
            {
                if (NPC.AnyNPCs(ModContent.NPCType<EoW1>()) && !Main.gameMenu)
                {
                    Filters.Scene.Activate("WolferShader");

                    // Updating a filter
                    Filters.Scene["WolferShader"].GetShader();


                }
                else
                {
                    Filters.Scene["WolferShader"].Deactivate();
                }


                if (NPC.AnyNPCs(ModContent.NPCType<Corruption>()) && !Main.gameMenu)
                {
                    Filters.Scene.Activate("CorruptionShader");

                    // Updating a filter
                    Filters.Scene["CorruptionShader"].GetShader();


                }
                else
                {
                    Filters.Scene["CorruptionShader"].Deactivate();
                }
            }
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
            {
                return;
            }
            if (NPC.AnyNPCs(ModContent.NPCType<Brain>()) && !Main.gameMenu)
            {
                if(NPC.AnyNPCs(ModContent.NPCType<SuperCreeper>()) || NPC.AnyNPCs(ModContent.NPCType<SuperCreeper2>()) || NPC.AnyNPCs(ModContent.NPCType<SuperCreeper3>()))
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/IncreasedEfficency");
                }
                else
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/UpgradeToIntellect");
                }
                priority = MusicPriority.BossMedium;
            }
            if (NPC.AnyNPCs(ModContent.NPCType<Corruption>()) && !Main.gameMenu)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/Existential");
                priority = MusicPriority.BossHigh;
            }
            if (NPC.AnyNPCs(ModContent.NPCType<EoW1>()) && !Main.gameMenu)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/ClearAsGlass");
                priority = MusicPriority.BossMedium;
            }
            if (Mworld.Menace && NPC.AnyNPCs(NPCID.WallofFlesh) && !Main.gameMenu)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/FromTheCore");
                priority = MusicPriority.BossMedium;
            }
        }
        public override void Load()
        {
            On.Terraria.NPC.Collision_DecideFallThroughPlatforms += NPC_Collision_DecideFallThroughPlatforms1;
            vanillaWOFHeadTexture = Main.npcHeadBossTexture[22];
            vanillaWOFTexture = Main.npcTexture[NPCID.WallofFlesh];
            if (1 == 1) //supposed to test for menace mode
            {
                Main.instance.LoadGore(134);
                Main.goreTexture[134] = GetTexture("NPCs/WormFixer");
                Main.instance.LoadGore(135);
                Main.goreTexture[135] = GetTexture("NPCs/WormFixer");

                Main.instance.LoadGore(137);
                Main.goreTexture[137] = GetTexture("Gores/WoFgore2");

                Main.instance.LoadGore(138);
                Main.goreTexture[138] = GetTexture("Gores/WoFgore1");
                //Skipping gore #139 cause that's exclusive to WoF's eye
                Main.instance.LoadGore(140);
                Main.goreTexture[140] = GetTexture("Gores/WoFgore6");

                Main.instance.LoadGore(141);
                Main.goreTexture[141] = GetTexture("Gores/WoFgore4");

                Main.instance.LoadGore(142);
                Main.goreTexture[142] = GetTexture("Gores/WoFgore5");

                Main.instance.LoadGore(136);
                Main.goreTexture[136] = GetTexture("NPCs/WormFixer");
                Main.npcHeadBossTexture[22] = GetTexture("NPCs/BasaltBarricade_Head_Boss");
                Main.instance.LoadNPC(NPCID.WallofFlesh);
                Main.npcTexture[NPCID.WallofFlesh] = GetTexture("NPCs/WoFmouth");

                Main.wofTexture = GetTexture("NPCs/WallOfFlesh");
            }
            else
            {
                /*if (ModContent.GetInstance<GloriousConfig>().MenaceMode)
                {
                    Main.npcHeadBossTexture[22] = GetTexture("Terraria/NPC_Head_Boss_22");
                    Main.instance.LoadNPC(NPCID.WallofFlesh);
                    Main.npcTexture[NPCID.WallofFlesh] = GetTexture("Terraria/NPC_113");
                    Main.wofTexture = GetTexture("Terraria/WallOfFlesh");

                    Main.instance.LoadNPC(NPCID.SkeletronHead);
                    Main.npcTexture[NPCID.SkeletronHead] = GetTexture("Terraria/NPC_" + NPCID.SkeletronHead);
                    Main.instance.LoadNPC(NPCID.SkeletronHand);
                    Main.npcTexture[NPCID.SkeletronHand] = GetTexture("Terraria/NPC_" + NPCID.SkeletronHand);
                    Main.boneArmTexture = GetTexture("Terraria/Arm_Bone");
                }*/
            }
            if (Main.netMode != NetmodeID.Server)
            {
                // First, you load in your shader file.
                // You'll have to do this regardless of what kind of shader it is,
                // and you'll have to do it for every shader file.
                // This example assumes you have both armour and screen shaders.

                Ref<Effect> SWolferShader = new Ref<Effect>(GetEffect("Effects/WolferShader"));
                Ref<Effect> SCorruptionShader = new Ref<Effect>(GetEffect("Effects/CorruptionShader"));
                // To add a dye, simply add this for every dye you want to add.
                // "PassName" should correspond to the name of your pass within the *technique*,
                // so if you get an error here, make sure you've spelled it right across your effect file.


                // If your dye takes specific parameters such as colour, you can append them after binding the shader.
                // IntelliSense should be able to help you out here.   


                // To bind a miscellaneous, non-filter effect, use this.
                // If you're actually using this, you probably already know what you're doing anyway.


                // To bind a screen shader, use this.
                // EffectPriority should be set to whatever you think is reasonable.   

                Filters.Scene["WolferShader"] = new Filter(new ScreenShaderData(SWolferShader, "PixelShaderFunction"), EffectPriority.Medium);
                Filters.Scene["CorruptionShader"] = new Filter(new ScreenShaderData(SCorruptionShader, "PixelShaderFunction"), EffectPriority.High);
            }

        }
        private bool NPC_Collision_DecideFallThroughPlatforms1(On.Terraria.NPC.orig_Collision_DecideFallThroughPlatforms orig, NPC self)
        {
            bool other = false;
            if (self.type == ModContent.NPCType<NPCs.NeonTyrant>() && self.target >= 0 && Main.player[self.target].position.Y > self.position.Y + self.height)
                other = true;
            return orig(self) || other;
        }
    }
}
