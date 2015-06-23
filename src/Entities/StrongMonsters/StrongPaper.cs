using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class StrongPaper : Monster
    {
        public StrongPaper(Game1 game, View view)
            : base(ContentHandler.GetTexture("monster_StrongPaper"), game, view, new Vector2(1, 1), (140 + (10 * (float)Model.Stage.Current)), (1.2f + (0.8f * (float)Model.Stage.Current)), 10, 1.4f, Model.GameRules.Category.Paper, Model.GameRules.Type.Strong)
        {
        }
    }
}
