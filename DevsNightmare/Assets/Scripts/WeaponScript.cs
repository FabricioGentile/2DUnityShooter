using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private AudioClip shootClip;
    [SerializeField] [Range(0f, 1.0f)] private float shootVolume = 0.5f;

    public Transform shotPrefab;
    public float shootingRate = 0.25f;
    private float shootCoolDown;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        shootCoolDown = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //decreasing the time between a shoot and another
        if (shootCoolDown > 0)
        {
            shootCoolDown -= Time.deltaTime;
        }
    }

    public void Attack()
    { 
        if (shootCoolDown <= 0)
        {
            audioSource.PlayOneShot(shootClip, shootVolume);
            //set a rate for the shoot of the enemy / player
            shootCoolDown = shootingRate;
            var shotTransform = Instantiate(shotPrefab) as Transform;

            //check who is shooting and set the position of the bullet
            if(gameObject.tag == "Boss1")
            {
                shotTransform.position = new Vector3(transform.position.x - 0.10f, transform.position.y + .25f, transform.position.z);
            }
            else if (gameObject.tag == "Boss2")
            {
                shotTransform.position = new Vector3(transform.position.x - 0.70f, transform.position.y, transform.position.z);
            }
            else
            {
                shotTransform.position = transform.position;
            }
        }
    }
}
