using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsDestroyer : MonoBehaviour
{
    [SerializeField] int point = 100;
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.name == "2DBulletfix" || otherObject.name == "2DBulletfix(Clone)" || otherObject.name == "Handcuffs" || otherObject.name == "Handcuffs(Clone)")
        {
            print("Bluuet");
            Destroy(otherObject.gameObject);
        }
        else
        {
            print("Carr");
            Destroy(otherObject.gameObject);
            FindObjectOfType<GameSession>().Score(point);
            Debug.Log(point);
        }
    }
}
