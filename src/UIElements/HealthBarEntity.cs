using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class HealthBarEntity : AtlasObject
	{
		private Vector2 _offset;
		private Monster _parentMonster;
		private float _health, _maxHealth;

		public float Health {
			set { _health = value; }
		}

		public HealthBarEntity (Texture2D texture, Vector2 position, Vector2 offset, Game1 game, View view, 
			Monster parentMonster, float health) : base (texture, position + offset, game, view, Color.White, 25, 1, 1, false)
		{
			_offset = offset;
			_parentMonster = parentMonster;
			_health = _maxHealth = health;
		}

		public override void Update ()
		{
			base.Update ();

			_position = _parentMonster.Position + _offset;
			ChangeFrame((int)(_health / _maxHealth * -25 + 25));
		}
	}
}

