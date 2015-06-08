using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class MenuStart : View
	{
		public MenuStart (Game1 game, ViewController viewController, Boolean MouseVisible) : base(game, viewController, MouseVisible)
		{
		}

		public override void Initialize() {
			base.Initialize();
			_gameObjects.Add (new Button (new Vector2(0,0), _game, this, ContentHandler.GetTexture("StartButton"), 3, 1));
		}
	}
}

