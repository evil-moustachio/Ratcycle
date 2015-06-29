using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class AtlasObject : GameObject
    {
		protected Vector2 _sourceRectanglePosition, _sourceRectangleDimensions;
        protected Texture2D _texture; //TODO: Change back to private later.
		private Rectangle _hitBox;
        private bool _animates;
		private float _frameHeight, _frameWidth;
		private int _columns, _rows;
        private long _nextFrameTick;
        private float _ticksPerFrame;
        private float _scale = 1.0f;
        private float _rotation = 0f;
		private float _currentX, _currentY = 0;
        private Vector2 _origin = Vector2.Zero;
		private bool _lockedInMotion = false;

		public virtual Rectangle HitBox
        {
            get
            {
				updateHitbox ();
				return _hitBox;
            }
        }

		/// <summary>
		/// Returns the Y position of the bottom of the texture.
		/// </summary>
		/// <value>The lowest y.</value>
		public override float LowestY 
		{
			get 
			{
				return _position.Y + _sourceRectangleDimensions.Y;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ratcycle.AtlasObject"/> class.
		/// </summary>
		/// <param name="texture">Texture.</param>
		/// <param name="position">Position.</param>
		/// <param name="game">Game.</param>
		/// <param name="view">View.</param>
		/// <param name="color">Color.</param>
		/// <param name="rows">Rows.</param>
		/// <param name="columns">Columns.</param>
		/// <param name="totalFrames">Total frames.</param>
		/// <param name="animates">If set to <c>true</c> animates.</param>
        public AtlasObject(Texture2D texture, Vector2 position, Game1 game, View view, Color color, int rows, int columns, int totalFrames, bool animates) : base (position, game, view, color)
        {
			_texture = texture;
			_columns = columns;
			_rows = rows;
			_frameWidth = _texture.Width / _columns;
			_frameHeight = _texture.Height / _rows;

            _animates = animates;

			_ticksPerFrame = Model.Time.OneSecondOfTicks / 18;
            _nextFrameTick = DateTime.Now.Ticks + (int)_ticksPerFrame;

			_sourceRectanglePosition = new Vector2(_currentX, _currentY);
			_sourceRectangleDimensions = new Vector2 (_frameWidth, _frameHeight);
        }

        public AtlasObject(Texture2D texture, Game1 game, View view, Color color, int rows, int columns, int totalFrames, bool animates)
            : base(game, view, color)
        {
            _texture = texture;
            _frameHeight = _texture.Height / rows;
            _frameWidth = _texture.Width / columns;
            _columns = columns;

            _animates = animates;

			_ticksPerFrame = Model.Time.OneSecondOfTicks / 18;
            _nextFrameTick = DateTime.Now.Ticks + (int)_ticksPerFrame;

			_sourceRectanglePosition = new Vector2(_currentX, _currentY);
			_sourceRectangleDimensions = new Vector2 (_frameWidth, _frameHeight);
        }

		/// <summary>
		/// Changes the frame.
		/// </summary>
		/// <param name="y">The y coordinate.</param>
        public void ChangeFrame(int y)
        {
			if (!_lockedInMotion) 
			{
				_currentY = y;
				_sourceRectanglePosition.Y = y * _frameHeight;
			}
        }

		/// <summary>
		/// Changes the frame.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public void ChangeFrame(float x, float y)
        {
			_currentX = x;
			_sourceRectanglePosition.X = x * _frameWidth;

			if (!_lockedInMotion) 
			{
				_currentY = y;
				_sourceRectanglePosition.Y = y * _frameHeight;
			}
        }

		public void StartSingleMotion(float y)
		{
			_currentX = 0;
			_sourceRectanglePosition.X = 0;
			_currentY = y;
			_sourceRectanglePosition.Y = y * _frameHeight;

			_lockedInMotion = true;
		}

		/// <summary>
		/// Changes the frame based on the animation
		/// </summary>
        public void AnimationHandler()
        {
            if (DateTime.Now.Ticks > _nextFrameTick)
            {
                _currentX++;

                if (_currentX == _columns)
                {
                    _currentX = 0;
					_lockedInMotion = false;
                }

                ChangeFrame(_currentX, _currentY);
                _nextFrameTick = DateTime.Now.Ticks + (int)_ticksPerFrame;
            }
        }

        public override void Update()
        {
            if (_animates)
            {
                AnimationHandler();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
			spriteBatch.Draw(_texture, _position, new Rectangle((int)_sourceRectanglePosition.X, (int)_sourceRectanglePosition.Y, 
				(int)_sourceRectangleDimensions.X, (int)_sourceRectangleDimensions.Y), Color, _rotation, _origin, _scale, SpriteEffects.None, 0f);
        }

		private void updateHitbox()
		{
			_hitBox = new Rectangle(
				(int)_position.X,
				(int)_position.Y,
				(int)_sourceRectangleDimensions.X,
				(int)_sourceRectangleDimensions.Y);
		}

		public Vector2 getSize()
		{
			return UtilHandler.getSize (_texture, (int)_columns, (int)_rows);
		}
    }
}
