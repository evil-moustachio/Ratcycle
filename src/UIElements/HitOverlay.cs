using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class HitOverlay : GameObject
	{
		private Texture2D _texture;
		private float _alpha = 0.3f, timer = 1;

		public HitOverlay (Game1 game, View view) : base (new Vector2(), game, view, Color.White)
		{
			_texture = ContentHandler.GetTexture ("HitOverlay");
		}

		public override void Update()
		{
			float newAlpha = 4 / timer;
			_alpha = newAlpha < _alpha ? newAlpha : _alpha;
			timer++;
			if (_alpha < 0.05f)
				((StageHUD)_parentView).removeItemFromGameObjects (this);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw (_texture, _position, _color * _alpha);
		}
	}
}

