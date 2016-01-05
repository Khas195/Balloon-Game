using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Core.StateStack;
public class BalloonPickedUp : BalloonState
{
     Balloon balloon;
     public BalloonPickedUp(Balloon balloon)
    {
        this.balloon = balloon;
    }
    public void Update()
    {

        // Get movement of the finger since last frame
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        this.balloon.transform.position = mousePosition;

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    // Get movement of the finger since last frame
        //    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            
        //    // Move object across XY plane
        //    transform.Translate(-touchDeltaPosition.x * followSpeed, -touchDeltaPosition.y * followSpeed, 0);
        //}
    }
   
    public void OnPushed()
    {
        balloon.GetAnimator().SetTrigger("pick");
    }
    public void OnPoped()
    {
        balloon.GetAnimator().SetTrigger("pick");
    }

    public void OnReturnToTop()
    {
        balloon.GetAnimator().SetTrigger("pick");
    }

    public void OnPressed()
    {
        balloon.GetAnimator().SetTrigger("pick");
    }





    public void SetBalloon(Balloon balloon)
    {
        this.balloon = balloon;
    }
}

