using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class NormalPlastic : Monster
    {
        public NormalPlastic(Game1 game, View view)
            : base(ContentHandler.GetTexture("monster_NormalPlastic"), game, view, new Vector2(1, 1), (80 + (10 * (float)Model.Stage.Current)), (0.6f + (0.5f * (float)Model.Stage.Current)), 20, 1.0f, Model.GameRules.Category.Plastic, Model.GameRules.Type.Normal)
        {

        }
    }
}
