using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    class NormalPaper : Monster
    {
        public NormalPaper(Game1 game, View view)
            : base(ContentHandler.GetTexture("monster_NormalPaper"), game, view, new Vector2(1, 1), (30 + (10 * (float)Model.Stage.Current)),(0.5f + (0.1f * (float)Model.Stage.Current)), 20, 0.8f, Model.GameRules.Category.Paper, Model.GameRules.Type.Normal)
        {
        }
    }
}
