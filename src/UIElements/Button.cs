using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class Button : AtlasObject
	{
		Model.Layout.ButtonStates buttonState = Model.Layout.ButtonStates.Inactive;
		bool buttonStateSwitch;
		Action eventHandler;

		public Button (Texture2D texture, Vector2 position, Game1 game, View view, Action evHandler)
            : base(texture, position, game, view, Color.White, 3, 1, 1, false)
		{
			eventHandler = evHandler;
		}

		public override void Update()
		{
			//check if mouse is in button.
			if (HitBox.Contains (MouseHandler.MouseLocation ())) {

				if (MouseHandler.LeftButtonBeginPress ()) {
					//check if the mouse starts pressing (inside the button).
					buttonState = Model.Layout.ButtonStates.Focus;
					buttonStateSwitch = true;

				} else if (MouseHandler.LeftButtonEndPress ()) {
					//check if the mouse stops pressing (inside the button).

					//Fire action
					eventHandler();
					return;

				} else if(!MouseHandler.LeftButtonPressed()){
					//check if the mouse is released (in the button).

					buttonState = Model.Layout.ButtonStates.Hover;
					buttonStateSwitch = true;

				}
			} else if (buttonState == Model.Layout.ButtonStates.Hover || buttonState == Model.Layout.ButtonStates.Focus) {
				//check if button is outside the button (and checks for the other two possibilities so it
				//won't fire every update).
				buttonState = Model.Layout.ButtonStates.Inactive;
				buttonStateSwitch = true;
			}

			//check if the buttonState has switched.
			if (buttonStateSwitch) {
				buttonStateSwitch = false;

				//and switch button to corresponding sprite.
				switch (buttonState) {
				case Model.Layout.ButtonStates.Inactive:
					ChangeFrame (0);
					break;
				case Model.Layout.ButtonStates.Hover:
					ChangeFrame (1);
					break;
				case Model.Layout.ButtonStates.Focus:
					ChangeFrame (2);
					break;
				}
			}
		}
	}
}

