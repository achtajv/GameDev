using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX, maxY, minY; //for setting the minimum and maximum positoin of the camera within the map
    // Start is called before the first frame update
    void Start()
    {
        //find objects that are tagged as Player
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate() //being called after all calculation in the Update() function in the player class
    {
        if (!player) { return; } //if no player is detected return and skip all lines

        //temporary position location
        tempPos = transform.position;
        tempPos.x = player.position.x; //player location position
        tempPos.y = player.position.y;

        //in order to stop the camera, use these if conditions
        if(tempPos.x < minX) { tempPos.x = minX; }
        if(tempPos.y < minY) { tempPos.y = minY; }
        if(tempPos.x > maxX) { tempPos.x = maxX; }
        if(tempPos.y > maxY) { tempPos.y = maxY; }

        transform.position = tempPos; //transfer it to the position of the camera so it moves
    }
}
