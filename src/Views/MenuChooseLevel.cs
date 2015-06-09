using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuChooseLevel : View
	{
		public MenuChooseLevel (Game1 game, ViewController viewController, Boolean mouseVisible) : base(game, viewController, mouseVisible)
		{
			_gameObjects.Add (new Text(new Vector2(200, 40), _game, this, "Verdana", "Selecteer level", Color.Black));
		}

		private void changeNumber(int n) 
		{

		}

		private void goToView(View newView)
		{

		}
	}
}

