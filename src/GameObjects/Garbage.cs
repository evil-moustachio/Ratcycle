using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
    public class Garbage : AtlasObject
    {
		private int _points;
		private Model.GameRules.Categories _category;
		private Model.GameRules.Types _type;

		public Model.GameRules.Categories Category
		{
			get { return _category; }
		}

		public Model.GameRules.Types Type
		{
			get { return _type; }
		}

		public Garbage(Texture2D texture, Vector2 position, Game1 game, View view, Color color, Model.GameRules.Categories category, Model.GameRules.Types type, int points)
            : base(texture, position, game, view, color, 1, 1, 1, false)
        {
			_points = points;
			_category = category;
			_type = type;
        }

		public void PickUp()
		{
			_position.X = 100000;
		}
    }
}
