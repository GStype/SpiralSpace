using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0.9f, 0, 0); //set the point from which the player's bullets are launched.
    
    public GameObject bulletPrefab;
    int bulletLayer;

    public float shootingDelay = 0.25f;
    float shootingLimiter = 0;

    //AudioSource shootingSound;

    void Start()
    {
        bulletLayer = gameObject.layer; //assigns the bullet to the layer of the unit that fired it.
        //shootingSound = GetComponent<AudioSource>();
        
    }
    
    void Update()
    {
        
        shootingLimiter -= Time.deltaTime;

        if(Input.GetButton("Fire1") && shootingLimiter <= 0)
        {
             
            //Debug.Log("Player shooting...");
            shootingLimiter = shootingDelay;
            

            Vector3 offset = bulletOffset; //set the point from which the player's bullets are launched.
            //shootingSound.Play();

            //adding offset so bullet launches from the tip of the ship
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            
            
            bulletGO.layer = bulletLayer;
        }
    }
}
