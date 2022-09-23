using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Imp : MonoBehaviour
{

    public Transform pos1, pos2;
    public float platSpeed;
    public bool dir = true;

    public SpriteRenderer sprite;

    public GameManager manager;

    // Update is called once per frame
    void Update()
    {
        if (manager.hasStarted) 
        {
            if (dir)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos2.position, platSpeed * Time.deltaTime);
                if (transform.position == pos2.position)
                {
                    dir = false;
                    sprite.flipX = true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pos1.position, platSpeed * Time.deltaTime);
                if (transform.position == pos1.position)
                {
                    dir = true;
                    sprite.flipX = false;
                }
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
