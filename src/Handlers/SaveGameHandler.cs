using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ratcycle
{
    public class SaveGameHandler
    {
        private string pathString;
        private string fileName;

        public SaveGameHandler()
        {
            pathString = @Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            fileName = "SaveGame.txt";
            pathString = Path.Combine(pathString, fileName);
            checkIfSafeGamePersists();
        }

        public void SaveGame()
        {
            string[] lines = { 
                Model.Settings.Key.Up.ToString(),
                Model.Settings.Key.Left.ToString(),
                Model.Settings.Key.Down.ToString(),
                Model.Settings.Key.Right.ToString(),
                Model.Settings.Key.PickUp.ToString(),
                Model.Settings.Key.Attack.ToString(),
                Model.Stage.Reached.ToString(),
                Model.Rat.level.ToString(),
                Model.Rat.exp.ToString()
            };
            File.WriteAllLines(pathString, lines);
        }

        public void LoadGame()
        {
            Keys up = (Keys)Enum.Parse(typeof(Keys), File.ReadLines(pathString).Skip(0).Take(1).First(), true);
            Keys left = (Keys)Enum.Parse(typeof(Keys), File.ReadLines(pathString).Skip(1).Take(1).First(), true);
            Keys down = (Keys)Enum.Parse(typeof(Keys), File.ReadLines(pathString).Skip(2).Take(1).First(), true);
            Keys right = (Keys)Enum.Parse(typeof(Keys), File.ReadLines(pathString).Skip(3).Take(1).First(), true);
            Keys pickUp = (Keys)Enum.Parse(typeof(Keys), File.ReadLines(pathString).Skip(4).Take(1).First(), true);
            Keys attack = (Keys)Enum.Parse(typeof(Keys), File.ReadLines(pathString).Skip(5).Take(1).First(), true);
            int reachedStage = Int32.Parse(File.ReadLines(pathString).Skip(6).Take(1).First());
            long level = Int64.Parse(File.ReadLines(pathString).Skip(7).Take(1).First());
            float exp = Int32.Parse(File.ReadLines(pathString).Skip(8).Take(1).First());

            Model.Settings.Key.Up = up;
            Model.Settings.Key.Left = left;
            Model.Settings.Key.Down = down;
            Model.Settings.Key.Right = right;
            Model.Settings.Key.PickUp = pickUp;
            Model.Settings.Key.Attack = attack;
            Model.Stage.Reached = reachedStage;
            Model.Stage.CurrentPlaying = reachedStage;
            Model.Rat.level = level;
            Model.Rat.exp = exp;
        }

        public void ResetProgress()
        {
            string[] lines = { 
                "W",
                "A",
                "S",
                "D",
                "F",
                "Space",
                "1",
                "1",
                "0"
            };
            File.WriteAllLines(pathString, lines);
        }

        private void checkIfSafeGamePersists()
        {
            if (!File.Exists(pathString))
            {
                ResetProgress();
            }
        }
    }
}
