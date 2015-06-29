using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class MenuInfo : Menu
	{
		private Model.KeySettings.KeyTypes _currentKeyType = Model.KeySettings.KeyTypes.Null;
		private GameObject _left, _right, _up, _down, _pickUp, _attack;

		public MenuInfo (Game1 game, ViewController viewController, bool mouseVisible) 
			: base (game, viewController, mouseVisible)
		{
			_gameObjects.Add (new AtlasObject (ContentHandler.GetTexture ("Background-0" + Model.Stage.Current), 
				new Vector2 (0, 0), _game, this, Color.White, 1, 1, 1, false));
			_gameObjects.Add (new AtlasObject (ContentHandler.GetTexture ("BackgroundGray"), new Vector2 (0, 0), _game, this, 
				Color.White, 1, 1, 1, false));

			Vector2 position = new Vector2 (_game.GraphicsDevice.Viewport.Width / 2 - ContentHandler.GetTexture ("infoScreen").Width / 2, 
				                   _game.GraphicsDevice.Viewport.Height / 2 - ContentHandler.GetTexture ("infoScreen").Height / 2);
			_gameObjects.Add (new AtlasObject (ContentHandler.GetTexture ("infoScreen"), position, _game, this, Color.White, 1, 1, 1, false));

			//left
			_left = new Button (ContentHandler.GetTexture ("Button_Square"), new Vector2 (109.4f, 167.6f), _game, this, 1, setKey, 1);
			_gameObjects.Add (_left);
			//right
			_right = new Button (ContentHandler.GetTexture ("Button_Square"), new Vector2 (234.8f, 167.6f), _game, this, 1, setKey, 2);
			_gameObjects.Add(_right);
			//up
			_up = new Button (ContentHandler.GetTexture ("Button_Square"), new Vector2 (172.1f, 104.9f), _game, this, 1, setKey, 3);
			_gameObjects.Add(_up);
			//down
			_down = new Button (ContentHandler.GetTexture ("Button_Square"), new Vector2 (172.1f, 167.6f), _game, this, 1, setKey, 4);
			_gameObjects.Add(_down);

			//pickup
			_pickUp = new Button (ContentHandler.GetTexture ("Button_Square"), new Vector2 (380.9f, 167.6f), _game, this, 1, setKey, 5);
			_gameObjects.Add(_pickUp);
			//attack
			_attack = new Button (ContentHandler.GetTexture ("Button_Wide"), new Vector2 (524.3f, 167.6f), _game, this, 1, setKey, 6);
			_gameObjects.Add(_attack);

			_gameObjects.Add (new Button (ContentHandler.GetTexture ("Button_Next"), new Vector2(221.8f, 408.0997f), _game, this, nextView));


			movable = new Text(new Vector2(), _game, this, "Aero Matics Display-18", Model.KeySettings.Left.ToString(), Color.White);
			_gameObjects.Add (movable);
		}

		private void nextView()
		{
			_viewController.SetView (new MenuChooseStage (_game, _viewController, true));
		}

		private void setKey(int i)
		{
			switch (i) {

			//left
			case 1: 
				_currentKeyType = Model.KeySettings.KeyTypes.Left;
				break;
			//right
			case 2:
				_currentKeyType = Model.KeySettings.KeyTypes.Right;
				break;
			//up
			case 3: 
				_currentKeyType = Model.KeySettings.KeyTypes.Up;
				break;
			//down
			case 4: 
				_currentKeyType = Model.KeySettings.KeyTypes.Down;
				break;

			//pick up
			case 5:
				_currentKeyType = Model.KeySettings.KeyTypes.PickUp;
				break;
			//attack
			case 6:
				_currentKeyType = Model.KeySettings.KeyTypes.Attack;
				break;
			default:
				Console.WriteLine ("Error: unknown button pressed");
				break;
			}
		}

		private void setKey (Model.KeySettings.KeyTypes keyType, Keys key)
		{
			switch (keyType) {
			case Model.KeySettings.KeyTypes.Left:
				Model.KeySettings.Left = key;
				break;
			case Model.KeySettings.KeyTypes.Right:
				Model.KeySettings.Right = key;
				break;
			case Model.KeySettings.KeyTypes.Up:
				Model.KeySettings.Up = key;
				break;
			case Model.KeySettings.KeyTypes.Down:
				Model.KeySettings.Down = key;
				break;
			case Model.KeySettings.KeyTypes.PickUp:
				Model.KeySettings.PickUp = key;
				break;
			case Model.KeySettings.KeyTypes.Attack:
				Model.KeySettings.Attack = key;
				break;
			default:
				Console.WriteLine ("Error: Unknown keytype added");
				break;
			}
		}

		public override void Update ()
		{
			base.Update ();
			if (_currentKeyType != Model.KeySettings.KeyTypes.Null && KeyHandler.getCurrentKeyPressed ().Length > 0) {
				setKey (_currentKeyType, KeyHandler.getCurrentKeyPressed () [0]);
				_currentKeyType = Model.KeySettings.KeyTypes.Null;
			}

			if (KeyHandler.IsKeyDown (Keys.Up))
				movable.Position -= new Vector2 (0, 0.3f);
			if (KeyHandler.IsKeyDown (Keys.Down))
				movable.Position += new Vector2 (0, 0.3f);
			if (KeyHandler.IsKeyDown (Keys.Left))
				movable.Position -= new Vector2 (0.3f, 0);
			if (KeyHandler.IsKeyDown (Keys.Right))
				movable.Position += new Vector2 (0.3f, 0);
			Console.WriteLine (movable.Position);
		}

		public override void Draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			base.Draw (spriteBatch);

			SpriteFont f = ContentHandler.GetFont ("Aero Matics Display-36");

			spriteBatch.DrawString (ContentHandler.GetFont ("Aero Matics Display-36"), Model.KeySettings.Left.ToString (), 
				UtilHandler.getCenteredPosition(ContentHandler.GetTexture("Button_Square"), _left.Position, 1, 3) - UtilHandler.getCenter(Model.KeySettings.Left.ToString(), f), 
				Color.White);
			spriteBatch.DrawString (ContentHandler.GetFont ("Aero Matics Display-36"), Model.KeySettings.Right.ToString (), 
				UtilHandler.getCenteredPosition(ContentHandler.GetTexture("Button_Square"), _right.Position, 1, 3) - UtilHandler.getCenter(Model.KeySettings.Right.ToString(), f), 
				Color.White);
			spriteBatch.DrawString (ContentHandler.GetFont ("Aero Matics Display-36"), Model.KeySettings.Up.ToString (), 
				UtilHandler.getCenteredPosition(ContentHandler.GetTexture("Button_Square"), _up.Position, 1, 3) - UtilHandler.getCenter(Model.KeySettings.Up.ToString(), f), 
				Color.White);
			spriteBatch.DrawString (ContentHandler.GetFont ("Aero Matics Display-36"), Model.KeySettings.Down.ToString (), 
				UtilHandler.getCenteredPosition(ContentHandler.GetTexture("Button_Square"), _down.Position, 1, 3) - UtilHandler.getCenter(Model.KeySettings.Down.ToString(), f), 
				Color.White);
		}

		GameObject movable;
	}
}

