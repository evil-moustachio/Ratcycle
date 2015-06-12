using System;
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
        

        /// <summary>
        /// Updates the View's GameObjects
        /// </summary>
		public virtual void Update ()
		{
			for (int i = _gameObjects.Count - 1; i >= 0; i--) {
				_gameObjects [i].Update ();
			}

            _orderedList = _gameObjects.OrderBy(o => o.Position.Y).ToList();
		}

        /// <summary>
        /// Draws the View's GameObjects
        /// </summary>
        /// <param name="spriteBatch"></param>
		public virtual void Draw (SpriteBatch spriteBatch)
		{
			for (int i = _orderedList.Count - 1; i >= 0; i--) {
				_gameObjects [i].Draw (spriteBatch);
			}
		}
	}
}

