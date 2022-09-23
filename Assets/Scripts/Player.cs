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

    public Animator anim;

    public CinemachineVirtualCamera cinemachineVirtualCamera;

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
}
