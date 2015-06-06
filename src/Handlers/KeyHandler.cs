using System;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public class KeyHandler
	{
		KeyboardState keyboardState;

		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update()
		{
			keyboardState = Keyboard.GetState ();
		}

		/// <summary>
		/// Determines whether the specified key is down.
		/// </summary>
		/// <returns><c>true</c> if the specified key is down; otherwise, <c>false</c>.</returns>
		/// <param name="key">Key.</param>
		public bool IsKeyDown(Keys key)
		{
			return keyboardState.IsKeyDown (key);
		}


	}
}

