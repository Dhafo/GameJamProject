using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : MonoBehaviour
{
    public Shoot shoot;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered collision with " + other.name);
        if (other.tag == "WallBounce")
        {
            shoot.inWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("exited collision with " + other.name);
        if (other.tag == "WallBounce")
        {
            shoot.inWall = false;
        }
    }
}
