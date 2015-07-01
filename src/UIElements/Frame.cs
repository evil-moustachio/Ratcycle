using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class Frame : GameObject
	{
		private List<GameObject> _gameObjects = new List<GameObject>();
		private List<Vector2> _gameObjectPositions = new List<Vector2> ();
		protected Vector2 _size;

		public Vector2 Size { get { return _size; } }

		public Frame (Vector2 position, Game1 game, View view, List<GameObject> gameObjects) : base(position, game, view, Color.White)
		{
			_size = UtilHandler.getSize (gameObjects);
			for (int i = gameObjects.Count - 1; i >= 0; i--) {
				_gameObjectPositions.Add (gameObjects [i].Position);
				_gameObjects.Add (gameObjects [i]);
			}

			setChildPositions ();
		}

		protected void setChildPositions ()
		{

			for (int i = _gameObjects.Count - 1; i >= 0; i--) {
				_gameObjects [i].Position = _gameObjectPositions [i] + _position;
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

		public Vector2 getSize()
		{
			return UtilHandler.getSize (_gameObjects);
		}

		public Vector2 getCenter()
		{
			return UtilHandler.getCenter (_gameObjects);
		}

		protected void setCenter(bool BasedOnSize)
		{
			Vector2 centerScreen = new Vector2 (_game.GraphicsDevice.Viewport.Width / 2, _game.GraphicsDevice.Viewport.Height / 2);
			if (BasedOnSize) {
				_position = centerScreen - new Vector2 (_size.X / 2, _size.Y / 2);
			} else {
				_position = centerScreen - getCenter ();
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

