using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaeForest.Input
{
    class Input
    {
        public Input()
        {

        }

        public static bool KeyDown(Keys keyCode)
        {
            return Keyboard.GetState().IsKeyDown(keyCode);
        }

        public static bool KeyUp(Keys keyCode)
        {
            return Keyboard.GetState().IsKeyUp(keyCode);
        }   
    }
}
