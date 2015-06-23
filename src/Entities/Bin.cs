using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class Bin : AtlasObject
    {
		private List<Garbage> _contents;
        private Model.GameRules.Category _category;

		public List<Garbage> Contents { get { return _contents; } }
		public Model.GameRules.Category Category { get { return _category; } }

        public Bin(Texture2D texture, Vector2 position, Game1 game, View view, Model.GameRules.Category category)
            : base(texture, position, game, view, Color.White, 1, 1, 1, false)
        {
			_contents = new List<Garbage>();
            _category = category;
        }

        public virtual void AddGarbage(Garbage garbage)
		{
			_contents.Add (garbage);

			if (_category == garbage.Category) {
				// Positive
				Model.GameRules.points += garbage.Points;
				((Stage)_parentView).NewPlayerFeedback("+" + garbage.Points, Color.Green, _position, 75f, 30f);
                _game.soundEffect = new SoundHandler("Correct", Model.Settings.SoundEffectVolume);
                _game.soundEffect.Play();
			} else {
				// Negative
				Model.GameRules.points -= garbage.Points / 2;
				((Stage)_parentView).NewPlayerFeedback("-" + (garbage.Points / 2), Color.Red, _position, 75f, 30f);
                _game.soundEffect = new SoundHandler("Wrong", Model.Settings.SoundEffectVolume);
                _game.soundEffect.Play();
			}
		}
    }
}
