using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] bool hasPackage = false;
    [SerializeField] Color32 colorEmpty;
    [SerializeField] Color32 colorFull;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            //Debug.Log("picked up package");
            Destroy(collision.gameObject);
            SetStatusCar(true, colorFull);
 
        } else if (collision.tag == "Customer" && hasPackage)
        {
            //Debug.Log("Package delivered");
            SetStatusCar(false, colorEmpty);

        }
    }

    private void SetStatusCar(bool carhasPackage, Color32 colorCar)
    {
        hasPackage = carhasPackage;
        GetComponent<SpriteRenderer>().color = colorCar;
    }
}
