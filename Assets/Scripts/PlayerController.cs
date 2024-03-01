using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform projectileSpawnPosition;
    public GameObject projectilePrefab;
    public Image timerBar;

    private float horizontalInput;
    private float verticalInput;
    private float speed = 18f;

    private float sideBound = 10f;
    private float topBound = 10f;
    private float bottomBound = -2f;

    private float fireRate = 0.4f;
    private float nextFire;

    public AudioClip coinSound;
    private AudioSource playerAudio;

    public bool hasPowerup;
 
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward *  verticalInput * speed * Time.deltaTime);

        CheckConstraints();

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }



    }
    void Shoot()
    {
        Instantiate(projectilePrefab, projectileSpawnPosition.position, projectilePrefab.transform.rotation);
    }
    void CheckConstraints()
    {
        if (transform.position.x > sideBound)
        {
            transform.position = new Vector3(sideBound, 1, transform.position.z);
        }
        if (transform.position.x < -sideBound)
        {
            transform.position = new Vector3(-sideBound, 1, transform.position.z);
        }
        if (transform.position.z > topBound)
        {
            transform.position = new Vector3(transform.position.x, 1, topBound);
        }
        if (transform.position.z < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, 1, bottomBound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            Debug.Log("powerup picked up");
            StartCoroutine(PowerupCountdownRoutine());
            InvokeRepeating("RepeatingFunction", 0, 0.4f);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(3);
        hasPowerup = false;
        Debug.Log("powerup worned off");
    }

    void RepeatingFunction()
    {
        Debug.Log("Repeater running...");
        playerAudio.PlayOneShot(coinSound);
        if (!hasPowerup ) 
        {
            CancelInvoke("RepeatingFunction");
            return;
        }
    }
}
