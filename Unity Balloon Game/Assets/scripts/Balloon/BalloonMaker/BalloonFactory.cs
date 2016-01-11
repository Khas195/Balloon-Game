using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class BalloonFactory : MonoBehaviour
{
    [SerializeField]
    Sprite blackBaloon;
    [SerializeField]
    Sprite yellowBalloon;
    [SerializeField]
    Sprite blueBaloon;
    [SerializeField]
    Sprite pinkBaloon;
    [SerializeField]
    Sprite greenBaloon;

    [SerializeField]
    GameObject basicPrototype;
    public GameObject CreateBalloon(Balloon.Type type)
    {
        GameObject product = null;
        Balloon balloon;
        switch (type)
        {
            case Balloon.Type.BLACK:
                product = ManufactureBasicElements(blackBaloon);
                balloon = product.GetComponent<Balloon>();
                balloon.BalloonType = Balloon.Type.BLACK;
                balloon.SetBalloonController(new BlackBalloonController());
                break;
            case Balloon.Type.BLUE:
                product = ManufactureBasicElements(blueBaloon);
                balloon = product.GetComponent<Balloon>();
                balloon.BalloonType = Balloon.Type.BLUE;
                balloon.SetBalloonController(new DefaultController());
                break;
            case Balloon.Type.GREEN:
                product = ManufactureBasicElements(greenBaloon);
                balloon = product.GetComponent<Balloon>();
                balloon.BalloonType = Balloon.Type.GREEN;
                balloon.SetBalloonController(new DefaultController());
                break;
            case Balloon.Type.PINK:
                product = ManufactureBasicElements(pinkBaloon);
                balloon = product.GetComponent<Balloon>();
                balloon.BalloonType = Balloon.Type.PINK;
                balloon.SetBalloonController(new DefaultController());
                break;
            case Balloon.Type.YELLOW:
                product = ManufactureBasicElements(yellowBalloon);
                balloon = product.GetComponent<Balloon>();
                balloon.BalloonType = Balloon.Type.YELLOW;
                balloon.SetBalloonController(new DefaultController());
                break;
            default:
                product = ManufactureBasicElements(yellowBalloon);
                balloon = product.GetComponent<Balloon>();
                balloon.BalloonType = Balloon.Type.YELLOW;
                balloon.SetBalloonController(new DefaultController());
                break;
        }
        return product;
    }

    private GameObject ManufactureBasicElements(Sprite sprite)
    {
        GameObject product;
        product = Instantiate(basicPrototype);
        product.GetComponent<SpriteRenderer>().sprite = sprite;

        return product;
    }
}
