using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject tool; // tool objesini tutar.
    [SerializeField] float fear; // kameranin toola olan uzakligini saklar.

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    // kameranin toolu takip etmesini saglar.
    void FollowPlayer()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, tool.transform.position.z - fear);
    }
}
