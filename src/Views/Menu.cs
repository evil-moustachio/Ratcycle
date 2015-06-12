using System;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class Menu : View
	{
		public Menu (Game1 game, ViewController viewController, Boolean mouseVisible) : base(game, viewController, mouseVisible)
		{
		}

		/// <summary>
		/// Draws the View's GameObjects ordered by adding order
		/// </summary>
		/// <param name="spriteBatch"></param>
		public override void Draw(SpriteBatch spriteBatch)
		{
			for (int i = 0; i < _gameObjects.Count; i++) 
			{
				_gameObjects[i].Draw(spriteBatch);
			}
		}
	}
}

