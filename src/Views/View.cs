using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Ratcycle
{
	public class View
	{
        protected Game1 _game;
        protected ViewController _viewController;
		protected List<TexturedGameObject> _gameObjects;
		protected Boolean _mouseVisible;

		public ViewController ViewController
		{
			get { return _viewController; }
		}

        /// <summary>
        /// Constructs the view.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="viewController"></param>
		public View (Game1 game, ViewController viewController, Boolean MouseVisible)
		{
            _game = game;
            _viewController = viewController;
			_mouseVisible = MouseVisible;
		}
        
        /// <summary>
        /// Initializes all used variables as new.
        /// </summary>
		public virtual void Initialize()
		{
			_game.IsMouseVisible = _mouseVisible;
			_gameObjects = new List<TexturedGameObject>();
		}


        /// <summary>
        /// Delete this function later on, using this just for testing. Makes textures blocks.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="wantedColor"></param>
        /// <returns></returns>
        protected Texture2D CreateRectangle(Game1 game, int width, int height, Color wantedColor)
        {
            Texture2D rectangleTexture = new Texture2D(game.GraphicsDevice, width, height);
            Color[] color = new Color[width * height];

            for (int i = 0; i < color.Length; i++)
            {
                color[i] = wantedColor;
            }

            rectangleTexture.SetData(color);
            return rectangleTexture;
        }

        /// <summary>
        /// Updates the View's GameObjects
        /// </summary>
		public virtual void Update ()
		{
			foreach (TexturedGameObject gameObject in _gameObjects)
            {
                gameObject.Update();
            }
		}

        /// <summary>
        /// Draws the View's GameObjects
        /// </summary>
        /// <param name="spriteBatch"></param>
		public virtual void Draw (SpriteBatch spriteBatch)
		{
			foreach (TexturedGameObject gameObject in _gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
		}
	}
}

