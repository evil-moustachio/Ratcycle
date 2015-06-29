using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class PopupBox : Frame
	{
		Rectangle outerSize, innerSize;
		Texture2D background;
		bool backgroundEnabled;

		public PopupBox (Vector2 position, Game1 game, View view, List<GameObject> gameObjects, bool background) : base (position, game, view, gameObjects)
		{
			getSizes (position);
			if (background)
				createBackground ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ratcycle.PopupBox"/> class, and set it to the center of the screen. 
		/// </summary>
		/// <param name="game">Game.</param>
		/// <param name="view">View.</param>
		/// <param name="gameObjects">Game objects.</param>
		/// <param name="background">If set to <c>true</c> background.</param>
		public PopupBox (Game1 game, View view, List<GameObject> gameObjects, bool background) : base (new Vector2(-100000), game, view, gameObjects)
		{
			setCenter ();
			if (background)
				createBackground ();
		}

		private void getSizes(Vector2 position)
		{
			innerSize = new Rectangle ((int)position.X - 10, (int)position.Y - 10, (int)_size.X + 10, (int)_size.Y + 10);
			outerSize = new Rectangle ((int)position.X - 13, (int)position.Y - 13, (int)_size.X + 13, (int)_size.Y + 13);
		}

		private void createBackground()
		{
			backgroundEnabled = true;

			background = new Texture2D (_game.GraphicsDevice, outerSize.Width, outerSize.Height);
			Color[] color = new Color[outerSize.Width * outerSize.Height];
			int x = 0, y = 0, i = 0;

			while (x <= outerSize.Width) {
				while (y <= outerSize.Height) {
					if ((x < 3 || x > outerSize.Width - 4) && (y < 3 || y > outerSize.Height - 3)) {
						color [i] = Color.White;
					} else {
						color [i] = Model.Layout.OrangeColor;
					}
					i++;
				}
			}

			background.SetData (color);
		}

		public override void Resize ()
		{
			base.Resize ();
			getSizes (_position);
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw (background, new Vector2 (outerSize.X, outerSize.Y), Color.White);
			base.Draw (spriteBatch);
		}
	}
}

