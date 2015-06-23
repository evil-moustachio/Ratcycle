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
			f = ContentHandler.GetFont (font);

			StringBuilder sb = new StringBuilder ();

			string[] originalLines = text.Split (new string[] { " " }, StringSplitOptions.None);
			string newLine = "";

			foreach (string word in originalLines) {
				if (getCurrentWidth (newLine) + getCurrentWidth (" " + word) <= width) {
					if (word == originalLines [0]) {
						newLine += word;
					} else {
						newLine += " " + word;
					}
				} else {
					sb.AppendLine (newLine);
					newLine = word;
				}
			}
			sb.AppendLine (newLine);

			return sb;

		}

		private static float getCurrentWidth(string s)
		{
			return f.MeasureString (s).X;
		}
	}
}

