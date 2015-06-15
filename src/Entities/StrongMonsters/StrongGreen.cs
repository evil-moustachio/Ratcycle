using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class StrongGreen : Monster
    {
        public StrongGreen(Vector2 position, Game1 game, View view)
            : base(ContentHandler.GetTexture("PC_GFT_GROOT"), position, game, view, new Vector2(1, 1), 100, 1, 15, 0.8f, Model.GameRules.Category.Green, Model.GameRules.Type.Strong)
        {
        }
    }
}
