using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private Renderer ren;
    private WeaponScript weapon;

    // Start is called before the first frame update
    void Start()
    {

        weapon = GetComponent<WeaponScript>();
        ren = GetComponent<Renderer>();
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


    