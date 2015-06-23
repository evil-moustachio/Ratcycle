using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class NormalOther : Monster
    {
        public NormalOther(Game1 game, View view)
            : base(ContentHandler.GetTexture("monster_NormalOther"), game, view, new Vector2(1, 1), (60 + (10 * (float)Model.Stage.Current)),(0.7f + (0.5f * (float)Model.Stage.Current)), 20, 0.9f, Model.GameRules.Category.Other, Model.GameRules.Type.Normal)
        {
        }
    }
}
