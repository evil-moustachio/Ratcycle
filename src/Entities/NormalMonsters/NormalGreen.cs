using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class NormalGreen : Monster
    {
        public NormalGreen(Vector2 position, Game1 game, View view)
            : base(ContentHandler.GetTexture("PC_GFT_KLEIN"), position, game, view, new Vector2(1, 1), 100, 2, 15, 1.0f, Model.GameRules.Category.Green, Model.GameRules.Type.Normal)
        {
        }
    }
}
