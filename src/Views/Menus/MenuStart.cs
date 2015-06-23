using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuStart : Menu
	{
		public MenuStart (Game1 game, ViewController viewController, Boolean mouseVisible)
			: base(game, viewController, mouseVisible)
		{
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("BackgroundStartmenu"), new Vector2(0,0), _game, 
				this, Color.White, 1, 1, 1, false));
			_gameObjects.Add (new Button (ContentHandler.GetTexture("Button_start_gray"), new Vector2(275, 325), 
				_game, this, nextView));
            _game.ChangeMusic("MainTheme");
		}

		private void nextView()
		{
			_viewController.SetView(new MenuInfo(_game, _viewController, true));
		}
	}
}

