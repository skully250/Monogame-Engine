using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaeForest.Utility
{
    class InputHandler
    {
        private bool game;
        public InputHandler(bool game)
        {
            this.game = game;
        }

        public bool KeyDown(Keys keyCode)
        {
            return game == true ? Keyboard.GetState().IsKeyDown(keyCode) : false;
        }

        public bool KeyUp(Keys keyCode)
        {
            return game == true ? Keyboard.GetState().IsKeyUp(keyCode) : false;
        }
    }
}