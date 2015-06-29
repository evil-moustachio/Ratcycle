using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public abstract class Entity : AtlasObject
	{
		protected Vector2 _minCoords;
		protected Vector2 _maxCoords;
		protected Vector2 _speed;
        protected float _health, _damage;
		protected bool _alive = true;
        protected bool _flip = false;

        public float Health
        {
            get { return _health; }
        }

        public abstract Rectangle AttackBox
        {
            get;
        }

        /// <summary>
        /// Entity constructor, extends GameObject.
        /// </summary>
		/// <param name="position"></param>
		/// <param name="texture"></param>
		/// <param name="rows"></param>
		/// <param name="columns"></param>
        /// <param name="animates"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
        /// <param name="speed"></param>
        public Entity(Texture2D texture, Vector2 position, Game1 game, View view, Color color, int rows, int columns, int totalFrames, bool animates, Vector2 speed) 
			: base(texture, position, game, view, color, rows, columns, totalFrames, animates)
        {
            _speed = speed;

			_minCoords = new Vector2 (0, (240 - HitBox.Height));
			_maxCoords = new Vector2 (_game.GraphicsDevice.Viewport.Width - HitBox.Width,
										_game.GraphicsDevice.Viewport.Height - HitBox.Height);
        }

        public Entity(Texture2D texture, Game1 game, View view, Color color, int rows, int columns, int totalFrames, bool animates, Vector2 speed)
            : base(texture, game, view, color, rows, columns, totalFrames, animates)
        {
            _speed = speed;

            _minCoords = new Vector2(0, (240 - HitBox.Height));
            _maxCoords = new Vector2(_game.GraphicsDevice.Viewport.Width - HitBox.Width,
                                        _game.GraphicsDevice.Viewport.Height - HitBox.Height);
        }

        protected Texture2D CreateHitBoxTexture(Game1 game, int width, int height, Color wantedColor)
        {
            Texture2D rectangleTexture = new Texture2D(game.GraphicsDevice, width, height);
            Color[] color = new Color[width * height];

            for (int i = 0; i < color.Length; i++)
            {
                color[i] = wantedColor;
            }

            rectangleTexture.SetData(color);
            return rectangleTexture;
        }

        protected void CheckHealth()
        {
            if (_alive && _health <= 0)
            {
                KillEntity();
            }
        }

		/// <summary>
		/// Applies damage to Entity.
		/// </summary>
		/// <param name="damage">Damage.</param>
		public virtual void Hit(float damage)
		{
			_health -= damage;
		}

        public abstract void KillEntity();

        /// <summary>
        /// Updates the entity (same as GameObject)
        /// </summary>
		public override void Update()
        {
            base.Update();
            CheckHealth();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            // spriteBatch.Draw(CreateHitBoxTexture(_game, HitBox.Width, HitBox.Height, new Color(Color.Red, 0.5f)), HitBox, new Color(Color.Red, 0.5f));
        }
	}
}

