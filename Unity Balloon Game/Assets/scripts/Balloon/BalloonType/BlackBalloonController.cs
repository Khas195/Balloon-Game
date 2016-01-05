
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Core.StateStack;

class BlackBalloonController : IBalloonController
{
    StateStack balloonStates;
    Balloon balloon;
    BalloonState normal;


    public void Init (Balloon balloon)
    {
        this.balloon = balloon;
        normal = new BalloonNormal(balloon);
        balloonStates = new StateStack();
        this.balloonStates.Push(normal);

    }
    public void OnClick()
    {
        balloon.StartCoroutine("Explode");
    }


    public void OnRelease()
    {
        return;
    }

    public void Update()
    {
        try
        {
            ((BalloonState)balloonStates.Peek()).Update();
        }
        catch (InvalidCastException)
        {
            Debug.Log("Invalid cast at " + this);
        }
        catch (NullReferenceException)
        {
            Debug.Log("Invalid Null at " + this);
        }
    }

    public StateStack GetStateStack()
    {
        return this.balloonStates;
    }
}