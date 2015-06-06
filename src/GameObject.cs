using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public abstract class GameObject
	{
        protected Vector2 _position;
        protected Game1 _game;
        protected View _parentView;

        // Texture
        protected Color _color;
        protected float _scale;
        protected float _rotation;
        protected Vector2 _origin;
        protected Texture2D _texture;
        protected Rectangle _sourceRectangle;

        // Animation
        private bool _animates;
        protected Vector2 _currentFrame;
        protected int _frameWidth;
        protected int _frameHeight;
        protected int _frameColumns;
        protected int _frameRows;
        private long _ticksPerFrame;
        private long _nextFrameTick;

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
        /// GameObject constructor.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="texture"></param>
        /// <param name="animates"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
		public GameObject(Vector2 position, Texture2D texture, bool animates, 
            Game1 game, View view)
		{
            int fps;

            _position = position;
            _texture = texture;
            _game = game;
            _parentView = view;

            _animates = animates;

            // Default settings.
            _frameColumns = 1;
            _frameRows = 1;
            _color = Color.White;
            _origin = Vector2.Zero;
            _rotation = 0;
            _scale = 1;
            fps = 25;

            // _sourceRectanlge setup.
            _frameWidth = _texture.Width / _frameColumns;
            _frameHeight = _texture.Height / _frameRows;
            _sourceRectangle = new Rectangle(0, 0, _frameWidth, _frameHeight);
            // Animation setup.
            _ticksPerFrame = 10000000 / fps;
            _nextFrameTick = DateTime.Now.Ticks + _ticksPerFrame;
		}

        /// <summary>
        /// Updates the sourceRectangle when it's time for the next frame.
        /// </summary>
        private void AnimationHandler()
        {
			if (Model.CurrentGameTick > _nextFrameTick)
            {
                var nextFrame = (int)_currentFrame.X + 1;
                if (nextFrame > _frameColumns)
                {
                    nextFrame = 0;
                }
                ChangeToFrame( nextFrame, (int)_currentFrame.Y);
				_nextFrameTick = Model.CurrentGameTick + _ticksPerFrame;
            }
        }

        /// <summary>
        /// Changes the sourceRectangle's position to the desired frame.
        /// Top row is 0, first column is 0.
        /// </summary>
        /// <param name="frameColumn"></param>
        /// <param name="frameRow"></param>
        public void ChangeToFrame(int frameColumn, int frameRow)
        {
            // Update _currentFrame
            _currentFrame.X = frameColumn;
            _currentFrame.Y = frameRow;
            // Update _sourceRectangle
            _sourceRectangle.X = _frameWidth * frameColumn;
            _sourceRectangle.Y = _frameHeight * frameRow;
        }
 
        /// <summary>
        /// Updates the object.
        /// </summary>
        public virtual void Update()
        {
            if (_animates)
            {
                AnimationHandler();
            }
        }

        /// <summary>
        /// Draws the object's texture on the spriteBatch.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
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

