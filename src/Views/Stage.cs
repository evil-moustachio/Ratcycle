using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle.GameFiles.src.Views
{
    public class Stage : View
    {
        public Stage (Game1 game, ViewController viewController) : base (game, viewController)
        {

        }

        public void Update ()
        {
            foreach (GameObject gameObject in _gameObjects)
            {
                gameObject.Update();
            }
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            foreach (GameObject gameObject in _gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }
    }
}
