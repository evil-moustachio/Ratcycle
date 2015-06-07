using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
    class Text : UIElement
    {
        private SpriteFont _font;
        private String _text;
        private Color _textColor;

        public Text(SpriteFont font, String text, Color textColor, Vector2 position, Texture2D texture, int frameColumns, int frameRows, bool animates, Game1 game, View view)
            : base(position, texture, frameColumns, frameRows, animates, game, view)
        {
            _font = font;
            _text = text;
            _textColor = textColor;
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, _text, _position, _textColor);
        }
    }
}
