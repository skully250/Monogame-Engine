using FaeForest;
using FaeForest.States;
using FaeForest.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FaeGame
{
    class ScreenManager
    {
        public StateEngine stateEngine;
        public State[] states = new State[5];
        private static InputHandler m_input;

        public ScreenManager(bool isActive, GraphicsDeviceManager graphics)
        {
            m_input = new InputHandler(isActive);
            stateEngine = new StateEngine();
            Camera.initialise(new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
            states[0] = new GameState(m_input);
            stateEngine.AddState("Main", states[0]);
            stateEngine.SetState("Main");
        }

        //Render everything on screen
        public void render(SpriteBatch spriteBatch, GameTime gameTime)
        {
            stateEngine.render(spriteBatch, gameTime);
        }

        //Update everything on screen
        public void update(GameTime gameTime)
        {
            stateEngine.update(gameTime);
        }
    }
}
