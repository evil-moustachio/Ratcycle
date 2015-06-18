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
            : base(ContentHandler.GetTexture("monster_NormalOther"), game, view, new Vector2(1, 1), 100, 1, 15, 0.8f, Model.GameRules.Category.Other, Model.GameRules.Type.Normal)
        {
        }
    }
}
