using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletScript : MonoBehaviour
{

    public int damage = 1;
    [SerializeField]
    private string objectTag;
    [SerializeField]
    private string objectTag2;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == objectTag || collider.gameObject.tag == objectTag2)
        {
            HealthScript health = collider.gameObject.GetComponent<HealthScript>();

            if (health != null)
            {
                health.Damage(damage);
            }
            Destroy(gameObject);
        }
        
    }
}
