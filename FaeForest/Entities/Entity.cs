using FaeForest.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FaeForest.Entities
{
    class Entity : IEntity
    {
        //Graphical
        private Sprite m_sprite;
        private Animation m_animation;

        //Mathematical
        private Vector2 m_position;
        private EntityStateManager states;

        public Entity(Vector2 position, Sprite sprite, int layer)
        {
            m_sprite = sprite;
            m_position = position;
            states = new EntityStateManager();
        }

        public Entity(Vector2 position, Animation animation, int layer)
        {
            m_animation = animation;
            m_position = position;
            states = new EntityStateManager();
        }

        public void render(SpriteBatch spriteBatch, GameTime gameTime)
        {
            m_sprite.Draw(m_position, spriteBatch);
        }

        public void update(GameTime gameTime)
        {
            
        }
    }
}