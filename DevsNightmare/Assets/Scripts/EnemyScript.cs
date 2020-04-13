using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private WeaponScript weapon;

    private float explosionDuration = 1.0f;
 

    // Start is called before the first frame update
    void Start()
    {

        weapon = GetComponent<WeaponScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon != null)
        {
            weapon.Attack();
        }

    }




}


    