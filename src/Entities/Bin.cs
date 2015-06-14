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

        public Bin(Texture2D texture, Vector2 position, Game1 game, View view, Color color, int rows, int columns, int totalFrames, bool animates, Model.GameRules.Category category)
            : base(texture, position, game, view, color, rows, columns, totalFrames, animates)
        {
            _contents = new List<Model.GameRules.Category>();
            _category = category;
        }

        public virtual void AddGarbage(Garbage garbage)
        {
            _contents.Add(garbage.Category);


            if (_category == garbage.Category)
            {
                 Model.GameRules.points += garbage.Points;
            }
        }
    }
}
