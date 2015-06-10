using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class Button : TexturedGameObject
	{
		Model.ButtonStates buttonState = Model.ButtonStates.Inactive;
		Model.ButtonTypes buttonType;
		bool buttonStateSwitch;
		Action eventHandler;

		public Button (Vector2 position, Game1 game, View view, Texture2D texture, int frameRows, Action evHandler) 
			: base(position, game, view, texture, frameRows, Color.White)
		{
			_frameRows = 1;
			eventHandler = evHandler;
		}

		public override void Update()
		{
			//check if mouse is in button.
			if (HitBox.Contains (MouseHandler.MouseLocation ())) {

				if (MouseHandler.LeftButtonBeginPress ()) {
					//check if the mouse starts pressing (inside the button).
					buttonState = Model.ButtonStates.Focus;
					buttonStateSwitch = true;

				} else if (MouseHandler.LeftButtonEndPress ()) {
					//check if the mouse stops pressing (inside the button).

					//Fire action
					eventHandler();

				} else if(!MouseHandler.LeftButtonPressed()){
					//check if the mouse is released (in the button).

					buttonState = Model.ButtonStates.Hover;
					buttonStateSwitch = true;

				}
			} else if (buttonState == Model.ButtonStates.Hover || buttonState == Model.ButtonStates.Focus) {
				//check if button is outside the button (and checks for the other two possibilities so it
				//won't fire every update).
				buttonState = Model.ButtonStates.Inactive;
				buttonStateSwitch = true;
			}

			//check if the buttonState has switched.
			if (buttonStateSwitch) {
				buttonStateSwitch = false;

				//and switch button to corresponding sprite.
				switch (buttonState) {
				case Model.ButtonStates.Inactive:
					ChangeToFrame (0);
					break;
				case Model.ButtonStates.Hover:
					ChangeToFrame (1);
					break;
				case Model.ButtonStates.Focus:
					ChangeToFrame (2);
					break;
				}
			}
		}
	}
}

