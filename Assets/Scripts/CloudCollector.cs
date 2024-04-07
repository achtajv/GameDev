using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cloud") ) //destroy the enemy that collides with the collector
        {
            Destroy(collision.gameObject);
        }
    }
}
