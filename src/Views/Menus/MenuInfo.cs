using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuInfo : Menu
	{
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

			_gameObjects.Add (new Button (ContentHandler.GetTexture ("Button_Next"), new Vector2(221.8f, 408.0997f), _game, this, nextView));
		}

		private void nextView()
		{
			_viewController.SetView (new MenuChooseStage (_game, _viewController, true));
		}
	}
}

