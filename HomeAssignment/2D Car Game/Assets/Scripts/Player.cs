using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Move()
    {
        //var is used as a generic variable. VS allows us to use var and it will set its type depending on the value it will have
        // deltaX will be updated with the input that will happen on the x-axis, left and right
        var deltaX = Input.GetAxis(“Horizontal”);
        var newXPos = transform.position.x + deltaX;

        //the x-position will be updated according to the newXPos - whether left or right. Y position will be the same
        transform.position = new Vector2(newXPos, transform.position.y);
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
