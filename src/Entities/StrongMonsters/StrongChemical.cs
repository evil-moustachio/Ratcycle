using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class StrongChemical : Monster
    {
        public StrongChemical(Game1 game, View view)
            : base(ContentHandler.GetTexture("monster_StrongChemical"), game, view, new Vector2(1, 1), 100, 1, 15, 0.8f, Model.GameRules.Category.Chemical, Model.GameRules.Type.Strong)
        {
        }
    }
}
