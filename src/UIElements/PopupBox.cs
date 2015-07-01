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
		public int margin = 5, borderSize = 3;
		public Color innerColor = Model.Layout.OrangeColor, borderColor = Color.White;

		/// <summary>
		/// Initializes a new instance of the <see cref="Ratcycle.PopupBox"/> class.
		/// </summary>
		/// <param name="position">Position.</param>
		/// <param name="game">Game.</param>
		/// <param name="view">View.</param>
		/// <param name="gameObjects">Game objects.</param>
		/// <param name="background">If set to <c>true</c> background.</param>
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
			setCenter (true);
			getSizes (_position);
			setChildPositions ();
			if (background)
				createBackground ();
		}

		private void getSizes(Vector2 position)
		{
			innerSize = new Rectangle ((int)position.X - margin, (int)position.Y - margin, (int)_size.X + margin*2, (int)_size.Y + margin*2);
			outerSize = new Rectangle ((int)position.X - margin - borderSize, (int)position.Y - margin - borderSize, (int)_size.X + margin*2 + borderSize*2, (int)_size.Y + margin*2 + borderSize*2);
		}

		private void createBackground()
		{
			backgroundEnabled = true;

			background = new Texture2D (_game.GraphicsDevice, outerSize.Width, outerSize.Height);
			Color[] color = new Color[outerSize.Width * outerSize.Height];
			int y = 0, i = 0;
			while (y <= (outerSize.Height - 1)) {
				int x = 0;
				while (x <= (outerSize.Width - 1)) {
					if ((x < 3 || x > outerSize.Width - 4) || (y < 3 || y > outerSize.Height - 3)) {
						color [i] = Color.White;
					} else {
						color [i] = Model.Layout.OrangeColor;
					}
					i++;
					x++;
				}
				y++;
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

