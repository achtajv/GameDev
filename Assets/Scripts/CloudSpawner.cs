using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;

    [SerializeField]
    private Transform leftPosition, rightPosition;

    private GameObject spawnedCloud;
    private int randomIndex, randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnClouds());
    }

    IEnumerator SpawnClouds()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 10));

            randomIndex = Random.Range(0, clouds.Length);
            randomSide = Random.Range(0, 2);

            spawnedCloud = Instantiate(clouds[randomIndex]);
            int randomFlip = Random.Range(0, 1);
            //left side
            if (randomSide == 0)
            {
                //random height generator
                spawnedCloud.transform.position = new Vector3(leftPosition.transform.position.x, Random.Range(4, 10), 0);
                spawnedCloud.GetComponent<Cloud>().speed = 1;
            }
            else
            {
                spawnedCloud.transform.position = new Vector3(rightPosition.transform.position.x, Random.Range(4, 10), 0);
                spawnedCloud.GetComponent<Cloud>().speed = -1;

            }
        }
    }
}
