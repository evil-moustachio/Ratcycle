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
		private bool _mouseVisible;

		public ViewController ViewController
		{
			get { return _viewController; }
		}

		public bool MouseVisible 
        {
			get { return _mouseVisible; }
		}

        /// <summary>
        /// Constructs the view.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="viewController"></param>
		/// <param name="mouseVisible"></param>
		public View(Game1 game, ViewController viewController, bool mouseVisible)
		{
            _game = game;
            _viewController = viewController;
            _mouseVisible = mouseVisible;

			_gameObjects = new List<GameObject>();
            _orderedList = new List<GameObject>();
		}

        /// <summary>
        /// Updates the View's GameObjects
        /// </summary>
		public virtual void Update()
		{
			for (int i = _gameObjects.Count - 1; i >= 0; i--) 
            {
				_gameObjects[i].Update();
			}

            _orderedList = _gameObjects.OrderBy(o => o.Position.Y).ToList();
		}

        /// <summary>
        /// Draws the View's GameObjects
        /// </summary>
        /// <param name="spriteBatch"></param>
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			for (int i = _orderedList.Count - 1; i >= 0; i--) 
            {
				_orderedList[i].Draw (spriteBatch);
			}
		}
	}
}

