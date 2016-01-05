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
        switch (type)
        {
            case Balloon.Type.BLACK:
                product = ManufactureBasicElements(blackBaloon);
                product.GetComponent<Balloon>().SetBalloonController(new BlackBalloonController());
                break;
            case Balloon.Type.BLUE:
                product = ManufactureBasicElements(blueBaloon);
                product.GetComponent<Balloon>().SetBalloonController(new DefaultController());
                break;
            case Balloon.Type.GREEN:
                product = ManufactureBasicElements(greenBaloon);
                product.GetComponent<Balloon>().SetBalloonController(new DefaultController());
                break;
            case Balloon.Type.PINK:
                product = ManufactureBasicElements(pinkBaloon);
                product.GetComponent<Balloon>().SetBalloonController(new DefaultController());
                break;
            case Balloon.Type.YELLOW:
                product = ManufactureBasicElements(yellowBalloon);
                product.GetComponent<Balloon>().SetBalloonController(new DefaultController());
                break;
            default:
                product = ManufactureBasicElements(yellowBalloon);
                product.GetComponent<Balloon>().SetBalloonController(new DefaultController());
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
