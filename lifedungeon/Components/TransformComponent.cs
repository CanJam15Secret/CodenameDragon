using Artemis.Interface;
using Microsoft.Xna.Framework;

namespace lifedungeon.Components
{
    public class TransformComponent : IComponent
    {
        public TransformComponent()
        {
            this.position = new Vector2(0f, 0f);
        }
        public TransformComponent(Vector2 position)
        {
            this.position = position;
        }

        public Vector2 position { get; set; }
    }
}
