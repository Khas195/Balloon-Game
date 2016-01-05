using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Core.StateStack;
class DefaultController : IBalloonController
{
    StateStack balloonStates;

    BalloonState normal;
    BalloonState pickedUp;
    BalloonState travelClosetLane;

    public void Init(Balloon balloon)
    {
        normal = new BalloonNormal(balloon);
        pickedUp = new BalloonPickedUp(balloon);
        travelClosetLane = new BalloonTravelToClosestLane(balloon);
        balloonStates = new StateStack();

        this.balloonStates.Push(normal);
    }
    public void OnClick()
    {
        balloonStates.Push(this.pickedUp);
    }

    public void OnRelease()
    {
        balloonStates.Pop();
        balloonStates.Push(this.travelClosetLane);
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
