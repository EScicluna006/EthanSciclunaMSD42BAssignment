using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBullets : MonoBehaviour
{
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject ObstacleShoot;
    [SerializeField] float ObstacleShootSpeed = 15f;

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            ObstacleFire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }
    private void ObstacleFire()
    {
        GameObject obstacleShoot = Instantiate(ObstacleShoot, transform.position, Quaternion.identity) as GameObject;
        obstacleShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ObstacleShootSpeed);
    }

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
        CountDownAndShoot();

    }
}
