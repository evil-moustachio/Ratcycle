using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuStart : View
	{
		public MenuStart (Game1 game, ViewController viewController, Boolean mouseVisible)
			: base(game, viewController, mouseVisible)
		{
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("startmenuBackground"), new Vector2(0,0), _game, this, Color.White, 1, 1, 1, false));
			_gameObjects.Add (new Button (ContentHandler.GetTexture("startbutton_ratCycle"), new Vector2(275, 325), _game, this, nextView));
		}
		private void nextView()
		{
			_viewController.setView(new MenuChooseLevel(_game, _viewController, true));
		}
	}
}

