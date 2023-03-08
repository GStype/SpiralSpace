using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    
    public Vector3 bulletOffset = new Vector3(0.9f, 0, 0); //set the point from which the enemy's bullets are launched.
    public GameObject bulletPrefab;
    int bulletLayer;

    public float shootingDelay = 0.5f;
    float shootingLimiter = 0;

     Transform player;
    
    void Start()
    {
        bulletLayer = gameObject.layer;        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player == null)
        { //Locate player ship
            GameObject gObj = GameObject.Find("PlayerGO"); //Identifies player by the object's name.

            if (gObj != null)
            {
                player = gObj.transform;
            }
        }
        shootingLimiter -= Time.deltaTime;
        
        if(shootingLimiter <= 0 && player != null && transform.position.x <= 9.4f)
        {
            //Debug.Log("Enemy shooting...");
            shootingLimiter = shootingDelay;

            Vector3 offset = bulletOffset; //set the point from which the enemy's bullets are launched.

            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation); //adding offset so bullet launches from the tip of the ship
            bulletGO.layer = bulletLayer;;
        }
    }
}
