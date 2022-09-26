using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public GameManager manager;

    public float speed;
    public float slimeImpact;
    public float maxUpwardSpeed;
    public float maxFallingSpeed;

    Vector2 lastVelocity;

    public Animator anim;

    public CinemachineVirtualCamera cinemachineVirtualCamera;

    // Update is called once per frame
    void Update()
    {
        var curSpeed = lastVelocity.magnitude;
        if (rb.velocity.y < 0f)
        {
            rb.velocity += Vector2.up * -speed;
        }

        if (rb.velocity.y < -maxFallingSpeed && curSpeed > maxFallingSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxFallingSpeed);
        }
        if (rb.velocity.y > maxUpwardSpeed && curSpeed > maxUpwardSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxUpwardSpeed);
        }
        lastVelocity = rb.velocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Shake());
        if (collision.collider.tag == "Ground")
        {
            anim.SetBool("isFalling", false);
        }
    }

    IEnumerator Shake() 
    {
        CinemachineBasicMultiChannelPerlin perlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = 0.45f;
        yield return new WaitForSeconds(.075f);
        perlin.m_AmplitudeGain = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Slime")
        {
            var curSpeed = lastVelocity.magnitude;
            var direction = lastVelocity.normalized;
            rb.velocity = direction * Mathf.Max(curSpeed / slimeImpact, 0f);
        }
    }
}
