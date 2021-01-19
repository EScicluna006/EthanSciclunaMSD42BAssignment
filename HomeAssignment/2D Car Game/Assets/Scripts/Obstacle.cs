using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]float ObstacleHealth = 100f;
    [SerializeField] AudioClip obstacleExplosion;
    [SerializeField] [Range(0, 1)] float obstacleExplosionVolume = 0.7f;

    //VFX for explosion of player
    [SerializeField] GameObject DeathVFX;
    [SerializeField] float explosionDuration = 1f;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //Gets the damage dealer class from the object
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        //If there is no dmgDealer in obstacle/bullet end method 
        if (!dmgDealer)
        {
            return;
        }

        RegisterHit(dmgDealer);
    }

    private void RegisterHit(DamageDealer dmgDealer)
    {
        //Reduce Health by Damage Given
        ObstacleHealth -= dmgDealer.GetDamage();

        //If Player Health is equal of lower than 0, Player dies
        if (ObstacleHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        //Explosion VFX & Sound
        GameObject explosion = Instantiate(DeathVFX, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(obstacleExplosion, Camera.main.transform.position, obstacleExplosionVolume);

        //Destroy explosion after 1 second
        Destroy(explosion, explosionDuration);
    }

    void Update()
    {
        
    }
}
