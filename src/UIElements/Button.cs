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
		Action<int> eventIntHandler;
		int eventInt;

		public Button (Texture2D texture, Vector2 position, Game1 game, View view, Action evHandler)
			: base(texture, position, game, view, Color.White, 3, 1, 1, false)
		{
			eventHandler = evHandler;
		}
			
		public Button (Texture2D texture, Vector2 position, Game1 game, View view, int Columns, Action<int> evHandler, int evInt)
			: base(texture, position, game, view, Color.White, 3, Columns, 1, false)
		{
			eventIntHandler = evHandler;
			eventInt = evInt;
		}

		public override void Update()
		{
			//Check if mouse is in button.
			if (HitBox.Contains (MouseHandler.MouseLocation())) 
            {
				if (MouseHandler.LeftButtonBeginPress ()) 
                {
					//check if the mouse starts pressing the button
					buttonState = Model.Layout.ButtonStates.Focus;
					buttonStateSwitch = true;
				} 
                else if (MouseHandler.LeftButtonEndPress()) 
                {
					//check if mouse stops pressing the button, inside the button
					handleEvent();
					return;
				} 
                else if(!MouseHandler.LeftButtonPressed())
                {
					//check if the mouse only hovers the buttons
					buttonState = Model.Layout.ButtonStates.Hover;
					buttonStateSwitch = true;
				}
			}
            else if (buttonState == Model.Layout.ButtonStates.Hover || buttonState == Model.Layout.ButtonStates.Focus)
            {
				//otherwise just make it inactive
				buttonState = Model.Layout.ButtonStates.Inactive;
				buttonStateSwitch = true;
			}

			//Change the texture of the button to the designated frame
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

		private void handleEvent()
		{
			if (eventHandler != null) 
			{
				eventHandler ();
			} 
			else 
			{
				eventIntHandler (eventInt);
			}
		}
	}
}

