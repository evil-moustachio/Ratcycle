using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class Frame : GameObject
	{
		List<GameObject> _gameObjects = new List<GameObject>();
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

