using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public static class MouseHandler
	{
		static MouseState mouseState;
		static MouseState prevMouseState;

		/// <summary>
		/// Update this instance.
		/// </summary>
		public static void Update()
		{
			mouseState = Mouse.GetState ();
		}

		/// <summary>
		/// Left button pressed.
		/// </summary>
		/// <returns><c>true</c>, if left button was pressed, <c>false</c> otherwise.</returns>
		public static bool LeftButtonPressed()
		{
			return (mouseState.LeftButton == ButtonState.Pressed);
		}

		/// <summary>
		/// Returns true if the left button was released and now pressed.
		/// </summary>
		/// <value><c>true</c> if the left button was released and now pressed, otherwise; <c>false</c>.</value>
		public static bool LeftButtonBeginPress()
		{
			return (prevMouseState.LeftButton == ButtonState.Released && LeftButtonPressed());
		}

		/// <summary>
		/// Returns true if the left button was pressed and now released.
		/// </summary>
		/// <returns><c>true</c> if the left button was pressed and now released, otherwise; <c>false</c>.</returns>
		public static bool LeftButtonEndPress()
		{
			return (prevMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released);
		}

		/// <summary>
		/// Right button pressed.
		/// </summary>
		/// <returns><c>true</c>, if right button was pressed, <c>false</c> otherwise.</returns>
		public static bool RightButtonPressed()
		{
			return mouseState.RightButton == ButtonState.Pressed;
		}

		/// <summary>
		/// Returns true if the right button was released and now pressed
		/// </summary>
		/// <value><c>true</c> if the right button was released and now pressed, otherwise; <c>false</c>.</value>
		public static bool RightButtonBeginPress()
		{
			return ((prevMouseState.RightButton == ButtonState.Released) && RightButtonPressed());
		}

		/// <summary>
		/// Returns true if the right button was pressed and now released.
		/// </summary>
		/// <returns><c>true</c> if the right button was pressed and now released, otherwise; <c>false</c>.</returns>
		public static bool RightButtonEndPress()
		{
			return (prevMouseState.RightButton == ButtonState.Pressed && mouseState.RightButton == ButtonState.Released);
		}

		/// <summary>
		/// Returns te mouse location in a Vector2.
		/// </summary>
		/// <returns>The location.</returns>
		public static Vector2 MouseLocation()
		{
			return new Vector2 (mouseState.Position.X, mouseState.Position.Y);
		}
	}
}

