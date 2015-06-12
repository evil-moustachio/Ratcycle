using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class StageHUD : View
	{
		private readonly Healthbar _healthBar;
		private Rat _rat;
		private Boolean _isPaused, _goUnPause;
		private List<GameObject> _pausedItems;
		private Stage _stage;

		public StageHUD (Game1 game, ViewController viewController, Boolean mouseVisible, Rat rat, Stage stage) 
			: base (game, viewController, mouseVisible)
		{
			_pausedItems = new List<GameObject> ();
			_stage = stage;
			_rat = rat;

			_healthBar = new Healthbar (ContentHandler.GetTexture ("HUDHealthbarRat"), 
				new Vector2 (25, 25), 
				new Vector2 (0, 0), _game, this, _rat.Health);

			_gameObjects.Add (_healthBar);
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("HUDRat"), new Vector2(25,25), _game, this, 
				Color.White, 1, 1, 1, false));
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("EscButton"), new Vector2(710, 25), _game, this, 
				Color.White, 1, 1, 1, false));
		}

		public override void Update ()
		{
			if (_goUnPause) {
				for (int i = _pausedItems.Count - 1; i >= 0; i--) {
					_gameObjects.Remove (_pausedItems [i]);
					_pausedItems.Remove (_pausedItems [i]);
				}
				_goUnPause = false;
			} else {
				base.Update ();
			}
			_healthBar.Health = _rat.Health;
			_healthBar.Update ();
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			for (int i = 0; i < _gameObjects.Count; i++) {
				_gameObjects [i].Draw (spriteBatch);
			}
		}

		public void Pause() {
			if (!_isPaused) {
				_game.IsMouseVisible = true;
				_isPaused = true;

				Vector2 center = new Vector2 (_game.GraphicsDevice.Viewport.Width / 2, 
					_game.GraphicsDevice.Viewport.Height / 2);

				_pausedItems.Add (new AtlasObject (ContentHandler.GetTexture ("OrangeBG"), new Vector2 (0), _game, this, 
					Color.White, 1, 1, 1, false));

				_pausedItems.Add(new Text(new Vector2(center.X - 100, 100), _game, this,
					Model.Layout.standartFontName, "Gepauzeerd", Color.White));

				_pausedItems.Add (new Button(ContentHandler.GetTexture("startbutton_ratCycle"), 
						center + new Vector2(-ContentHandler.GetTexture("startbutton_ratCycle").Width / 2, 0), 
					_game, this, _stage.Pause));
				_pausedItems.Add (new Button(ContentHandler.GetTexture("SquareButton"), 
					center + new Vector2(-ContentHandler.GetTexture("SquareButton").Width / 2, 100), 
					_game, this, _stage.GoToFinishLevelView));

				for (int i = 0; i < _pausedItems.Count; i++) {
					_gameObjects.Add (_pausedItems [i]);
				}
			}
		}

		public void UnPause() {
			if (_isPaused) {
				_game.IsMouseVisible = false;
				_isPaused = false;
				_goUnPause = true;
			}
		}
	}
}

