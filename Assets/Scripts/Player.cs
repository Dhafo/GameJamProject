using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public float speed;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y < 0f)
        {
            rb.velocity += Vector2.up   * -speed;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            anim.SetBool("isFalling", false);
        }
    }
}
