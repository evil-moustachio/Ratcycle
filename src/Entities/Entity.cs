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

        /// <summary>
        /// Entity constructor, extends GameObject.
        /// </summary>
		/// <param name="position"></param>
		/// <param name="texture"></param>
		/// <param name="frameColumns"></param>
		/// <param name="frameRows"></param>
        /// <param name="animates"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
        /// <param name="speed"></param>
        public Entity(Texture2D texture, Vector2 position, Game1 game, View view, Color color, int rows, int columns, int totalFrames, bool animates, Vector2 speed) 
			: base(texture, position, game, view, color, rows, columns, totalFrames, animates)
        {
            _speed = speed;

            // Default values for border boundaries for every entity
            // Change minimal values according to background.
			_minCoords = new Vector2 (0, (240 - HitBox.Height));
			_maxCoords = new Vector2 (_game.GraphicsDevice.Viewport.Width - HitBox.Width,
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

        /// <summary>
        /// Determines what happens on hit of a certain object. Just in entity, because HUD doesn't count as hit.
        /// </summary>
        /// <param name="other"></param>
        public virtual void OnHit(Entity other)
        {
            // Maybe make this function abstract
        }
        
        /// <summary>
        /// Updates the entity (same as GameObject)
        /// </summary>
		public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
	}
}

