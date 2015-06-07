using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class Button : UIElement
	{
		int _headingView;
		Model.ButtonStates buttonState = Model.ButtonStates.Inactive;
		bool buttonStateSwitch;

		/// <summary>
		/// Initializes a new instance of the <see cref="Ratcycle.Button"/> class.
		/// </summary>
		/// <param name="position">Position.</param>
		/// <param name="texture">Texture.</param>
		/// <param name="frameColumns">Frame columns.</param>
		/// <param name="frameRows">Frame rows.</param>
		/// <param name="animates">If set to <c>true</c> animates.</param>
		/// <param name="game">Game.</param>
		/// <param name="view">View.</param>
		/// <param name="headingView">Heading view.</param>
		public Button (Vector2 position, Texture2D texture, int frameColumns, int frameRows, 
			bool animates, Game1 game, View view, int headingView) 
			: base(position, texture, frameColumns, frameRows, animates, game, view)
		{
			_frameColumns = 3;
			_frameRows = 1;
			_headingView = headingView;
		}

		public override void Update()
		{
			base.Update ();

			//check if mouse is in button.
			if (_object.Contains (MouseHandler.MouseLocation ())) {

				if (MouseHandler.LeftButtonBeginPress ()) {
					//check if the mouse starts pressing (inside the button).
					buttonState = Model.ButtonStates.Focus;
					buttonStateSwitch = true;
				} else if (MouseHandler.LeftButtonEndPress ()) {
					//check if the mouse stops pressing (inside the button).
					_parentView.ViewController.CurrentView = _headingView;
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
					ChangeToFrame (-1, 0);
					break;
				case Model.ButtonStates.Hover:
					ChangeToFrame (-1, 1);
					break;
				case Model.ButtonStates.Focus:
					ChangeToFrame (-1, 2);
					break;
				}
			}
		}
	}
}

