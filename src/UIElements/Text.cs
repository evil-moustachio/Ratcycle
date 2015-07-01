using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace Ratcycle
{
	public class Text : GameObject
    {
        protected SpriteFont _font;
		protected StringBuilder _text = new StringBuilder();

		public Text(Vector2 position, Game1 game, View view, String fontName, String text, Color color)
			: base(position, game, view, color)
		{
			_font = ContentHandler.GetFont(fontName);
			_text.Append(text);
		}
		public Text(Vector2 position, Game1 game, View view, String fontName, StringBuilder text, Color color)
			: base(position, game, view, color)
		{
			_font = ContentHandler.GetFont(fontName);
			_text = text;
		}

        public override void Draw(SpriteBatch spriteBatch)
        {
			spriteBatch.DrawString(_font, _text, _position, Color);
		}

		public void setString(String text)
		{
			_text.Clear();
			_text.Append(text);
		}

		public void setString(StringBuilder text)
		{
			_text = text;
		}

		public void setString(String text, Vector2 pos)
		{
			setString (text);
			_position = pos;
		}

		public void setString(StringBuilder text, Vector2 pos)
		{
			setString (text);
			_position = pos;
		}

		public Vector2 getSize()
		{
			return UtilHandler.getSize (_text, _font);
		}

		public Vector2 getCenter()
		{
			return UtilHandler.getCenter (_text, _font);
		}

		public Vector2 getCenteredPosition()
		{
			return UtilHandler.getCenteredPosition (_text, _font, _position);
		}

		public Vector2 getCenteredPosition(Vector2 p)
		{
			return UtilHandler.getCenteredPosition (_text, _font, p);
		}
    }
}
