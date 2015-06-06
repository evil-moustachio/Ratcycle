using System;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public static class KeyHandler
	{
		static KeyboardState keyboardState;

		/// <summary>
		/// Update this instance.
		/// </summary>
		public static void Update()
		{
			keyboardState = Keyboard.GetState ();
		}

		/// <summary>
		/// Determines whether the specified key is down.
		/// </summary>
		/// <returns><c>true</c> if the specified key is down; otherwise, <c>false</c>.</returns>
		/// <param name="key">Key.</param>
		public static bool IsKeyDown(Keys key)
		{
			return keyboardState.IsKeyDown (key);
		}


	}
}

