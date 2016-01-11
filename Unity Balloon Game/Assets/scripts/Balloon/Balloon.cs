using UnityEngine;
using System.Collections;
public class Balloon : MonoBehaviour {

    public enum Type { BLUE, YELLOW, PINK, GREEN, BLACK };
    [SerializeField]
    AudioClip pickUp;
    public AudioClip PickUp { get { return pickUp; } }
    [SerializeField]
    AudioClip putDown;
    public AudioClip PutDown { get { return putDown; } }
    [SerializeField]
    AudioClip pop;
    public AudioClip Pop { get { return pop; } }


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
        AudioSource.PlayClipAtPoint(pop, this.transform.position);
        
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        BalloonPoolManager.Instance.RequestPoolWithBalloonType(this.balloonType).ReturnBalloonOfType(this.gameObject);
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        this.transform.localScale = Vector3.one;
    }
    void OnCollider2D()
    {

    }

}
