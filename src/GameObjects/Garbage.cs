using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace Ratcycle
{
    public class Garbage : AtlasObject
    {
        //Has a type var.
        //Pts/Cat

        public Garbage(Texture2D texture, Vector2 position, Game1 game, View view, Color color)
            : base(texture, position, game, view, color, 1, 1, 1, false)
        {
            
        }

        public void function()
        {
        }

        // function pick up.
    }
}
