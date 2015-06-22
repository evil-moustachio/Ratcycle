using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Ratcycle
{
	public static class ContentHandler
	{
		static Dictionary <string, Texture2D> textures = new Dictionary<string, Texture2D>();
		static Dictionary <string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();
        static Dictionary<string, SoundEffect> soundEffects = new Dictionary<string, SoundEffect>();

		/// <summary>
		/// Sets the content.
		/// </summary>
		public static void SetContent()
		{

			//BACKGROUNDS
			textures.Add ("BackgroundGray", null);
			textures.Add ("BackgroundOrange", null);
			textures.Add ("BackgroundOrangeSmall", null);
			textures.Add ("BackgroundOrangeBig", null);
			textures.Add ("BackgroundStartmenu", null);
			textures.Add ("Background-01", null);
			textures.Add ("Background-02", null);
			textures.Add ("Background-03", null);
			textures.Add ("Background-04", null);
			textures.Add ("Background-05", null);

			//BUTTONS
			textures.Add ("ButtonStart", null);
			textures.Add ("ButtonRestart", null);
			textures.Add ("ButtonChooseLevel", null);
			textures.Add ("ButtonRight", null);
			textures.Add ("ButtonLeft", null);
			textures.Add ("ChooseLevel_Button-01", null);
			textures.Add ("ChooseLevel_Button-02", null);
			textures.Add ("ChooseLevel_Button-03", null);
			textures.Add ("ChooseLevel_Button-04", null);
			textures.Add ("ChooseLevel_Button-05", null);

			//HUD
			textures.Add ("ButtonEsc", null);
			textures.Add ("HealthBarEntity", null);
			textures.Add ("HUDHealthbarRat", null);
			textures.Add ("HUDRat", null);

			//ENTITIES
			textures.Add ("Entity_rat", null);
			textures.Add ("Entity_BinChemical", null);
			textures.Add ("Entity_BinGreen", null);
			textures.Add ("Entity_BinOther", null);
			textures.Add ("Entity_BinPaper", null);
			textures.Add ("Entity_BinPlastic", null);
			textures.Add ("Entity_Garbagetruck", null);
			textures.Add ("monster_NormalChemical", null); //PLACEHOLDER
			textures.Add ("monster_StrongChemical", null); //PLACEHOLDER
			textures.Add ("monster_NormalGreen", null); //PLACEHOLDER
			textures.Add ("monster_StrongGreen", null); //PLACEHOLDER
			textures.Add ("monster_NormalPaper", null); //PLACEHOLDER
			textures.Add ("monster_StrongPaper", null); //PLACEHOLDER
			textures.Add ("monster_NormalPlastic", null); //PLACEHOLDER
			textures.Add ("monster_StrongPlastic", null); //PLACEHOLDER
			textures.Add ("monster_NormalOther", null); //PLACEHOLDER
			textures.Add ("monster_StrongOther", null); //PLACEHOLDER

			//PLACEHOLDERS
			textures.Add("PCSquareButton", null);
			textures.Add("pcInventory", null);

			//FONTS
			fonts.Add ("Aero Matics Display-14", null);
			fonts.Add ("Aero Matics Display-18", null);
			fonts.Add ("Aero Matics Display-24", null);
			fonts.Add ("Aero Matics Display-28", null);
			fonts.Add ("Aero Matics Display-36", null);
			fonts.Add ("Aero Matics Display-48", null);

            //MUSIC
            soundEffects.Add("DeathTheme", null);
            soundEffects.Add("GameTheme", null);
            soundEffects.Add("MainTheme", null);

            //SOUND EFFECTS
            soundEffects.Add ("MonsterHitsRat", null);
            soundEffects.Add ("Correct", null);
            soundEffects.Add ("Wrong", null);
            soundEffects.Add ("Woosj", null);
            soundEffects.Add ("Button", null);
            soundEffects.Add("DeathSpiral", null);
            soundEffects.Add("PickupMonster", null);
            soundEffects.Add("MonsterDie", null);
		}

		/// <summary>
		/// Loads the textures.
		/// </summary>
		/// <param name="content">Content.</param>
		public static void LoadContent(ContentManager content)
		{
			String device = GetDevice ();
			for (int i = textures.Count - 1; i >= 0; --i) 
			{
				string key = textures.Keys.ElementAt (i);
				textures [key] = content.Load<Texture2D>(key);
			}

			for (int i = fonts.Count - 1; i >= 0; --i) 
			{
				string key = fonts.Keys.ElementAt (i);
				fonts [key] = content.Load<SpriteFont>(key);
			}

            for (int i = soundEffects.Count - 1; i >= 0; --i)
            {
                string key = soundEffects.Keys.ElementAt(i);
				soundEffects[key] = content.Load<SoundEffect>("Audio/" + device + "/" + key);
            }
		}

		/// <summary>
		/// Gets the texture by specified name.
		/// </summary>
		/// <returns>The texture.</returns>
		/// <param name="name">Name.</param>
		public static Texture2D GetTexture(string name)
		{
			return textures [name];
		}

		/// <summary>
		/// Gets the font by the specified name.
		/// </summary>
		/// <returns>The font.</returns>
		/// <param name="name">Name.</param>
		public static SpriteFont GetFont(string name)
		{
			return fonts [name];
		}

        /// <summary>
        /// Gets the sound effect by the specified name.
        /// </summary>
        /// <returns>The 'soundeffect.</returns>
        /// <param name="name">Name.</param>
        public static SoundEffect GetSoundEffect(string name)
        {
            return soundEffects[name];
        }

		/// <summary>
		/// Gets the device.
		/// </summary>
		/// <returns>The device.</returns>
		public static String GetDevice()
        {
            if (Environment.OSVersion.ToString().Contains("Windows"))
            {
                return "Windows";
            }
            else
            {
                return "Mac";
            } 
        }
	}
}

