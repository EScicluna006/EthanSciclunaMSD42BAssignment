using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int playerHealth = 50;

    [SerializeField] AudioClip impactSound;
    [SerializeField] [Range(0,1)]float ImpactSoundVolume = 0.75f;

    float xMin, xMax;
    
    void Start()
    {
        SetUpMoveBoundaries();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector2(newXPos, transform.position.y);

        
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        playerHealth -= damageDealer.GetDamage();
        AudioSource.PlayClipAtPoint(impactSound, Camera.main.transform.position, ImpactSoundVolume);
        FindObjectOfType<GameSession>().Health(playerHealth);

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<Level>().LoadGameOver();
        }
    }

    void Update()
    {
        Move();
    }
}
