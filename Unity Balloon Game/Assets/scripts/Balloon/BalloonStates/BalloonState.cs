using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Core.StateStack;

public interface BalloonState : State
{
    void Update();
    void SetBalloon(Balloon balloon);
}
