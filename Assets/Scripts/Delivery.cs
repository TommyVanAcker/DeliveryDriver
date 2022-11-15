using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    int pts;
    bool hasPackage = false;
    
    [Header("Car Status: ")]
    [Tooltip("Color when car has no package")][SerializeField] Color32 colorEmpty;
    [Tooltip("Color when car has a package")][SerializeField] Color32 colorFull;
    [Header("Reward system: ")]
    [SerializeField] [Range(0,100)] int ptsPackageDelivered = 10;
    [Tooltip("crashed with package")][Range(1,50)][SerializeField] int penaltyPtsPackageLost = 5;
    [Tooltip("crashed without package")][Range(1,30)][SerializeField] int penaltyPtsCrashed = 3;
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
