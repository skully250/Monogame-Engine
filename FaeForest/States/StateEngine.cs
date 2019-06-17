using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace FaeForest.States
{
    class StateEngine
    {
        public static Dictionary<string, State> states;
        private String CurrentState;

        public StateEngine()
        {
            states = new Dictionary<String, State>();
        }

        public void LoadContent(SpriteBatch spriteBatch, ContentManager Content)
        {
            foreach (State states in states.Values)
            {
                states.LoadContent(spriteBatch, Content);
            }
        }

        public void SetState(string name)
        {
            CurrentState = name;
        }

        public void AddState(String name, State state)
        {
            states.Add(name, state);
        }

        public State getCurrentState()
        {
            State current;
            states.TryGetValue(CurrentState, out current);
            return current;
        }

        public void render(SpriteBatch spriteBatch, GameTime gameTime)
        {
            getCurrentState().render(spriteBatch, gameTime);
        }

        public void update(GameTime gameTime)
        {
            getCurrentState().update(gameTime);
        }
    }
}