using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public class Player
	{
		Keys _up = Keys.W, _down = Keys.S, _left = Keys.A, _right = Keys.D;
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
			if (KeyHandler.IsKeyDown (_up))
				Rat.Direction.Add (Model.Player.Direction.Up);
			if (KeyHandler.IsKeyDown (_down))
				Rat.Direction.Add (Model.Player.Direction.Down);
			if (KeyHandler.IsKeyDown (_left))
				Rat.Direction.Add (Model.Player.Direction.Left);
			if (KeyHandler.IsKeyDown (_right))
				Rat.Direction.Add (Model.Player.Direction.Right);

			KeyHandler.Update ();
			MouseHandler.Update ();
		}
	}
}

