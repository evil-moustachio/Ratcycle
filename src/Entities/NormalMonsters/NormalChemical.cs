using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    class NormalChemical : Monster
    {

        public NormalChemical(Game1 game, View view)
            : base(ContentHandler.GetTexture("monster_NormalChemical"), game, view, new Vector2(1, 1), (50 + (10 * (float)Model.Stage.Current)), (0.8f + (0.5f * (float)Model.Stage.Current)), 20, 0.5f, Model.GameRules.Category.Chemical, Model.GameRules.Type.Normal)
        {
            _health = (60 + (10 * (float)Model.Stage.Current));
            _damage = (1 + (0.5f * (float)Model.Stage.Current));
        }
    }
}
