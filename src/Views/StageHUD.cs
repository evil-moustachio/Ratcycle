using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class StageHUD : View
	{
		private HealthbarEntity _healthBar;
		public StageHUD (Game1 game, ViewController viewController, Boolean mouseVisible, Rat rat) 
			: base (game, viewController, mouseVisible)
		{
			_healthBar = new HealthbarEntity (ContentHandler.GetTexture ("HUDHealthbarRat"), 
				new Vector2 (25, 25), 
				new Vector2 (0, 0), 
				_game, 
				this, 
				rat.Health);

			_gameObjects.Add (_healthBar);
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("HUDRat"), new Vector2(25,25), _game, this, Color.White, 1, 1, 1, false));
		}

		public override void Update ()
		{
			base.Update ();

		}
	}
}

