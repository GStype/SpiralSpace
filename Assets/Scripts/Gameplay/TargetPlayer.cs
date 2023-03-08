using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{

    public float rotSpeed = 0f;

    Transform player; //Tracks the Transform of the player



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
        
        if(player == null)
        {
            return; //attempts to find the player on the next frame
        }
        
        //In this point the player ship undoubtedly exists. Thus, the enemy will attempt to face them.

        Vector3 dir = player.position - transform.position; //dir is a distance vector
        dir.Normalize(); //Normalize the vector.

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; 
        
        Quaternion defaultRot = Quaternion.Euler(0, 0, zAngle);

        //rotate from current rotation, to desired rotation, with what speed (degrees per second)
        transform.rotation = Quaternion.RotateTowards(transform.rotation, defaultRot, rotSpeed * Time.deltaTime);
    }
}
