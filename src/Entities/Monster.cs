using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
    //This class should become abstract
	public class Monster : Entity
	{
		private Healthbar _healthBar;
        protected int _range;
        protected long _atkspd;
        protected long _nextAttack;
        protected Model.GameRules.Category _cat;
        protected Model.GameRules.Type _type;

        public Model.GameRules.Category Category { get { return _cat; } }
        public Model.GameRules.Type Type { get { return _type; } }

        public override Rectangle AttackBox
        {
            get
            {
                return new Rectangle(
                    HitBox.X - _range,
                    HitBox.Y - _range,
                    HitBox.Width  + (_range*2),
                    HitBox.Height + (_range*2));
            }
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Ratcycle.Monster"/> class.
		/// </summary>
		/// <param name="position">Where the Monster will be spawned.</param>
		/// <param name="game">Game.</param>
		/// <param name="view">View.</param>
		/// <param name="texture">Texture.</param>
		/// <param name="speed">The speed with which the monster will travel.</param>
		/// <param name="health">the Monster's health.</param>
		/// <param name="damage">The amount of damage the Monster may deal.</param>
		/// <param name="range">The Monster's attack range.</param>
		/// <param name="atkspd">Cooldown period for the Monster's attack.</param>
		public Monster(Texture2D texture, Vector2 position, Game1 game, View view, Vector2 speed, float health, float damage, int range, float atkspd, Model.GameRules.Category cat, Model.GameRules.Type type) 
			: base (texture, position, game, view, Color.White, 1, 1, 1, false, speed)
		{
			_health = health;
            _damage = damage;
            _range = range;
			_atkspd = (long)(atkspd * Model.Time.OneSecondOfTicks);
            _cat = cat;
            _type = type;

			_nextAttack = Model.Time.CurrentGameTick;
			_healthBar = new Healthbar (ContentHandler.GetTexture("HealthBarEntity"), _position, new Vector2(0,-25), _game, _parentView, _health);
		}

		/// <summary>
		/// Plots a path towards the specified target. Only returns a position within the speed of the Monster.
		/// </summary>
		/// <param name="target">Target.</param>
		private Vector2 MoveToTarget(Vector2 target)
		{
			// Determines current triangle.
			var diffX = target.X - HitBox.Center.X;
			var diffY = target.Y - HitBox.Bottom;
			var totalDistance = Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));

			// Calculates the sides of the smaller triangle.
			var scale = totalDistance / _speed.X;
			var offsetX = diffX / scale;
			var offsetY = diffY / scale;

			// Uses the sides of the smaller triangle as offset from the old position.
			var newX = _position.X + offsetX;
			var newY = _position.Y + offsetY;
			return new Vector2((float)newX, (float)newY);
		}

		/// <summary>
		/// Updates the Monster's position.
		/// </summary>
        private void Move()
        {
			// Creates the next Hitbox with an updated position.
			Vector2 nextPosition = MoveToTarget(((Stage)_parentView).RatBase);
			Rectangle nextXHitbox = new Rectangle((int)nextPosition.X, (int)_position.Y, HitBox.Width, HitBox.Height);
			Rectangle nextYHitbox = new Rectangle((int)_position.X, (int)nextPosition.Y, HitBox.Width, HitBox.Height);

			// Updates the position if the move is allowed.
			if (((Stage)_parentView).NotColliding(this, nextXHitbox, _minCoords, _maxCoords))
			{
				_position.X = nextPosition.X;
			}
			if (((Stage)_parentView).NotColliding(this, nextYHitbox, _minCoords, _maxCoords))
			{
				_position.Y = nextPosition.Y;
			}
        }

		/// <summary>
		/// Attacks another entity if it is in the Monster's AttackBox
		/// </summary>
        private void Attack()
        {
			if (Model.Time.CurrentGameTick >= _nextAttack)
            {
                if (((Stage)_parentView).AttackHandler(this, _damage, AttackBox))
                {
					_nextAttack = Model.Time.CurrentGameTick + _atkspd;
                }
            }
        }

		/// <summary>
		/// Updates the position and health of the bar to match the Monster's.
		/// Then initiates the HealthBar's Update method.
		/// </summary>
		private void UpdateHealthBar()
		{
			_healthBar.SetPositionFromBasePosition(_position);
			_healthBar.Health = _health;
			_healthBar.Update();
		}
        
        /// <summary>
        /// The monster dies and turns into garbage.
        /// NOTE: This could become an abstract function.
        /// </summary>
        public override void KillEntity()
        {
            ((Stage)_parentView).MonsterToGarbage(this, _texture);
        }

		public override void Update()
		{
			base.Update();
            Move();
            Attack();
			UpdateHealthBar ();
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			_healthBar.Draw(spriteBatch);
		}
	}
}

