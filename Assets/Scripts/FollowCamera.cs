using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //this things position should be same as player position with offset

    GameObject player;
    float distanceToPlayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distanceToPlayer = transform.position.z - player.transform.position.z;
        
    }

    private void LateUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        transform.position = player.transform.position + new Vector3(0,0,distanceToPlayer);
    }
}
