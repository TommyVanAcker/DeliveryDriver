using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [Header("Car Speed: ")]
    [Range(1f,15f)][SerializeField] float slowSpeed = 5f;
    [Range(1f, 20f)][SerializeField] float normalSpeed = 10f;
    [Range(1f, 30f)][SerializeField] float boostSpeed = 20f;
    [Range(100f, 1500f)][SerializeField] float steerSpeed = 1500f;
    float timeleft;
    float moveSpeed;
    bool hasDifferentSpeed = false;

    // Start is called before the first frame update
    void Start()
    {
        timeleft = 5f;
        moveSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Drive();
        if (hasDifferentSpeed)
        {
            timeleft -= Time.deltaTime;
            if (timeleft < 0f)
            {
                moveSpeed = normalSpeed;
                timeleft = 5f;
                hasDifferentSpeed = false;
            }
        }
        
    }

   void Drive()
    {
        float moveAmount =  Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount,0);
        transform.Rotate(0,0,-steerAmount);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Boost")
        {
            Debug.Log("speed up the car");
            moveSpeed = boostSpeed;
            hasDifferentSpeed= true;

        }
        else if (collision.tag == "Bump")
        {
            Debug.Log("slow down the car");
            moveSpeed = slowSpeed;
            hasDifferentSpeed= true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
        hasDifferentSpeed= true;
    }


}
