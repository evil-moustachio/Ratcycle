using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class PaperBin : Bin
    {
        public PaperBin(Vector2 position, Game1 game, View view)
            : base (ContentHandler.GetTexture("PCSquareButton"), position, game, view, Model.GameRules.Category.Paper)
        {
        }
    }
}
