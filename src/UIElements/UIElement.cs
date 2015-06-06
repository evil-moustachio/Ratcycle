using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public class UIElement : GameObject
	{
        /// <summary>
        /// UIElement constructor, extends GameObject.
        /// </summary>
		/// <param name="position"></param>
		/// <param name="texture"></param>
		/// <param name="frameColumns"></param>
		/// <param name="frameRows"></param>
        /// <param name="animates"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
		public UIElement(Vector2 position, Texture2D texture, int frameColumns, int frameRows, 
			bool animates, Game1 game, View view)
			: base(position, texture, frameColumns, frameRows, animates, game, view)
        {
        }

		public override void Update ()
		{
			base.Update ();
		}
	}
}

