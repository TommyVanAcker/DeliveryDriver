using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] bool hasPackage = false;
    [SerializeField] Color32 colorEmpty;
    [SerializeField] Color32 colorFull;
    [SerializeField] int pts;
    [SerializeField] int ptsPackageDelivered = 10;
    [SerializeField] int penaltyPtsPackageLost = 5;
    [SerializeField] int penaltyPtsCrashed = 3;
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
            pts += ptsPackageDelivered;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasPackage)
        {
            SetStatusCar(false, colorEmpty);
            pts -= penaltyPtsPackageLost;
        } else
        {
            pts-= penaltyPtsCrashed;
        }
    }

    private void SetStatusCar(bool carhasPackage, Color32 colorCar)
    {
        hasPackage = carhasPackage;
        GetComponent<SpriteRenderer>().color = colorCar;
    }
}
