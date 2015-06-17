using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class ChemicalBin : Bin
    {
        public ChemicalBin(Vector2 position, Game1 game, View view)
            : base(ContentHandler.GetTexture("Entity_BinChemical"), position, game, view, Model.GameRules.Category.Chemical)
        {
        }
    }
}
