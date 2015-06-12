using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class StageHUD : View
	{
		private readonly Healthbar _healthBar;
		private Rat _rat;

		public StageHUD (Game1 game, ViewController viewController, Boolean mouseVisible, Rat rat) 
			: base (game, viewController, mouseVisible)
		{
			_rat = rat;

			_healthBar = new Healthbar (ContentHandler.GetTexture ("HUDHealthbarRat"), 
				new Vector2 (25, 25), 
				new Vector2 (0, 0), _game, this, _rat.Health);

			_gameObjects.Add (_healthBar);
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("HUDRat"), new Vector2(25,25), _game, this, Color.White, 1, 1, 1, false));
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("EscButton"), new Vector2(710, 25), _game, this, Color.White, 1, 1, 1, false));
		}

		public override void Update ()
		{
			base.Update ();
			_healthBar.Health = _rat.Health;
			_healthBar.Update ();
		}

		public void Pause() {

		}

		public void UnPause() {

		}
	}
}

