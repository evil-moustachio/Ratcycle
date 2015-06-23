using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
    public class Garbage : AtlasObject
    {
		private int _points;
		private Model.GameRules.Category _category;
		private Model.GameRules.Type _type;

		public Model.GameRules.Category Category
		{
			get { return _category; }
		}

		public Model.GameRules.Type Type
		{
			get { return _type; }
		}
        
        public int Points
        {
            get { return _points; }
        }

		public Garbage(Texture2D texture, Vector2 position, Game1 game, View view, bool flip, Color color, Model.GameRules.Category category, Model.GameRules.Type type, int points)
            : base(texture, position, game, view, color, 4, 1, 1, false)
        {
			_points = points;
			_category = category;
			_type = type;

            if (flip)
                ChangeFrame(2);
            else
                ChangeFrame(3);
        }

		public void PickUp()
		{
			_position.X = 100000;
		}
    }
}
