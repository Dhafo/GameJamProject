using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = player.position - transform.position;
        transform.up = -dir;
    }
}
