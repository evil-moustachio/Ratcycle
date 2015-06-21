using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    class SoundEffectHandler
    {
        SoundEffect effect;
        

        public SoundEffectHandler(String location, Game game)
        {
            //You MUST use Monogame Pipeline to convert the song to the right format! Else you will get error
            effect = ContentHandler.GetSoundEffect(location);
        }

        public SoundEffectHandler(String location, Game game, bool loop)
        {
            //You MUST use Monogame Pipeline to convert the song to the right format! Else you will get error
            effect = ContentHandler.GetSoundEffect(location);
            SoundEffectInstance instance = effect.CreateInstance();
            if (loop)
            {
                instance.IsLooped = loop;
            }
        }

        public void Play()
        {
            effect.Play();
        }
    }
}
