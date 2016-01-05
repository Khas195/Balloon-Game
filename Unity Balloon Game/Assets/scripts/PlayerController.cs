using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Balloon balloon;
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {

                balloon = hit.transform.GetComponent<Balloon>();
                if (balloon != null)
                {
                    balloon.OnClick();
                }
                
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (balloon != null)
            {
                balloon.OnRelease();
                balloon = null;
            }
        }
      
        /*
        if (Input.touchCount >  0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("Touched");
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
                if (hit)
                {
                    balloon = hit.transform.gameObject.GetComponent<BalloonController>();
                    if (balloon != null)
                    {
                        balloon.OnClick();
                    }
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Debug.Log("Release");
                if (balloon != null)
                {
                    balloon.OnRelease();
                    balloon = null;
                }
            }
        }
         */
	}
}
