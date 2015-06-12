using System;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public static class KeyHandler
	{
		static KeyboardState keyboardState, prevKeyboardState;

		/// <summary>
		/// Update this instance.
		/// </summary>
		public static void Update()
		{
			prevKeyboardState = keyboardState;
			keyboardState = Keyboard.GetState();
		}

		/// <summary>
		/// Determines whether the specified key is down.
		/// </summary>
		/// <returns><c>true</c> if the specified key is down; otherwise, <c>false</c>.</returns>
		/// <param name="key">Key.</param>
		public static bool IsKeyDown(Keys key)
		{
			return keyboardState.IsKeyDown(key);
		}

		/// <summary>
		/// Checks if the given key has been released compared to the previous gametick
		/// </summary>
		/// <returns><c>true</c>, if key was released, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		public static Boolean checkKeyReleased(Keys key)
		{
			return (prevKeyboardState.IsKeyDown(key) && keyboardState.IsKeyUp(key));
		}

		/// <summary>
		/// Checks if the givne key has been pressed compared to the previous gametick
		/// </summary>
		/// <returns><c>true</c>, if new key was pressed, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>
		public static Boolean checkNewKeyPressed(Keys key)
		{
			return (prevKeyboardState.IsKeyUp (key) && keyboardState.IsKeyDown(key));
		}

	}
}

