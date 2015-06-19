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

        public Bin(Texture2D texture, Vector2 position, Game1 game, View view, Model.GameRules.Category category)
            : base(texture, position, game, view, Color.White, 1, 1, 1, false)
        {
            _contents = new List<Model.GameRules.Category>();
            _category = category;
        }

        public virtual void AddGarbage(Garbage garbage)
		{
			_contents.Add (garbage.Category);

			if (_category == garbage.Category) {
				// Positive
				Model.GameRules.points += garbage.Points;
				((Stage)_parentView).addPointNotification("+" + garbage.Points, Color.Green, _position, 75f, 30f);
			} else {
				// Negative
				Model.GameRules.points -= garbage.Points;
				((Stage)_parentView).addPointNotification("-" + garbage.Points, Color.Red, _position, 75f, 30f);
			}
		}
    }
}
