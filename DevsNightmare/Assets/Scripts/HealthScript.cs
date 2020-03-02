using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    [SerializeField] private GameObject explosionFX;
    private float explosionDuration = 5.0f;

    public int hp = 1;
    public void Damage(int damageCount)
    {
        hp -= damageCount;
        if(hp <= 0)
        {
            GameObject explosion = Instantiate(explosionFX,
                                               transform.position,
                                               transform.rotation);
            Destroy(explosion, explosionDuration);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
