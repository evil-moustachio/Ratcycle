using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
    public class Inventory : AtlasObject
    {

        /// <summary>
        /// Displays what the rat picked up
        /// </summary>
        /// <param name="position"></param>
        /// <param name="game"></param>
        /// <param name="view"></param>
        public Inventory(Vector2 position, Game1 game, View view) : base(ContentHandler.GetTexture("inventory"), position, game, view, Color.White, 11, 1, 1, false)
        {
            ChangeFrame(10);
        }

        /// <summary>
        /// Change the inventory's frame to match the specified piece of garbage.
        /// </summary>
        /// <param name="category">The category of garbage.</param>
        /// <param name="type">The type of garbage.</param>
        public void AddGarbage(Model.GameRules.Category category, Model.GameRules.Type type)
        {
            switch (category)
            {
                case Model.GameRules.Category.Chemical:
                    if (type == Model.GameRules.Type.Normal)
                        ChangeFrame(3);
                    if (type == Model.GameRules.Type.Strong)
                        ChangeFrame(8);
                    break;
                case Model.GameRules.Category.Green:
                    if (type == Model.GameRules.Type.Normal)
                        ChangeFrame(2);
                    if (type == Model.GameRules.Type.Strong)
                        ChangeFrame(7);
                    break;
                case Model.GameRules.Category.Other:
                    if (type == Model.GameRules.Type.Normal)
                        ChangeFrame(1);
                    if (type == Model.GameRules.Type.Strong)
                        ChangeFrame(6);
                    break;
                case Model.GameRules.Category.Paper:
                    if (type == Model.GameRules.Type.Normal)
                        ChangeFrame(0);
                    if (type == Model.GameRules.Type.Strong)
                        ChangeFrame(5);
                    break;
                case Model.GameRules.Category.Plastic:
                    if (type == Model.GameRules.Type.Normal)
                        ChangeFrame(9);
                    if (type == Model.GameRules.Type.Strong)
                        ChangeFrame(4);
                    break;
            }
        }

        /// <summary>
        /// Show an empty inventory.
        /// </summary>
        public void RemoveGarbage()
        {
            ChangeFrame(10);
        }
    }
}
