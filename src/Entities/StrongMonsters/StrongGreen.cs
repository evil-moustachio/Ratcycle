using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class StrongGreen : Monster
    {
        public StrongGreen(Game1 game, View view)
            : base(ContentHandler.GetTexture("monster_StrongGreen"), game, view, new Vector2(1, 1), (190 + (10 * (float)Model.Stage.Current)), (1.3f + (1.5f * (float)Model.Stage.Current)), 10, 1.8f, Model.GameRules.Category.Green, Model.GameRules.Type.Strong)
        {

        }
    }
}
