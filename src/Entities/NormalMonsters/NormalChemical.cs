using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    class NormalChemical : Monster
    {

        public NormalChemical(Vector2 position, Game1 game, View view)
            : base(ContentHandler.GetTexture("PC_CHEMISCH_KLEIN"), position, game, view, new Vector2(1, 1), 100, 1, 15, 0.8f, Model.GameRules.Category.Chemical, Model.GameRules.Type.Normal)
        {
        }
    }
}
