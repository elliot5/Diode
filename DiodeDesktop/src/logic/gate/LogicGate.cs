using DiodeDesktop.src.logic.node;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiodeDesktop.src.logic.gate
{
    abstract class LogicGate
    {
        //Updating
        public abstract void UpdateLogic(GameTime gameTime);

        //Location
        public abstract Rectangle GetBounds();

        //Creation/Style
        public abstract void Initialize(int x, int y);
        public abstract Color GetColor();

        //IO
        public abstract void CalculateGate(int input, int output);
        public abstract int GetInputCount();
        public abstract int GetOutputCount();
        public abstract List<LogicNode> GetNodes();

    }
}
