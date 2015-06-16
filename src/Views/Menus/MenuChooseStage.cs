using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuChooseStage : Menu
	{
		private GameObject _moveable;
		private Button[] _stageButtons = new Button[5];
		private Text[] _levelCounterText = new Text[5];


		public MenuChooseStage (Game1 game, ViewController viewController, Boolean mouseVisible) : base(game, viewController, mouseVisible)
		{
			//Background
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("background_ratCycle"), new Vector2(0,0), _game, 
				this, Color.White, 1, 1, 1, false));
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("GrayBackground"), new Vector2(0,0), _game, this, 
				Color.White, 1, 1, 1, false));

			//Orange background
			_gameObjects.Add (new AtlasObject (ContentHandler.GetTexture ("OrangeBG"), new Vector2 (0), _game, this, 
				Color.White, 1, 1, 1, false));

			//Select level text
			_gameObjects.Add (new Text(new Vector2(188.2f, 90.4f), _game, this, "Aero Matics Display-48", 
				"Selecteer level", Color.White));

			//Select-level add/substract buttons
			_gameObjects.Add (new Button (ContentHandler.GetTexture ("LeftButton"), new Vector2 (76.8f, 335.3f), _game, this, subsLevel));
			_gameObjects.Add (new Button(ContentHandler.GetTexture("RightButton"), new Vector2(697f, 335.3f), _game, this, subsLevel));

			//Select level buttons and text
			float[] xCoordinatesButtons = {109, 226, 343, 460, 577};
			float[] xCoordinatesText = {157, 274, 389, 509, 622};
			for (int i = 0; i < 5; i++) {
				_levelCounterText [i] = new Text (new Vector2 (xCoordinatesText [i], 278), _game, this, "Aero Matics Display-28", "0", Color.White);
				_stageButtons [i] = new Button (ContentHandler.GetTexture ("PC_ChooseLevelButtons-0" + (i + 1)), new Vector2 (xCoordinatesButtons [i], 320.9f), _game, this, nextView, 3);
				_gameObjects.Add (_levelCounterText[i]);
				_gameObjects.Add(_stageButtons[i]);
			}
			updateStages ();
			
			//Next button
			_gameObjects.Add (new Button(ContentHandler.GetTexture("startbutton_ratCycle"), new Vector2(277.5f, 444), 
				_game, this, nextView));
		}

		private void addLevel() 
		{
		}

		private void subsLevel()
		{
		}

		private void nextView()
		{
			_viewController.SetView (new Stage (_game, _viewController, false));
		}

		private void updateStages()
		{
			
		}

		public override void Update ()
		{
			base.Update ();

			//TODO: remove this (and make position in gameobject get only again)
			float speed;
			if (KeyHandler.IsKeyDown (Microsoft.Xna.Framework.Input.Keys.LeftShift)) {
				speed = 1f;
			} else {
				speed = 0.1f;
			}
			if (KeyHandler.IsKeyDown (Microsoft.Xna.Framework.Input.Keys.Left)) {
				_moveable.Position -= new Vector2(speed, 0);
			}
			if (KeyHandler.IsKeyDown (Microsoft.Xna.Framework.Input.Keys.Right)) {
				_moveable.Position += new Vector2(speed, 0);
			}
			if (KeyHandler.IsKeyDown (Microsoft.Xna.Framework.Input.Keys.Up)) {
				_moveable.Position -= new Vector2(0, speed);
			}
			if (KeyHandler.IsKeyDown (Microsoft.Xna.Framework.Input.Keys.Down)) {
				_moveable.Position += new Vector2(0, speed);
			}
			Console.WriteLine (_moveable.Position);
		}
	}
}

