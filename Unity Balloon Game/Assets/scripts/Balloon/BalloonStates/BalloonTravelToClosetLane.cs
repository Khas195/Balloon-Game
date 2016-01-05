using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Core.StateStack;
public class BalloonTravelToClosestLane : BalloonState
{
    Balloon balloon;
    IBalloonController balloonController;
    Vector3 myLane;
    public Vector3 MyLane { get { return myLane; } }
    public BalloonTravelToClosestLane(Balloon balloon)
    {
        this.balloon = balloon;
    }
    public void Update()
    {
        try
        {
            balloon.transform.position = Vector3.MoveTowards(balloon.transform.position, myLane, balloon.Speed * Time.deltaTime);
            if (Vector3.Equals(balloon.transform.position, myLane))
            {
                balloon.GetBalloonController().GetStateStack().Pop();
            }
        }
        catch (NullReferenceException)
        {
            Debug.Log("Null Excecption at : " + this);
        }
    }
    void FindLane()
    {
        GameObject[] allLanes = GameObject.FindGameObjectsWithTag("Pipe");
        float currentDistance = int.MaxValue;
        foreach (GameObject lane in allLanes)
        {
            float distance = Vector3.Distance(lane.transform.position, this.balloon.transform.position);
            if (distance <= currentDistance)
            {
                myLane = lane.transform.position;
                currentDistance = distance;
            }
        }
        myLane = new Vector3(myLane.x, this.balloon.transform.position.y, this.balloon.transform.position.z);

    }
    public void OnPushed()
    {
        FindLane();
    }
    public void OnPoped()
    {
    }

    public void OnReturnToTop()
    {
        FindLane();
    }

    public void OnPressed()
    {
    }
    public void SetBalloon(Balloon balloon)
    {
        this.balloon = balloon;
    }
}

