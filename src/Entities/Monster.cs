using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class Monster : Entity
	{
		private Healthbar _healthBar;
        protected int _range;
        protected long _atkspd;
        protected long _nextAttack;

        public override Rectangle AttackBox
        {
            get
            {
                return new Rectangle(
                    HitBox.X -_range,
                    HitBox.Y - _range,
                    HitBox.Width + (_range*2),
                    HitBox.Height +(_range*2));
            }
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Ratcycle.Enemy"/> class.
		/// </summary>
		/// <param name="position">Position.</param>
		/// <param name="game">Game.</param>
		/// <param name="view">View.</param>
		/// <param name="texture">Texture.</param>
		/// <param name="speed">Speed.</param>
		/// <param name="health">Health.</param>
		public Monster (Texture2D texture, Vector2 position, Game1 game, View view, Vector2 speed, float health, float damage, int range, float atkspd) 
			: base (texture, position, game, view, Color.White, 1, 1, 1, false, speed)
		{
			_health = health;
            _damage = damage;
            _range = range;
			_atkspd = (long)(atkspd * Model.Time.OneSecondOfTicks);

			_nextAttack = Model.Time.CurrentGameTick;
			_healthBar = new Healthbar (ContentHandler.GetTexture("HealthBarEntity"), _position, new Vector2(0,-25), _game, _parentView, _health);
		}

		/// <summary>
		/// Returns a Vector2 with the next location towards the target.
		/// </summary>
		/// <param name="target">Target.</param>
		public Vector2 Target(Vector2 target)
		{
			Vector2 newPosition;
			float offset;
			float speed = _speed.X;

			// Check if it's a straight line
			if (target.X == _position.X) {
				if (target.Y > _position.Y) 
                {
					offset = speed * -1;
				} 
                else {
					offset = speed;
				}

				newPosition = new Vector2 (_position.X, _position.Y + offset);
			} 
            else if (target.Y == _position.Y) 
            {
				if (target.X > _position.X) 
                {
					offset = speed * -1;
				} 
                else 
                {
					offset = speed;
				}

				newPosition = new Vector2 (_position.X + offset, _position.Y);
			} 
            else 
            {

				// Determine current trianlge
				var diffX = target.X - _position.X;
				var diffY = target.Y - _position.Y;
				var totalDistance = Math.Sqrt (Math.Pow(diffX, 2) + Math.Pow(diffY, 2));

				// New triangle
				var scale = totalDistance / speed;
				var offsetX = diffX / scale;
				var offsetY = diffY / scale;

				// Next position
				var newX = _position.X + offsetX;
				var newY = _position.Y + offsetY;
				newPosition = new Vector2 ((float)newX, (float)newY);
			}

			return newPosition;
		}

        private void Move()
        {
            Stage view = (Stage)_parentView;
            Vector2 nextPosition = Target(((Stage)_parentView).RatPosition);
            Rectangle nextHitbox = new Rectangle((int)nextPosition.X, (int)nextPosition.Y, HitBox.Width, HitBox.Height);

            if (view.NotColliding(this, nextHitbox, _minCoords, _maxCoords))
            {
                _position = nextPosition;
            }
        }

        private void Attack ()
        {
			if (Model.Time.CurrentGameTick >= _nextAttack)
            {
                if (((Stage)_parentView).AttackHandler(this, _damage, AttackBox))
                {
					_nextAttack = Model.Time.CurrentGameTick + _atkspd;
                }

            }
        }


		public override void Update ()
		{
			base.Update ();
            Move();
            Attack();

			_healthBar.SetPositionFromBasePosition (_position);
			_healthBar.Health = _health;
			_healthBar.Update ();
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			base.Draw (spriteBatch);
			_healthBar.Draw (spriteBatch);
		}
	}
}

