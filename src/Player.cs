using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public class Player
	{
		MouseHandler _mouseHandler;
		KeyHandler _keyHandler;

		public Player ()
		{
			_mouseHandler = new MouseHandler ();
			_keyHandler = new KeyHandler ();
		}

		public void Update()
		{
			_mouseHandler.Update ();
			_keyHandler.Update ();
		}

		/// <summary>
		/// Gets the mouse handler.
		/// </summary>
		/// <value>The mouse handler.</value>
		public MouseHandler MouseHandler
		{
			get { return _mouseHandler; }
		}

		/// <summary>
		/// Gets the key handler.
		/// </summary>
		/// <value>The key handler.</value>
		public KeyHandler KeyHandler
		{
			get { return _keyHandler; }
		}
	}
}

