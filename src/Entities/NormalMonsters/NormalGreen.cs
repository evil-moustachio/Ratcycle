using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class NormalGreen : Monster
    {
        public NormalGreen(Game1 game, View view)
            : base(ContentHandler.GetTexture("monster_NormalGreen"), game, view, new Vector2(1, 1), (100 + (10 * (float)Model.Stage.Current)),(1.5f + (0.5f * (float)Model.Stage.Current)), 20, 1.0f, Model.GameRules.Category.Green, Model.GameRules.Type.Normal)
        {

        }
    }
}
