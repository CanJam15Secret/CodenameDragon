using Artemis.Interface;
using System;

namespace lifedungeon.Components
{
    public class RenderComponent : IComponent
    {
        public RenderComponent(String spriteSheet, int spriteNo)
        {
            this.spriteSheet = spriteSheet;
            this.spriteNo = spriteNo;
        }

        public String spriteSheet { get; private set; }
        public int spriteNo { get; private set; }
    }
}
