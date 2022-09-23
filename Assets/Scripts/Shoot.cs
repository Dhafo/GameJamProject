using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Shoot : MonoBehaviour
{
    public GameManager manager;
    [SerializeField]
    private float wallForce;
    [SerializeField]
    private float airForce;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform shootTransform;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform origin;

    public Player player;

    public Animator frog;


    public float rateOfFire;
    public bool inWall;
    public bool inWin = false;
    private bool canShoot = true;

    public AudioSource source;

    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public float intensity;

    // Update is called once per frame
    void Update()
    {
        if (manager.hasStarted)
        {
            Vector3 gunpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (gunpos.x < transform.position.x)
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            }

            if (Input.GetMouseButtonDown(0) && inWin && canShoot)
            {
                WinGame();
            }
            else if (Input.GetMouseButtonDown(0) && inWall && canShoot)
            {
                StartCoroutine(WallFire(wallForce));
            }
            else if (Input.GetMouseButtonDown(0) && !inWall && canShoot)
            {
                StartCoroutine(WallFire(airForce));
            }
        }
           
    }

    IEnumerator WallFire(float forceAmount)
    {
        source.Play();
        player.anim.SetBool("isFalling", true);
        player.anim.SetBool("shoot", true);
        frog.SetBool("shoot", true);
        canShoot = false;
        CinemachineBasicMultiChannelPerlin perlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = intensity;
        yield return new WaitForSeconds(.2f);
        GameObject explosion = Instantiate(bullet, origin.transform.position, origin.transform.rotation);
        rb.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * -forceAmount, ForceMode2D.Impulse);
        Destroy(explosion, .5f);
        perlin.m_AmplitudeGain = 0;
        yield return new WaitForSeconds(rateOfFire);
        canShoot = true;
        frog.SetBool("shoot", false);
        player.anim.SetBool("shoot", false);
    }

    private void WinGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
