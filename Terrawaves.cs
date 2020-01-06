using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using System;

namespace Terrawaves
{
	public class Terrawaves : Mod
	{
		internal static Terrawaves instance;
        public static Texture2D texture;

        public void TerrawavesMod()
		{
			base.Properties = new ModProperties
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}

		public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            ModLoader.GetMod("Terrawaves");
            if (Main.myPlayer != -1 && !Main.gameMenu && Main.musicVolume != 0f)
            {
                if (Main.LocalPlayer.active && Main.raining)
                {
                    music = base.GetSoundSlot(SoundType.Music, "Sounds/Music/Rain");
                    priority = MusicPriority.BiomeLow;
                }
                if (Main.LocalPlayer.active && Main.bloodMoon)
                {
                    music = base.GetSoundSlot(SoundType.Music, "Sounds/Music/BloodMoon");
                    priority = MusicPriority.BiomeLow;
                }
                bool flag = false;
                bool flag2 = false;
                NPC npc = new NPC();
                for (var a = 0; a < 200; a++)
                {
                    if (Main.npc[a].active)
                    {
                        if (Main.npc[a].type == NPCID.EyeofCthulhu)
                        {
                            flag = true;
                            npc = Main.npc[a];
                        }
                        if (Main.npc[a].type == NPCID.KingSlime)
                        {
                            flag2 = true;
                            npc = Main.npc[a];
                        }
                    }
                }
                if (Main.LocalPlayer.active && flag)
                {
                    double num = (Main.expertMode ? 1.5385 : 2);
                    if (npc.life > (int)((double)npc.lifeMax / num))
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/EyeOfCthulhu1");
                    }
                    else
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/EyeOfCthulhu2");
                    }
                    priority = MusicPriority.BossHigh;
                }
                if (Main.LocalPlayer.active && flag2)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/KingSlime");
                    priority = MusicPriority.BossHigh;
                }
            }
        }

        public override void Load()
        {
            Terrawaves.instance = this;
            if (!Main.dedServ)
			{
				base.AddMusicBox(base.GetSoundSlot(SoundType.Music, "Sounds/Music/BloodMoon"), base.ItemType("EerieMusicBox"), base.TileType("CDMusicBox"), 0);
                base.AddMusicBox(base.GetSoundSlot(SoundType.Music, "Sounds/Music/Rain"), base.ItemType("RainMusicBox"), base.TileType("SFMusicBox"), 0);
            }
        }
	}  
}