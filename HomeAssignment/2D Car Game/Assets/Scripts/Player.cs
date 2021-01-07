﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;

    float xMin, xMax;
    
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    private void Move()
    {
        //var is used as a generic variable. VS allows us to use var and it will set its type depending on the value it will have
        // deltaX will be updated with the input that will happen on the x-axis, left and right
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        //the x-position will be updated according to the newXPos - whether left or right. Y position will be the same
        transform.position = new Vector2(newXPos, transform.position.y);

        
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
