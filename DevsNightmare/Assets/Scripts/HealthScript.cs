using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private GameObject explosionFX;
    private float explosionDuration = 5.0f;
    private SoundsScript sc;
    public HealthBarScript healthBar;

    public int hp = 1;

    // Start is called before the first frame update
    void Start()
    {
        sc = SoundsScript.FindSoundController();
        if (gameObject.tag == "Player")
        {
            healthBar.SetMaxHealth(hp);
        }
    
    }

    public void Damage(int damageCount)
    {
        hp -= damageCount;
        if(gameObject.tag == "Player")
        {
            healthBar.SetHealth(hp);
        }
       
        if (hp <= 0)
        {
            switch (gameObject.tag)
            {
                case "Enemy1":
                    ScoreScript.scoreValue += 10;
                    break;
                case "Boss1":
                    ScoreScript.scoreValue += 100;
                    break;
                case "Enemy2":
                    ScoreScript.scoreValue += 20;
                    break;
                case "Boss2":
                    ScoreScript.scoreValue += 200;
                    break;
                default:
                    break;
            }
            GameObject explosion = Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(explosion, explosionDuration);
            PlaySound(dieSound);
            Destroy(gameObject);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (sc)
        {
            sc.PlayOneShot(clip);
        }
    }
}
