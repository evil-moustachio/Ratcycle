using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class RectangleDrawer : GameObject
	{
		Rectangle _rectangle;
		Texture2D _texture;
		Color _rectangleColor;
		
		public RectangleDrawer (Rectangle rectangle, Game1 game, View view, Color color) 
			: base(new Vector2(rectangle.Width, rectangle.Height), game, view, color)
		{
			_rectangle = rectangle;

			SetColor(color);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw (_texture, _position, _color);
		}

		public void SetTexture(Texture2D t)
		{
			_texture = t;
		}

		public void SetRectangle(Rectangle r)
		{
			Texture2D t = new Texture2D(_game.GraphicsDevice, r.Width, r.Height);
			Color[] c = new Color[t.Width * t.Height];

			for (int i = 0; i < c.Length; i++) 
			{
				c[i] = _rectangleColor;
			}

			t.SetData(c);
			SetTexture (t);
		}

		public void SetColor(Color c)
		{
			_rectangleColor = c;

			SetRectangle(_rectangle);
		}
	}
}

