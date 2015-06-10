using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuChooseLevel : View
	{
		private Text levelCounterText;
		private int levelCounter;

		public MenuChooseLevel (Game1 game, ViewController viewController, Boolean mouseVisible) : base(game, viewController, mouseVisible)
		{
			_gameObjects.Add (new Text(new Vector2(200, 40), _game, this, Model.standartFontName, "Selecteer level", Color.Black));
//			_gameObjects.Add (new Text (new Vector2 (200, 200), _game, this, Model.standartFontName, levelCounter, Color.Black));
//			_gameObjects

		}

		private void addNumber() 
		{

		}

		private void substractNumber()
		{

		}

		private void nextView()
		{

		}
	}
}

