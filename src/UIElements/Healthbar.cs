using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class Healthbar : AtlasObject
	{
		private Vector2 _offset;
		private float _health, _maxHealth;

		public float Health {
			set { _health = value; }
		}

		public Healthbar (Texture2D texture, Vector2 position, Vector2 offset, Game1 game, View view, 
			float health)
			: base (texture, position + offset, game, view, Color.White, 25, 1, 1, false)
		{
			_offset = offset;
			_health = _maxHealth = health;
		}

		public void SetPositionFromBasePosition(Vector2 v) {
			_position = v + _offset;
		}

		public override void Update ()
		{
			base.Update ();

			ChangeFrame((int)(_health / _maxHealth * -25 + 25));
		}
	}
}

