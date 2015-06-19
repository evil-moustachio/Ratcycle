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
		private AtlasObject _inventoryBG, _inventory;
		private Text _points;

		//Paused items
		private Boolean _isPaused, _goUnPause;
		private List<GameObject> _pausedItems;

		public StageHUD (Game1 game, ViewController viewController, Boolean mouseVisible, Rat rat, Stage stage) 
			: base (game, viewController, mouseVisible)
		{
			_pausedItems = new List<GameObject> ();
			_stage = stage;
			_rat = rat;

			//Rat items
			_healthBar = new Healthbar (ContentHandler.GetTexture ("HUDHealthbarRat"), new Vector2 (25, 25), 
				new Vector2 (0, 0), _game, this, _rat.Health);
			_gameObjects.Add (_healthBar);
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("HUDRat"), new Vector2(25,25), _game, this, 
				Color.White, 1, 1, 1, false));
			_points = new Text (new Vector2(239, 57), _game, this, "Aero Matics Display-14", "0 punten", Color.Black);
			_gameObjects.Add (_points);

			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("ButtonEsc"), new Vector2(710, 25), _game, this, 
				Color.White, 1, 1, 1, false));
		}

		public override void Update ()
		{
			if (_goUnPause) 
            {
				for (int i = _pausedItems.Count - 1; i >= 0; i--) 
                {
					_gameObjects.Remove (_pausedItems [i]);
					_pausedItems.Remove (_pausedItems [i]);
				}

				_goUnPause = false;
			}

			base.Update ();

			_healthBar.Health = _rat.Health;
			_healthBar.Update ();
			UpdatePoints (Model.GameRules.points);
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
			Vector2 center = new Vector2(_game.GraphicsDevice.Viewport.Width / 2, 
				_game.GraphicsDevice.Viewport.Height / 2);

			_pausedItems.Add(new AtlasObject(ContentHandler.GetTexture("BackgroundOrange"), new Vector2 (0), _game, this, 
				Color.White, 1, 1, 1, false));

			_pausedItems.Add(new Text(new Vector2(center.X - 100, 100), _game, this,
				Model.Layout.standartFontName, "Gepauzeerd", Color.White));

			_pausedItems.Add(new Button(ContentHandler.GetTexture("ButtonStart"), 
				center + new Vector2(-ContentHandler.GetTexture("ButtonStart").Width / 2, 0), 
				_game, this, _stage.Pause));
			_pausedItems.Add(new Button(ContentHandler.GetTexture("PCSquareButton"), 
				center + new Vector2(-ContentHandler.GetTexture("PCSquareButton").Width / 2, 100), 
				_game, this, _stage.NextView));

			for (int i = 0; i < _pausedItems.Count; i++) 
			{
				_gameObjects.Add(_pausedItems[i]);
			}
		}

		/// <summary>
		/// Draws the garbage in the HUD.
		/// </summary>
		/// <param name="cat">Category.</param>
		/// <param name="type">Type.</param>
		public void DrawGarbage(Model.GameRules.Category cat, Model.GameRules.Type type)
		{
			Vector2 v = new Vector2 (140, 100);

			_inventoryBG = new AtlasObject (ContentHandler.GetTexture ("pcInventory"), new Vector2 (100, 80), _game, 
				this, Color.White, 1, 1, 1, false);

			if (cat == Model.GameRules.Category.Plastic) 
			{
				if (type == Model.GameRules.Type.Normal) 
				{
					_inventory = new AtlasObject (ContentHandler.GetTexture ("monster_NormalPlastic"), v, _game, this, 
						Color.White, 1, 1, 1, false);
				} 
				else 
				{
					_inventory = new AtlasObject (ContentHandler.GetTexture ("monster_StrongPlastic"), v, _game, this, 
						Color.White, 1, 1, 1, false);
				}
			} 
			else if (cat == Model.GameRules.Category.Paper) 
			{
				if (type == Model.GameRules.Type.Normal) 
				{
					_inventory = new AtlasObject (ContentHandler.GetTexture ("monster_NormalPaper"), v, _game, this, 
						Color.White, 1, 1, 1, false);
				} 
				else 
				{
					_inventory = new AtlasObject (ContentHandler.GetTexture ("monster_StrongPaper"), v, _game, this, 
						Color.White, 1, 1, 1, false);
				}
			}  
			else if (cat == Model.GameRules.Category.Chemical) 
			{
				if (type == Model.GameRules.Type.Normal) 
				{
					_inventory = new AtlasObject (ContentHandler.GetTexture ("monster_NormalChemical"), v, _game, this, 
						Color.White, 1, 1, 1, false);
				} 
				else 
				{
					_inventory = new AtlasObject (ContentHandler.GetTexture ("monster_StrongChemical"), v, _game, this, 
						Color.White, 1, 1, 1, false);
				}
			}
			else if (cat == Model.GameRules.Category.Green) 
			{
				if (type == Model.GameRules.Type.Normal) 
				{
					_inventory = new AtlasObject (ContentHandler.GetTexture ("monster_NormalGreen"), v, _game, this, 
						Color.White, 1, 1, 1, false);
				} 
				else 
				{
					_inventory = new AtlasObject (ContentHandler.GetTexture ("monster_StrongGreen"), v, _game, this, 
						Color.White, 1, 1, 1, false);
				}
			} 
			else if (cat == Model.GameRules.Category.Other) 
			{
				if (type == Model.GameRules.Type.Normal) 
				{
					_inventory = new AtlasObject (ContentHandler.GetTexture ("monster_NormalOther"), v, _game, this, 
						Color.White, 1, 1, 1, false);
				} 
				else 
				{
					_inventory = new AtlasObject (ContentHandler.GetTexture ("monster_StrongOther"), v, _game, this, 
						Color.White, 1, 1, 1, false);
				}
			}

			_gameObjects.Add (_inventoryBG);
			_gameObjects.Add (_inventory);
		}

		/// <summary>
		/// Removes the garbage from the HUD.
		/// </summary>
		public void RemoveGarbage()
		{
			_gameObjects.Remove (_inventoryBG);
			_gameObjects.Remove (_inventory);
		}

		/// <summary>
		/// Updates the points.
		/// </summary>
		/// <param name="points">Points.</param>
		private void UpdatePoints(int points)
		{
			_points.setString (points + " punten");
		}
	}
}

