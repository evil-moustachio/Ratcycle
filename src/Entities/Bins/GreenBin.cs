using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class GreenBin : Bin
    {
        public GreenBin(Vector2 position, Game1 game, View view)
            : base(ContentHandler.GetTexture("Entity_BinGreen"), position, game, view, Model.GameRules.Category.Green)
        {
        }
    }
}
