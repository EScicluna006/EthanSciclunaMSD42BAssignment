using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]float ObstacleHealth = 100f;
    [SerializeField] AudioClip obstacleExplosion;
    [SerializeField] [Range(0, 1)] float obstacleExplosionVolume = 0.7f;

    [SerializeField] GameObject DeathVFX;
    [SerializeField] float explosionDuration = 1f;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        if (!dmgDealer)
        {
            return;
        }

        RegisterHit(dmgDealer);
    }

    private void RegisterHit(DamageDealer dmgDealer)
    {
        ObstacleHealth -= dmgDealer.GetDamage();

        if (ObstacleHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(DeathVFX, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(obstacleExplosion, Camera.main.transform.position, obstacleExplosionVolume);
        Destroy(explosion, explosionDuration);
    }

    void Update()
    {
        
    }
}
