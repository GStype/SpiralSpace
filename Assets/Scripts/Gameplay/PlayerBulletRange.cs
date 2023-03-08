using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletRange : MonoBehaviour
{
    //Limit how far the player can shoot
    public float timer = 3f;


    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x >= 8.9f)
        {
           gameObject.layer = 11; //"Out of bounds" layer
        }
    }
}
