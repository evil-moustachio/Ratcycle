using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class StageHUD : View
	{
		private Stage _stage;

		//Elements that have to be recalled later
		private Rat _rat;
		private readonly Healthbar _healthBar;
		private Text _points;

		//Paused items
		private Boolean _isPaused, _goUnPause;
		private List<GameObject> _overviewItems;

        public Inventory Inventory;

		public StageHUD (Game1 game, ViewController viewController, Boolean mouseVisible, Rat rat, Stage stage) 
			: base (game, viewController, mouseVisible)
		{
			_overviewItems = new List<GameObject>();
			_stage = stage;
			_rat = rat;

			//Rat healthbar
			_healthBar = new Healthbar (ContentHandler.GetTexture ("HUDHealthbarRat"), new Vector2 (25, 25), 
				new Vector2 (0, 0), _game, this, _rat.Health);
			_gameObjects.Add (_healthBar);

            // Rat Inventory
            _gameObjects.Add(new Inventory(new Vector2(97, 67), _game, this));
            Inventory = (Inventory)_gameObjects[_gameObjects.Count - 1];

            // Rat face
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("HUDRat"), new Vector2(25,25), _game, this, 
				Color.White, 1, 1, 1, false));
			_points = new Text (new Vector2(239, 57), _game, this, "Aero Matics Display-14", "0 punten", Color.Black);
			_gameObjects.Add (_points);

			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("Button_Esc"), new Vector2(710, 25), _game, this, 
				Color.White, 1, 1, 1, false));
		}

		public override void Update()
		{
			if (_goUnPause) 
			{
				for (int i = _overviewItems.Count - 1; i >= 0; i--) 
				{
					_gameObjects.Remove (_overviewItems [i]);
					_overviewItems.Remove (_overviewItems [i]);
				}

				_goUnPause = false;
			}

			base.Update();

			_healthBar.Health = _rat.Health;
			_healthBar.Update();
			UpdatePoints ((int)Model.GameRules.points);
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			for (int i = 0; i < _gameObjects.Count; i++) 
			{
				_gameObjects [i].Draw (spriteBatch);
			}
		}


		/// <summary>
		/// Pause the game.
		/// </summary>
		public void Pause() 
		{
			if (!_isPaused) 
			{
				_game.IsMouseVisible = true;
				_isPaused = true;

				createPauseHUD();
			}
		}

		/// <summary>
		/// Unpause the game
		/// </summary>
		public void UnPause() 
		{
			if (_isPaused) 
			{
				_game.IsMouseVisible = false;
				_isPaused = false;
				_goUnPause = true;
			}
		}

		/// <summary>
		/// Creates the pause overlay.
		/// </summary>
		private void createPauseHUD()
		{
            var center = Model.Layout.Center(_game);

			_overviewItems.Add(new AtlasObject(ContentHandler.GetTexture("BackgroundOrange"), new Vector2 (0), _game, this, 
				Color.White, 1, 1, 1, false));

			_overviewItems.Add(new Text(new Vector2(center.X - 150, 100), _game, this,
				Model.Layout.Font.ExtraExtraLarge, "Gepauzeerd", Color.White));

            // Buttons
			_overviewItems.Add(new Button(ContentHandler.GetTexture("Button_hervatten"), 
				center + new Vector2(-ContentHandler.GetTexture("Button_hervatten").Width / 2, -80), 
				_game, this, _stage.Pause));
			_overviewItems.Add(new Button(ContentHandler.GetTexture("Button_opnieuw"),
				center + new Vector2 (-ContentHandler.GetTexture ("Button_opnieuw").Width / 2, 10), _game, this, ResetStage));
			_overviewItems.Add(new Button(
				ContentHandler.GetTexture("Button_stoppen"),
				center + new Vector2 (-ContentHandler.GetTexture ("Button_stoppen").Width / 2, 100), _game, this,
				ToStartMenu));

			for (int i = 0; i < _overviewItems.Count; i++) 
			{
				_gameObjects.Add(_overviewItems[i]);
			}
		}

		public void GameOver()
		{
			_game.IsMouseVisible = true;
			_isPaused = true;

			createGameOverHUD();
		}

		private void createGameOverHUD()
		{
			Vector2 center = new Vector2(_game.GraphicsDevice.Viewport.Width / 2, 
				_game.GraphicsDevice.Viewport.Height / 2);

			_overviewItems.Add(new AtlasObject(ContentHandler.GetTexture("BackgroundOrange"), new Vector2 (0), _game, this, 
				Color.White, 1, 1, 1, false));

			_overviewItems.Add(new Text(new Vector2(center.X - 140, 100), _game, this,
				Model.Layout.Font.ExtraExtraLarge, "Game Over", Color.White));

			_overviewItems.Add(new Button(ContentHandler.GetTexture("Button_opnieuw"),
				center + new Vector2 (-ContentHandler.GetTexture ("Button_opnieuw").Width / 2, -50), _game, this, 
				ResetStage));
			_overviewItems.Add(new Button(ContentHandler.GetTexture("Button_stoppen"),
				center + new Vector2 (-ContentHandler.GetTexture ("Button_stoppen").Width / 2, 50), _game, this,
				ToStartMenu));

			for (int i = 0; i < _overviewItems.Count; i++) 
			{
				_gameObjects.Add(_overviewItems[i]);
			}
		}

		/// <summary>
		/// Updates the points.
		/// </summary>
		/// <param name="points">Points.</param>
		private void UpdatePoints(int points)
		{
			_points.setString (points + " punten");
		}

		private void ResetStage()
		{
            Model.GameRules.points = 0;
			_viewController.SetView(new Stage(_game, _viewController, false));
		}

		private void ToStartMenu()
		{
			_viewController.SetView(new MenuStart(_game, _viewController, true));
		}
	}
}

