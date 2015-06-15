using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class NormalPlastic : Monster
    {
        public NormalPlastic(Vector2 position, Game1 game, View view)
            : base(ContentHandler.GetTexture("PC_PLASTIC_KLEIN"), position, game, view, new Vector2(1, 1), 100, 1, 15, 0.8f, Model.GameRules.Category.Plastic, Model.GameRules.Type.Normal)
        {
        }
    }
}
