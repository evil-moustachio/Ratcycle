using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	class Text : GameObject
    {
        private SpriteFont _font;
        private String _text;

		public Text(Vector2 position, Game1 game, View view, String fontName, String text, Color color)
			: base(position, game, view, color)
        {
			_font = ContentHandler.GetFont(fontName);
            _text = text;
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
			spriteBatch.DrawString(_font, _text, _position, _color);
        }

		public void setString(String text)
		{
			_text = text;
		}

		public void setString(String text, Vector2 pos)
		{
			_text = text;
			_position = pos;
		}
    }
}
