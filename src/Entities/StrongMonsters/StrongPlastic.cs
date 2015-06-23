using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class StrongPlastic : Monster
    {
        public StrongPlastic(Game1 game, View view)
            : base(ContentHandler.GetTexture("monster_StrongPlastic"), game, view, new Vector2(1, 1), (170 + (10 * (float)Model.Stage.Current)),(1.5f + (1.5f * (float)Model.Stage.Current)), 10, 1.7f, Model.GameRules.Category.Plastic, Model.GameRules.Type.Strong)
        {
        }
    }
}
