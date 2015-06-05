using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;

namespace Ratcycle
{
	public static class ContentHandler
	{
		static Dictionary <string, Texture2D> textures = new Dictionary<string, Texture2D>();

		/// <summary>
		/// Sets the textures.
		/// </summary>
		public static void SetTextures()
		{
			textures.Add ("StartButton", null);
		}

		/// <summary>
		/// Loads the textures.
		/// </summary>
		/// <param name="content">Content.</param>
		public static void LoadContent (ContentManager content)
		{
			for (int i = textures.Count - 1; i >= 0; --i) {
				string key = textures.Keys.ElementAt (i);
				textures [key] = content.Load<Texture2D> (key);
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
	}
}

