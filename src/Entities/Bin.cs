using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class Bin : AtlasObject
    {
        private List<Model.GameRules.Category> _contents;
        private Model.GameRules.Category _category;
        private List<PointNotification> _pointNotifications;

        public Bin(Texture2D texture, Vector2 position, Game1 game, View view, Model.GameRules.Category category)
            : base(texture, position, game, view, Color.White, 1, 1, 1, false)
        {
            _contents = new List<Model.GameRules.Category>();
            _category = category;

            _pointNotifications = new List<PointNotification>();
        }

        public virtual void AddGarbage(Garbage garbage)
        {
            _contents.Add(garbage.Category);

            if (_category == garbage.Category)
            {
                // Positive
                Model.GameRules.points += garbage.Points;
                _pointNotifications.Add(new PointNotification( _position, 75f, 30f, "+" + garbage.Points, Color.Green, _game, _parentView, this, "Aero Matics Display-48"));
            }
            else
            {
                // Negative
                Model.GameRules.points -= garbage.Points;
                _pointNotifications.Add(new PointNotification(_position, 75f, 30f, "-" + garbage.Points, Color.Red, _game, _parentView, this, "Aero Matics Display-48"));
            }
        }

        public void UpdatePointNotifications()
        {
            for (int i = _pointNotifications.Count - 1; i >= 0; i--)
            {
                _pointNotifications[i].Update();
            }
        }

        public void DrawUpdateNotifications(SpriteBatch spriteBatch)
        {
            for (int i = _pointNotifications.Count - 1; i >= 0; i--)
            {
                _pointNotifications[i].Draw(spriteBatch);
            }
        }

        public void removePointNotification(PointNotification pointNotification)
        {
            _pointNotifications.Remove(pointNotification);
        }

        public override void Update()
        {
            base.Update();
            UpdatePointNotifications();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
 	         base.Draw(spriteBatch);
             DrawUpdateNotifications(spriteBatch);
        }
    }
}
