using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public class Player
	{
		Keys _up, _down, _left, _right; // TODO: this
        /// <summary>
        /// Constructs the player
        /// </summary>
		public Player ()
		{
			
		}

        /// <summary>
        /// Updates the player
        /// </summary>
		public void Update()
		{
			KeyHandler.Update ();
			MouseHandler.Update ();
		}
	}
}

