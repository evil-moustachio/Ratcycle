using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class MenuInfo : Menu
	{
		private Model.Settings.Key.KeyTypes _currentKeyType = Model.Settings.Key.KeyTypes.Null;
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
				_currentKeyType = Model.Settings.Key.KeyTypes.Left;
				break;
			//right
			case 2:
				_currentKeyType = Model.Settings.Key.KeyTypes.Right;
				break;
			//up
			case 3: 
				_currentKeyType = Model.Settings.Key.KeyTypes.Up;
				break;
			//down
			case 4: 
				_currentKeyType = Model.Settings.Key.KeyTypes.Down;
				break;

			//pick up
			case 5:
				_currentKeyType = Model.Settings.Key.KeyTypes.PickUp;
				break;
			//attack
			case 6:
				_currentKeyType = Model.Settings.Key.KeyTypes.Attack;
				break;
			default:
				Console.WriteLine ("Error: unknown button pressed");
				break;
			}
		}

		private void setKey (Model.Settings.Key.KeyTypes keyType, Keys key)
		{
			if (!checkKeyIsSet (key)) {
				switch (keyType) {
				case Model.Settings.Key.KeyTypes.Left:
					Model.Settings.Key.Left = key;
					break;
				case Model.Settings.Key.KeyTypes.Right:
					Model.Settings.Key.Right = key;
					break;
				case Model.Settings.Key.KeyTypes.Up:
					Model.Settings.Key.Up = key;
					break;
				case Model.Settings.Key.KeyTypes.Down:
					Model.Settings.Key.Down = key;
					break;
				case Model.Settings.Key.KeyTypes.PickUp:
					Model.Settings.Key.PickUp = key;
					break;
				case Model.Settings.Key.KeyTypes.Attack:
					Model.Settings.Key.Attack = key;
					break;
				default:
					Console.WriteLine ("Error: Unknown keytype added");
					break;
				}

				_currentKeyType = Model.Settings.Key.KeyTypes.Null;
			}
		}

		private bool checkKeyIsSet(Keys key)
		{
			if (key == Model.Settings.Key.Left || key == Model.Settings.Key.Right || key == Model.Settings.Key.Up || key == Model.Settings.Key.PickUp || key == Model.Settings.Key.Down || key == Model.Settings.Key.Attack)
				return true;
			return false;
		}

		public override void Update ()
		{
			base.Update ();
			if (_currentKeyType != Model.Settings.Key.KeyTypes.Null && KeyHandler.getCurrentKeyPressed ().Length > 0) {
				setKey (_currentKeyType, KeyHandler.getCurrentKeyPressed () [0]);
			}

//			if (KeyHandler.IsKeyDown (Keys.Up))
//				movable.Position -= new Vector2 (0, 0.3f);
//			if (KeyHandler.IsKeyDown (Keys.Down))
//				movable.Position += new Vector2 (0, 0.3f);
//			if (KeyHandler.IsKeyDown (Keys.Left))
//				movable.Position -= new Vector2 (0.3f, 0);
//			if (KeyHandler.IsKeyDown (Keys.Right))
//				movable.Position += new Vector2 (0.3f, 0);
//			Console.WriteLine (movable.Position);
		}

		public override void Draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			base.Draw (spriteBatch);

			SpriteFont f = ContentHandler.GetFont ("Aero Matics Display-36");

			spriteBatch.DrawString (ContentHandler.GetFont ("Aero Matics Display-36"), Model.Settings.Key.Left.ToString (), 
				UtilHandler.getCenteredPosition(ContentHandler.GetTexture("Button_Square"), _left.Position, 1, 3) - UtilHandler.getCenter(Model.Settings.Key.Left.ToString(), f), 
				Color.White);
			spriteBatch.DrawString (ContentHandler.GetFont ("Aero Matics Display-36"), Model.Settings.Key.Right.ToString (), 
				UtilHandler.getCenteredPosition(ContentHandler.GetTexture("Button_Square"), _right.Position, 1, 3) - UtilHandler.getCenter(Model.Settings.Key.Right.ToString(), f), 
				Color.White);
			spriteBatch.DrawString (ContentHandler.GetFont ("Aero Matics Display-36"), Model.Settings.Key.Up.ToString (), 
				UtilHandler.getCenteredPosition(ContentHandler.GetTexture("Button_Square"), _up.Position, 1, 3) - UtilHandler.getCenter(Model.Settings.Key.Up.ToString(), f), 
				Color.White);
			spriteBatch.DrawString (ContentHandler.GetFont ("Aero Matics Display-36"), Model.Settings.Key.Down.ToString (), 
				UtilHandler.getCenteredPosition(ContentHandler.GetTexture("Button_Square"), _down.Position, 1, 3) - UtilHandler.getCenter(Model.Settings.Key.Down.ToString(), f), 
				Color.White);

			spriteBatch.DrawString (ContentHandler.GetFont ("Aero Matics Display-36"), Model.Settings.Key.PickUp.ToString (), 
				UtilHandler.getCenteredPosition(ContentHandler.GetTexture("Button_Square"), _pickUp.Position, 1, 3) - UtilHandler.getCenter(Model.Settings.Key.PickUp.ToString(), f), 
				Color.White);
			spriteBatch.DrawString (ContentHandler.GetFont ("Aero Matics Display-36"), Model.Settings.Key.Attack.ToString (), 
				UtilHandler.getCenteredPosition(ContentHandler.GetTexture("Button_Wide"), _attack.Position, 1, 3) - UtilHandler.getCenter(Model.Settings.Key.Attack.ToString(), f), 
				Color.White);
		}

		GameObject movable;
	}
}

