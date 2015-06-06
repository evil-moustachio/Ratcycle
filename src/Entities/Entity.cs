using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public abstract class Entity : GameObject
	{
		protected Vector2 _minCoords;
		protected Vector2 _maxCoords;
        protected Vector2 _speed;

        /// <summary>
        /// Entity constructor, extends GameObject.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="texture"></param>
        /// <param name="animates"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
        /// <param name="speed"></param>
        public Entity(Vector2 position, Texture2D texture, bool animates, 
            Game1 game, View view, Vector2 speed) : base(position, texture, animates, game, view)
        {
            _speed = speed;

            // Default values for border boundaries for every entity
            // Change minimal values according to background.
			_minCoords = new Vector2 (0,0);
			_maxCoords = new Vector2 (game.GraphicsDevice.Viewport.Width - _texture.Width,
										game.GraphicsDevice.Viewport.Height - _texture.Height);
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
	}
}

