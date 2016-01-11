using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Balloon") {
			Balloon balloon = other.GetComponent<Balloon> ();
			BalloonPoolManager.Instance.RequestPoolWithBalloonType (balloon.BalloonType).ReturnBalloonOfType (other.gameObject);
		}
    }
}
