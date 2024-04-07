using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D cloudBody;
    private SpriteRenderer cloudSR;
    // Start is called before the first frame update
    void Awake()
    {
        cloudBody = GetComponent<Rigidbody2D>();
        cloudSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int randomFlip = Random.Range(0, 1);
        //velocity forces to move left to right or up to down
        cloudBody.velocity = new Vector2(speed, cloudBody.velocity.y);
        cloudSR.flipX = (randomFlip == 0) ? true : false;
    }

}
