using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class SoundHandler
    {
        SoundEffect effect;
        SoundEffectInstance instance;

        public SoundHandler(String location, float volume)
        {
            //You MUST use Monogame Pipeline to convert the song to the right format! Else you will get error
            effect = ContentHandler.GetSoundEffect(location);
            instance = effect.CreateInstance();
            instance.Volume = volume;
        }

        public SoundHandler(String location, float volume, bool loop)
        {
            //You MUST use Monogame Pipeline to convert the song to the right format! Else you will get error
            effect = ContentHandler.GetSoundEffect(location);
            instance = effect.CreateInstance();
            if (loop)
            {
                instance.IsLooped = loop;
            }
            instance.Volume = volume;
        }

        public void Play()
        {
            instance.Play();
        }

        public void Pause()
        {
            instance.Pause();
        }

        public void Stop()
        {
            instance.Stop();
        }

        public bool IsPlaying()
        {
            if (instance.State == SoundState.Playing)
                return true;
            else
                return false;
        }

        public bool IsPaused()
        {
            if (instance.State == SoundState.Paused)
                return true;
            else
                return false;
        }

        public bool IsStopped()
        {
            if (instance.State == SoundState.Stopped)
                return true;
            else
                return false;
        }

        public string GetName()
        {
            string name = effect.Name;
            string strToReplace = "Audio/" + ContentHandler.GetDevice() + "/";
            name = name.Replace(strToReplace, "");
            return name;
        }
    }
}
