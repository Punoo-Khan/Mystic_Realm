using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform tower;
    public float xoffset, yoffset, zoffset;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, tower.position);
        transform.position = player.transform.position + new Vector3(xoffset, yoffset, zoffset);
        transform.LookAt(player.transform.position);

    }
}

