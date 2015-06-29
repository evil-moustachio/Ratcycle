using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
    public static class UtilHandler
    {
        public static void Shuffle<T>(this T[] array)
        {
            int n = array.Length;
            Random rng = new Random();
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        public static void Shuffle<T>(this List<T> array)
        {
            int n = array.Count - 1;
            Random rng = new Random();
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

		public static Vector2 getSize(Texture2D t, int columns, int rows)
		{
			return new Vector2 (t.Width / columns, t.Height / rows);
		}

		public static Vector2 getSize(string s, SpriteFont f)
		{
			return f.MeasureString (s);
		}

		public static Vector2 getSize(StringBuilder s, SpriteFont f)
		{
			return f.MeasureString (s);
		}

		public static Vector2 getCenter(Texture2D t, int columns, int rows)
		{
			return getSize(t, columns, rows) / 2;
		}

		public static Vector2 getCenter(string s, SpriteFont f)
		{
			return getSize(s, f) / 2;
		}

		public static Vector2 getCenter(StringBuilder s, SpriteFont f)
		{
			return getSize(s, f);
		}

		public static Vector2 getCenteredPosition(Texture2D t, Vector2 p, int columns, int rows)
		{
			return p + getCenter (t, columns, rows);
		}

		public static Vector2 getCenteredPosition(string s, SpriteFont f, Vector2 p)
		{
			return p + getCenter (s, f);
		}

		public static Vector2 getCenteredPosition(StringBuilder s, SpriteFont f, Vector2 p)
		{
			return p + getCenter(s, f);
		}
    }
}
