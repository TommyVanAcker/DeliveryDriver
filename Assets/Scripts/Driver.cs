using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float steerSpeed = 2000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Drive();
    }

   void Drive()
    {
        float moveAmount =  Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount,0);
        transform.Rotate(0,0,-steerAmount);
    }
}
