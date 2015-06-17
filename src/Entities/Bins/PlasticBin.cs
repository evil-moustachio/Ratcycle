using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class PlasticBin : Bin
    {
        public PlasticBin(Vector2 position, Game1 game, View view)
            : base(ContentHandler.GetTexture("Entity_BinPlastic"), position, game, view, Model.GameRules.Category.Plastic)
        {
        }
    }
}
