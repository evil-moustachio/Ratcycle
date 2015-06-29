using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class Frame : GameObject
	{
		private List<GameObject> _gameObjects = new List<GameObject>();
		protected Vector2 _size;

		public Vector2 Size { get { return _size; } }

		public Frame (Vector2 position, Game1 game, View view, List<GameObject> gameObjects) : base(position, game, view, Color.White)
		{
			_size = UtilHandler.getSize (gameObjects);
			for (int i = gameObjects.Count - 1; i >= 0; i--) {
				gameObjects [i].Position += _position;
				_gameObjects.Add (gameObjects [i]);
			}
		}

		public virtual void Resize()
		{
			_size = UtilHandler.getSize (_gameObjects);
		}

		public void AddGameObject(GameObject g)
		{
			_gameObjects.Add (g);
		}

		public void RemoveGameObject (GameObject g)
		{
			_gameObjects.Remove(g);
		}

		protected void setCenter()
		{
			Vector2 centerScreen = new Vector2 (_game.GraphicsDevice.Viewport.Width / 2, _game.GraphicsDevice.Viewport.Height / 2),
			centerThis = UtilHandler.getCenter (_gameObjects);
			_position = centerScreen - centerThis;
		}

		public override void Update ()
		{
			base.Update ();

			for (int i = _gameObjects.Count - 1; i >= 0; i--) {
				_gameObjects [i].Update ();
			}
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			for (int i = _gameObjects.Count - 1; i >= 0; i--) {
				_gameObjects [i].Draw (spriteBatch);
			}
		}
	}
}

