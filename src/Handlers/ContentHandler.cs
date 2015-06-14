﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;

namespace Ratcycle
{
	public static class ContentHandler
	{
		static Dictionary <string, Texture2D> textures = new Dictionary<string, Texture2D>();
		static Dictionary <string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();

		/// <summary>
		/// Sets the content.
		/// </summary>
		public static void SetContent()
		{
			
			//MENUS
			textures.Add ("startbutton_ratCycle", null);
			textures.Add ("startmenuBackground", null);
			textures.Add ("OrangeBG", null);

			//STAGES
			textures.Add("background_ratCycle", null);

			//HUD
			textures.Add ("HealthBarEntity", null);
			textures.Add ("HUDHealthbarRat", null);
			textures.Add ("HUDRat", null);
			textures.Add ("EscButton", null);

			//ENTITIES
			textures.Add("RatSprite", null);

			//PLACEHOLDERS
			textures.Add ("PCSquareButton", null);

			textures.Add ("pcInventory", null);
			textures.Add ("PC_CHEMISCH_KLEIN", null);
			textures.Add ("PC_CHEMISCH_GROOT", null);
			textures.Add ("PC_GFT_KLEIN", null);
			textures.Add ("PC_GFT_GROOT", null);
			textures.Add ("PC_PAPIER_KLEIN", null);
			textures.Add ("PC_PAPIER_GROOT", null);
			textures.Add ("PC_PLASTIC_KLEIN", null);
			textures.Add ("PC_PLASTIC_GROOT", null);
			textures.Add ("PC_REST_KLEIN", null);
			textures.Add ("PC_REST_GROOT", null);

			//FONTS
			fonts.Add ("Aero Matics Display-14", null);
        }

		/// <summary>
		/// Loads the textures.
		/// </summary>
		/// <param name="content">Content.</param>
		public static void LoadContent(ContentManager content)
		{
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
	}
}

