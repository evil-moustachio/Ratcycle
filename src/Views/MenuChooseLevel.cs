using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuChooseLevel : View
	{
		private Text levelCounterText;
		private int levelCounter = Model.CurrentLevel;

		public MenuChooseLevel (Game1 game, ViewController viewController, Boolean mouseVisible) : base(game, viewController, mouseVisible)
		{
			_gameObjects.Add (new Text(new Vector2(320, 40), _game, this, Model.standartFontName, "Selecteer level", Color.Black));
			_gameObjects.Add (new Button(ContentHandler.GetTexture("SquareButton"), new Vector2(305, 200), _game, this, subsLevel));
			_gameObjects.Add (new Text (new Vector2 (395, 200), _game, this, Model.standartFontName, levelCounter.ToString(), Color.Black));
			levelCounterText = (Text)_gameObjects [_gameObjects.Count - 1];
			_gameObjects.Add (new Button(ContentHandler.GetTexture("SquareButton"), new Vector2(455, 200), _game, this, addLevel));
			_gameObjects.Add (new Button(ContentHandler.GetTexture("startbutton_ratCycle"), new Vector2(580, 500), _game, this, nextView));
		}

		private void addLevel() 
		{
			if (Model.ReachedLevel > levelCounter) {
				levelCounter++;
			}
			levelCounterText.setString (levelCounter.ToString());
		}

		private void subsLevel()
		{
			if (levelCounter > 0) {
				levelCounter--;
			}
			levelCounterText.setString (levelCounter.ToString());
		}

		private void nextView()
		{
			Model.CurrentLevel = levelCounter;
			_viewController.setView (new Stage (_game, _viewController, false));
		}
	}
}

