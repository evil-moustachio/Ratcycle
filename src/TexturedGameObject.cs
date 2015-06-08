using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class TexturedGameObject : GameObject
	{
		// Texture
		protected float _scale;
		protected float _rotation;
		protected Vector2 _origin;
		protected Texture2D _texture;

		//Switching sprites
		protected Rectangle _sourceRectangle;
		protected int _frameRows;
		protected int _currentYFrame;
		protected int _frameWidth;
		protected int _frameHeight;

		/// <summary>
		/// Returns the current hitbox of the object. Which is calculated
		/// using the sourceRectangle of the object.
		/// </summary>
		public Rectangle HitBox
		{
			get
			{
				return new Rectangle(
					(int)_position.X,
					(int)_position.Y,
					_sourceRectangle.Width, 
					_sourceRectangle.Height);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ratcycle.TexturedGameObject"/> class.
		/// </summary>
		/// <param name="position">Position.</param>
		/// <param name="game">Game.</param>
		/// <param name="view">View.</param>
		/// <param name="texture">Texture.</param>
		/// <param name="frameRows">Frame rows.</param>
		public TexturedGameObject (Vector2 position, Game1 game, View view, Texture2D texture,
									int frameRows) : base(position, game, view)
		{
			_texture = texture;

			_frameRows = frameRows;
			_origin = Vector2.Zero;
			_rotation = 0;
            _scale = 1;

			_currentYFrame = 0;
			_frameWidth = _texture.Width;
			_frameHeight = _texture.Height / _frameRows;
			_sourceRectangle = new Rectangle (0, 0, _frameWidth, _frameHeight);
		}

		/// <summary>
		/// Changes the sourceRectangle's position to the desired frame.
		/// Top row is 0, first column is 0.
		/// </summary>
		/// <param name="frameRow"></param>
		public void ChangeToFrame(int frameRow)
		{

			// Update _currentFrame
			_currentYFrame = frameRow;

			// Update _sourceRectangle
			_sourceRectangle.Y = _frameHeight * frameRow;
		}

		/// <summary>
		/// Draws the object's texture on the spriteBatch.
		/// </summary>
		/// <param name="spriteBatch"></param>
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			base.Draw (spriteBatch);
			spriteBatch.Draw(
				_texture,
				_position,
				_sourceRectangle,
				_color,
				_rotation,
				_origin,
				_scale,
				SpriteEffects.None,
				0f);
		}
	}
}

