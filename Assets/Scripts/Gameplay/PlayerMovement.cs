using System.Runtime.CompilerServices;
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    float defaultSpeed = 3f;
    float defaultHorizontalSpeed = 4f;
    float playerHeightBoundary = 0.4f;
    float playerWidthBoundary = 0.6f;
    

    void Update()
    {
        //Player Movement
        Vector3 playerPos = transform.position;
        
        
        playerPos.x += Input.GetAxis("Horizontal") * defaultHorizontalSpeed * Time.deltaTime; //slows the increase of x per second the button is pushed down
        transform.position = playerPos;                                                       //in short, the player's default speed


        playerPos.y += Input.GetAxis("Vertical") * defaultSpeed * Time.deltaTime; //slows the increase of x per second the button is pushed down
        transform.position = playerPos;                                           

        //World Boundaries
        
        //prohibit the player from "leaving" the screen vertically
        if (playerPos.y + playerHeightBoundary > Camera.main.orthographicSize) //for +y axis
        {

            playerPos.y = Camera.main.orthographicSize - playerHeightBoundary;
        } 

        if (playerPos.y -playerHeightBoundary < -Camera.main.orthographicSize) //for //-y axis
        {
            playerPos.y = -Camera.main.orthographicSize + playerHeightBoundary; 
        }
        
        //prohibit the player from "leaving" the screen horizontally
        /*  Unlike the vertical orthographic size, the horizontal is not fixed.
            For this reason, it is required to calculate the screen ratio
            in order to know the screen's width */

        float currentScreenRatio = (float)Screen.width / (float)Screen.height;
        float orthographicWidth = Camera.main.orthographicSize * currentScreenRatio; 

        if (playerPos.x + playerWidthBoundary > orthographicWidth) //for +x axis
        {        
            playerPos.x = orthographicWidth - playerWidthBoundary;
        } 

        if (playerPos.x -playerWidthBoundary < -orthographicWidth) //for -x axis
        {        
            playerPos.x = -orthographicWidth + playerWidthBoundary;
        } 

        transform.position = playerPos;

    }
}
