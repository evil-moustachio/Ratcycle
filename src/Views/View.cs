﻿using System;
using System.Linq;

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
		protected List<GameObject> _gameObjects;
        protected List<GameObject> _orderedList;
		private Boolean _mouseVisible;

		public ViewController ViewController
		{
			get { return _viewController; }
		}

		public Boolean MouseVisible {
			get { return _mouseVisible; }
		}

        /// <summary>
        /// Constructs the view.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="viewController"></param>
		/// <param name="mouseVisible"></param>
		public View (Game1 game, ViewController viewController, Boolean mouseVisible)
		{
            _game = game;
            _viewController = viewController;
			_gameObjects = new List<GameObject>();
            _orderedList = new List<GameObject>();
			_mouseVisible = mouseVisible;
		}

		//TODO: Delete CreateRectangle function
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
			foreach (GameObject gameObject in _gameObjects)
            {
                gameObject.Update();
            }
            _orderedList = _gameObjects.OrderBy(o => o.Position.Y).ToList();
		}

        /// <summary>
        /// Draws the View's GameObjects
        /// </summary>
        /// <param name="spriteBatch"></param>
		public virtual void Draw (SpriteBatch spriteBatch)
		{
			foreach (GameObject gameObject in _orderedList)
            {
                if (gameObject is Entity)
                {
                    gameObject.Draw(spriteBatch);
                }
            }

            foreach (GameObject gameObject in _orderedList)
            {
                if (!(gameObject is Entity))
                {
                    gameObject.Draw(spriteBatch);
                }
            }
		}
	}
}

