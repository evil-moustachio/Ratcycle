using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuChooseLevel : Menu
	{
		private Text levelCounterText;
		private int levelCounter = Model.Level.Current;

		public MenuChooseLevel (Game1 game, ViewController viewController, Boolean mouseVisible) : base(game, viewController, mouseVisible)
		{
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("background_ratCycle"), new Vector2(0,0), _game, this, Color.White, 1, 1, 1, false));
			_gameObjects.Add (new RectangleDrawer(new Rectangle(0, 0, _game.GraphicsDevice.Viewport.Width, _game.GraphicsDevice.Viewport.Height), _game, this, Color.Black));

			_gameObjects.Add (new AtlasObject (ContentHandler.GetTexture ("OrangeBG"), new Vector2 (0), _game, this, 
				Color.White, 1, 1, 1, false));
			_gameObjects.Add (new Text(new Vector2(320, 40), _game, this, Model.Layout.standartFontName, 
				"Selecteer level", Color.Black));
			_gameObjects.Add (new Button(ContentHandler.GetTexture("SquareButton"), new Vector2(305, 200), _game, this, 
				subsLevel));
			_gameObjects.Add (new Text (new Vector2 (395, 200), _game, this, Model.Layout.standartFontName, 
				levelCounter.ToString(), Color.Black));
			levelCounterText = (Text)_gameObjects [_gameObjects.Count - 1];
			_gameObjects.Add (new Button(ContentHandler.GetTexture("SquareButton"), new Vector2(455, 200), _game, this,
				addLevel));
			_gameObjects.Add (new Button(ContentHandler.GetTexture("startbutton_ratCycle"), new Vector2(580, 500), 
				_game, this, nextView));

            levelCounter = Model.Level.Current;
		}

		private void addLevel() 
		{
			if (Model.Level.Reached > levelCounter) 
            {
				levelCounter++;
			}
			levelCounterText.setString (levelCounter.ToString());
		}

		private void subsLevel()
		{
			if (levelCounter > 0) 
            {
				levelCounter--;
			}
			levelCounterText.setString (levelCounter.ToString());
		}

		private void nextView()
		{
			Model.Level.Current = levelCounter;
			_viewController.SetView (new Stage (_game, _viewController, false));
		}
	}
}

