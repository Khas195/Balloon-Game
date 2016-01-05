using UnityEngine;
using System.Collections;
public class Balloon : MonoBehaviour {

    public enum Type { BLUE, YELLOW, PINK, GREEN, BLACK };

     Type balloonType;
    public  Type BalloonType 
    {
        get
        {
            return balloonType;
        }
        set
        {
            balloonType = value;
        }
    }

    float floatingSpeed = 3;
    public float Speed { get { return floatingSpeed; } set { floatingSpeed = value; } }



    IBalloonController balloonController;
    // cache
    Animator anim;

    
	// Use this for initialization
	void Start () {
        this.anim = this.GetComponent<Animator>();
	}
    public Animator GetAnimator()
    {
        return anim;
    }

    public void SetBalloonController(IBalloonController newController){
        newController.Init(this);
        balloonController = newController;
    }
    public IBalloonController GetBalloonController()
    {
        return this.balloonController;
    }

	// Update is called once per frame
	void Update () {
        if (balloonController != null )
        {
            balloonController.Update();
        }
	}
    public void OnClick()
    {
        if (balloonController != null)
            balloonController.OnClick();
    }
    public void OnRelease()
    {
        if (balloonController != null)
        {
            balloonController.OnRelease();
        }
    }

    public IEnumerator Explode()
    {
        anim.SetTrigger("explode");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        this.gameObject.SetActive(false);
    }
    void OnCollider2D()
    {

    }

}
