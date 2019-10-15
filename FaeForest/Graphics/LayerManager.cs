using FaeForest.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FaeForest.Graphics
{
    class LayerManager
    {
        private Dictionary<int, Dictionary<int, Entity>> layerDict;

        public LayerManager()
        {
                layerDict = new Dictionary<int, Dictionary<int, Entity>>();
        }

        public void addSprite(int layer, Entity entity)
        {
            Dictionary<int, Entity> internalDict;
            if (!layerDict.TryGetValue(layer, out internalDict)) {
                internalDict = new Dictionary<int, Entity>();
                internalDict.Add(0, entity);
            } else {
                internalDict.Add(internalDict.Count + 1, entity);
            }
        }

        public void removeSprite(int layer, int count)
        {
            Dictionary<int, Entity> internalDict;
            layerDict.TryGetValue(layer, out internalDict);
            layerDict.Remove(count);
        }

        public void render(bool animated, SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Dictionary<int, Entity> internalDict in layerDict.Values)
            {
                foreach (Entity entity in internalDict.Values)
                {
                    entity.render(spriteBatch, gameTime);
                }
            }
        }
    }
}
