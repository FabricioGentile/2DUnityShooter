using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    public Transform shotPrefab;
    public float shootingRate = 0.25f;
    private float shootCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        shootCoolDown = 0;
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
            shootCoolDown = shootingRate;
            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;
        }
    }
}
