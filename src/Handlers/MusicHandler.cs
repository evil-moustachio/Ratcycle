using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    class MusicHandler
    {
        private Song song;

        public MusicHandler(String location, Game game)
        {
            song = game.Content.Load<Song>(location);
        }

        public MusicHandler(String location, Game game, bool repeat)
        {
            //You MUST use Monogame Pipeline to convert the song to the right format! Else you will get error
            song = ContentHandler.GetMusic("Nova3");
            if (repeat)
                MediaPlayer.IsRepeating = repeat;
        }

        public void Play()
        {
            MediaPlayer.Play(song);
        }

        public void Pause()
        {
            MediaPlayer.Pause();
        }

        public void Stop()
        {
            MediaPlayer.Stop();
        }
    }
}
