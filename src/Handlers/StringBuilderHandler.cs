using System;
using System.Text;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public static class StringBuilderHandler
	{
		private static SpriteFont f;
		public static StringBuilder CreateStringWithNewLines(string text, int width, string font)
		{
			StringBuilder sb = new StringBuilder ();
			string oldString = text, newString = "";
			bool isRightSize = false;

			f = ContentHandler.GetFont (font);

			while (!isRightSize) {
				newString = oldString [oldString.Length - 1] + newString;
				oldString = oldString.Remove (oldString.Length - 1);

				if (getCurrentWidth(oldString, f) < width) {
					sb.AppendLine (oldString);
					oldString = newString;
					newString = "";
					if (getCurrentWidth(oldString, f) < width) {
						sb.AppendLine (oldString);
						isRightSize = true;
					}
				}
			}

			return sb;
		}

		private static float getCurrentWidth(string s)
		{
			return f.MeasureString (s, f).X;
		}
	}
}

