using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.StateStack
{
    public interface State
    {
        void OnPushed();
        void OnPoped();
        void OnReturnToTop();
        void OnPressed();
    }
}
