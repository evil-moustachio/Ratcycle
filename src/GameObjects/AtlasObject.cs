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
        protected Rectangle _sourceRectangle;
        protected Texture2D _texture; //TODO: Change back to private later.
		private Rectangle _hitBox;
        private bool _animates;
        private int _frameHeight, _frameWidth, _columns;
        private long _nextFrameTick;
        private float _ticksPerFrame;
        private float _scale = 1.0f;
        private float _rotation = 0f;
        private int _currentX, _currentY = 0;
        private Vector2 _origin = Vector2.Zero;
		private bool _lockedInMovement = false;

		public virtual Rectangle HitBox
        {
            get
            {
				updateHitbox ();
				return _hitBox;
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
			_frameHeight = _texture.Height / rows;
			_frameWidth = _texture.Width / columns;
            _columns = columns;

            _animates = animates;

			_ticksPerFrame = Model.Time.OneSecondOfTicks / 18;
            _nextFrameTick = DateTime.Now.Ticks + (int)_ticksPerFrame;

            _sourceRectangle = new Rectangle(_currentX, _currentY, _frameWidth, _frameHeight);
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

            _sourceRectangle = new Rectangle(_currentX, _currentY, _frameWidth, _frameHeight);
        }

		/// <summary>
		/// Changes the frame.
		/// </summary>
		/// <param name="y">The y coordinate.</param>
        public void ChangeFrame(int y)
        {
			if (!_lockedInMovement) 
			{
				_currentY = y;
				_sourceRectangle.Y = y * _frameHeight;
			}
        }

		/// <summary>
		/// Changes the frame.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
        public void ChangeFrame(int x, int y)
        {
				_currentX = x;
				_sourceRectangle.X = x * _frameWidth;

			if (!_lockedInMovement) 
			{
				_currentY = y;
				_sourceRectangle.Y = y * _frameHeight;
			}
        }

		public void StartSingleMovement(int y)
		{
			ChangeFrame (0, y);
			_lockedInMovement = true;
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
					_lockedInMovement = false;
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
            spriteBatch.Draw(_texture, _position, _sourceRectangle, _color, _rotation, _origin, _scale, SpriteEffects.None, 0f);
        }

		private void updateHitbox()
		{
			_hitBox = new Rectangle(
				(int)_position.X,
				(int)_position.Y,
				_sourceRectangle.Width,
				_sourceRectangle.Height);
		}
    }
}
