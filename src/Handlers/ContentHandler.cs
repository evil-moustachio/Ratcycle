using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

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
			foreach (var texture in textures) {
				textures [texture.Key] = content.Load<Texture2D> (texture.Key);
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

