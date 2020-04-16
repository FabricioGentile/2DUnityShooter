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
        switch (gameObject.tag)
        {
            //creates the health bar just for the player
            case "Player":
                healthBar.SetMaxHealth(hp);
                break;
        }
    }

    public void Damage(int damageCount)
    {
        //take the damage from HP
        hp -= damageCount;
        //updates the health bar
        if(gameObject.tag == "Player")
        {
            healthBar.SetHealth(hp);
        }
       
        //if the enemy is killed, give the player the following scoring values
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
            //destroy the enemy
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
