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
			if (HitBox.Contains (MouseHandler.MouseLocation())) 
            {
				if (MouseHandler.LeftButtonBeginPress ()) 
                {
					buttonState = Model.Layout.ButtonStates.Focus;
					buttonStateSwitch = true;
				} 
                else if (MouseHandler.LeftButtonEndPress()) 
                {

					eventHandler();
					return;
				} 
                else if(!MouseHandler.LeftButtonPressed())
                {
					buttonState = Model.Layout.ButtonStates.Hover;
					buttonStateSwitch = true;
				}
			}
            else if (buttonState == Model.Layout.ButtonStates.Hover || buttonState == Model.Layout.ButtonStates.Focus)
            {
				buttonState = Model.Layout.ButtonStates.Inactive;
				buttonStateSwitch = true;
			}

			if (buttonStateSwitch) 
            {
				buttonStateSwitch = false;

				switch (buttonState) 
                {
				    case Model.Layout.ButtonStates.Inactive:
					    ChangeFrame(0);
					    break;
				    case Model.Layout.ButtonStates.Hover:
					    ChangeFrame(1);
					    break;
				    case Model.Layout.ButtonStates.Focus:
					    ChangeFrame(2);
					    break;
				}
			}
		}
	}
}

