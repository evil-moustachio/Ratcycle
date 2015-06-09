using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class Monster : Entity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Ratcycle.Enemy"/> class.
		/// </summary>
		/// <param name="position">Position.</param>
		/// <param name="game">Game.</param>
		/// <param name="view">View.</param>
		/// <param name="texture">Texture.</param>
		/// <param name="frameRows">Frame rows.</param>
		/// <param name="frameColumns">Frame columns.</param>
		/// <param name="fps">Fps.</param>
		/// <param name="speed">Speed.</param>
		public Monster (Vector2 position, Game1 game, View view, Texture2D texture, int frameRows, int frameColumns, 
			int fps, Vector2 speed) 
			: base(position, game, view, texture, frameRows, frameColumns, fps, speed, Color.White)
		{
		}

		/// <summary>
		/// Returns a Vector2 with the next location towards the target.
		/// </summary>
		/// <param name="target">Target.</param>
		public Vector2 Target(Vector2 target)
		{
			Vector2 newPosition;
			float offset;
			float speed = _speed.X;

			// Check if it's a straight line
			if (target.X == _position.X) {
				if (target.Y > _position.Y) {
					offset = speed * -1;
				} else {
					offset = speed;
				}
				newPosition = new Vector2 (_position.X, _position.Y + offset);
			} else if (target.Y == _position.Y) {
				if (target.X > _position.X) {
					offset = speed * -1;
				} else {
					offset = speed;
				}
				newPosition = new Vector2 (_position.X + offset, _position.Y);
			} else {

				// Determine current trianlge
				var diffX = target.X - _position.X;
				var diffY = target.Y - _position.Y;
				var totalDistance = Math.Sqrt (Math.Pow(diffX, 2) + Math.Pow(diffY, 2));

				// New triangle
				var scale = totalDistance / speed;
				var offsetX = diffX / scale;
				var offsetY = diffY / scale;

				// Next position
				var newX = _position.X + offsetX;
				var newY = _position.Y + offsetY;
				newPosition = new Vector2 ((float)newX, (float)newY);
			}
			return newPosition;
		}

		public override void Update ()
		{
			base.Update ();
			Stage view = (Stage)_parentView;
			Vector2 nextPosition = Target (view.RatPosition);
			Rectangle nextHitbox = new Rectangle ((int)nextPosition.X, (int)nextPosition.Y, HitBox.Width, HitBox.Height);

			if (view.NotColliding(this, nextHitbox, _minCoords, _maxCoords))
			{
				_position = nextPosition;
			}
			else if (nextHitbox.Intersects(view.RatHitBox))
			{
				Console.WriteLine("Got the Rat in the groin");
			}
		}
	}
}

