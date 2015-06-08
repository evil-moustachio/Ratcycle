using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
    class Text : UIElement
    {
        private SpriteFont _font;
        private String _text;
        private Color _fontColor;

        public Text(string fontName, String text, Color fontColor, Vector2 position, Texture2D texture, 
					int frameColumns, int frameRows, bool animates, Game1 game, View view)
            : base(position, texture, frameColumns, frameRows, animates, game, view)
        {
			_font = ContentHandler.GetFont(fontName);
            _text = text;
			_fontColor = fontColor;
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, _text, _position, _fontColor);
        }
    }
}
