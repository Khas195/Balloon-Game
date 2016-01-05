using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Core.StateStack;
public class BalloonNormal : BalloonState
{
    Balloon balloon;
    public BalloonNormal(Balloon balloon)
    {
        this.balloon = balloon;
    }
    public void Update()
    {
        if (balloon != null)
        {
            balloon.transform.position += new Vector3(0, balloon.Speed * Time.deltaTime, 0);
        }
    }

    public void OnPushed()
    {
    }
    public void OnPoped()
    {
    }

    public void OnReturnToTop()
    {
    }

    public void OnPressed()
    {
    }
    public void SetBalloon(Balloon balloon)
    {
        this.balloon = balloon;
    }


}

