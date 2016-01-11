using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class BalloonPool
{
    private Balloon.Type type;
    BalloonFactory factory;

    Stack<GameObject> availablePool;
    List<GameObject> usedPool;

    public BalloonPool(Balloon.Type type, BalloonFactory factory)
    {
        // TODO: Complete member initialization
        this.type = type;
        availablePool = new Stack<GameObject>();
        usedPool = new List<GameObject>();
        this.factory = factory;
    }
    public Balloon.Type GetPoolType()
    {
        return type;
    }
    public GameObject RequestBalloonOfType(){
        GameObject requestedBalloon = null;
       
        if (availablePool.Count <= 0)
        {
            requestedBalloon = factory.CreateBalloon(type);
        }
        else
        {
            requestedBalloon = availablePool.Pop();
        }
        usedPool.Add(requestedBalloon);
        return requestedBalloon;
    }
    public void ReturnBalloonOfType(GameObject balloonObject)
	{
        
        Balloon balloon = balloonObject.GetComponent<Balloon>();
        if (balloon != null && balloon.BalloonType == type)
        {
            if (usedPool.Contains(balloonObject))
            {
                usedPool.Remove(balloonObject);
            }
            this.availablePool.Push(balloonObject);
			balloonObject.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong balloon Type or No balloon Script were found");
        }
    }
}

