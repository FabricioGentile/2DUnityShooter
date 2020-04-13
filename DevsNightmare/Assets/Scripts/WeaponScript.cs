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
            shootCoolDown = shootingRate;
            var shotTransform = Instantiate(shotPrefab) as Transform;
            if(gameObject.tag == "Boss1")
            {
                shotTransform.position = new Vector3(transform.position.x - 10, transform.position.y + 25, transform.position.z);
            }
            else
            {
                shotTransform.position = transform.position;
            }
            

        }
    }
}
