using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    
    void Update()
    {

       if (gameObject.transform.position.x <= -10 || gameObject.transform.position.y <= -5.5 || gameObject.transform.position.y >= 5.5)
       {
           Destroy(gameObject);
       }

       
    }
}
