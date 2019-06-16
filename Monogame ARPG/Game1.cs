using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FaeForest;
using FaeForest.Graphics;
using FaeForest.Utility;

namespace FaeGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteSheet[] spriteSheets = new SpriteSheet[20];
        World world;
        Animation anim1, anim2;
        InputHandler m_input;

        int animFrame = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Camera.initialise(new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
            m_input = new InputHandler(this.IsActive);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            spriteSheets[0] = new SpriteSheet(new Vector2(12, 8), new Vector2(32, 32), "actor110", Content);
            spriteSheets[1] = new SpriteSheet(new Vector2(11, 3), new Vector2(32, 32), "TileSet", Content);
            spriteSheets[2] = new SpriteSheet(new Vector2(12, 5), new Vector2(377, 377), "107826", Content);
            //spriteSheets[1].spriteGrid.Remove("10");
            world = new World(spriteSheets[1].spriteGrid, new Vector2(100, 100), spriteBatch);
            anim1 = new Animation(spriteSheets[0], 32, 0, 0, 3);
            anim2 = new Animation(spriteSheets[2], 377, 0, 0, 11);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        float timer;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > 1f)
            {
                if (animFrame >= 2)
                    animFrame = 0;
                else
                    animFrame++;
                timer = 0;
            }

            world.update();
            Camera.Update(m_input, null, false);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, Camera.TransformMatrix());
            //spriteBatch.Begin();
            world.Draw();
            anim1.Draw(spriteBatch, new Vector2(3, 3), animFrame);
            anim2.ScaledDraw(spriteBatch, new Vector2(10, 10), MathUtility.PixelPercentage(377,64), animFrame);
            //anim2.Draw(spriteBatch, new Vector2(10, 10), animFrame);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}