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
            : base(ContentHandler.GetTexture("monster_StrongChemical"), game, view, new Vector2(1, 1),
				(180 + (10 * (float)Model.Stage.Current)), (1.8f + (1.5f * (float)Model.Stage.Current)),  10, 2.0f, 
				Model.GameRules.Category.Chemical, Model.GameRules.Type.Strong)
        {
        }
    }
}
