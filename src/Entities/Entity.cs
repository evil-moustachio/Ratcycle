using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public class Entity : GameObject
	{
        public Entity(Vector2 position, Texture2D texture, bool animates, 
            Game1 game, View view) : base(position, texture, animates, game, view)
        {
        }
	}
}

