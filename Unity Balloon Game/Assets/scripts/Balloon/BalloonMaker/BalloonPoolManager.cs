using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BalloonPoolManager  {
    List<BalloonPool> balloonPoolList;
    BalloonFactory factory;

    static BalloonPoolManager instance;
    public static BalloonPoolManager Instance { 
        get
        {
            if (instance == null)
            {
                instance = new BalloonPoolManager();
            }
            return instance;
        } 
    }
    BalloonPoolManager()
    {
        balloonPoolList = new List<BalloonPool>();
    }
    public void SetFactory(BalloonFactory factory)
    {
        this.factory = factory;
    }
    public BalloonPool RequestPoolWithBalloonType(Balloon.Type type)
    {
        if (factory == null)
        {
            Debug.Log("Assign factory to balloonPool");
            return null;
        }
        foreach (BalloonPool balloonPool in balloonPoolList)
        {
            if (balloonPool.GetPoolType() == type)
            {
                return balloonPool;
            }
        }
        BalloonPool newPoolType = new BalloonPool(type,factory);
        this.balloonPoolList.Add(newPoolType);
        return newPoolType;
    }

}
