using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Core.StateStack;
public interface IBalloonController
{
    void Init(Balloon balloon);
    void OnClick();

    void OnRelease();
    void Update();

    StateStack GetStateStack();
}

