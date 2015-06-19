using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
    public class PointNotification : Text
    {
        private float _duration;
        private Vector2 _target;
        private float _speed;
        private int _counter;

        private Bin _parent;

        /// <summary>
        /// Gives the player feedback on his actions.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="distance"></param>
        /// <param name="duration"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
        /// <param name="parent"></param>
        /// <param name="fontName"></param>
        public PointNotification(Vector2 position, float distance, float duration, string text, Color color, Game1 game, View view, Bin parent, string fontName)
            : base(position, game, view, fontName, text, color)
        {
            _parent = parent;
            _duration = duration;
            _target = new Vector2(_position.X, _position.Y - distance);
            _speed = distance / _duration;
            _counter = 0;
        }

        /// <summary>
        /// Moves the object
        /// </summary>
        public void Move()
        {
            _position.Y -= _speed;
        }

        /// <summary>
        /// Fades the color of the object linearly.
        /// </summary>
        public void Fade()
        {
            var updatesLeft = _duration - _counter;
            Vector4 color = _color.ToVector4();
            color.X -= (color.X / updatesLeft);
            color.Y -= (color.Y / updatesLeft);
            color.Z -= (color.Z / updatesLeft);
            color.W -= (color.W / updatesLeft);
            _color = new Color(color);
        }
        
        public override void Update()
        {
            // Check if it has reached the target.
            if (_position.Y >= _target.Y)
            {
                Move();

                // Starts fading after a third of the time.
                if (_counter >= (_duration / 3))
                    Fade();

                // Keeps track of how many updates the Notification has had.
                _counter++;
            }
            else
            {
                // Target reached, Kill this instance.
                _parent.removePointNotification(this);
            }
        }
    }
}
