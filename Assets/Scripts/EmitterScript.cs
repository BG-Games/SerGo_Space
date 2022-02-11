using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    GameObject[] asteroidPack;
    public GameObject Enemy;
    public float minEnemyDelay = 0.8f, maxEnemyDelay = 1.5f;
    public float minDelay = 0.8f, maxDelay = 1f;

    float nextLaunchTime = 0;
    float nextEnemyLaunchTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        asteroidPack = new GameObject[] { asteroid1, asteroid2, asteroid3 };
    }

    // Update is called once per frame
    void Update()
    {
        if(!ControllerScript.isStarted)
            return;
        if(Time.time> nextLaunchTime)
        {
            Vector3 asteroidPosition = new Vector3(Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2), 0, transform.position.z);
            Instantiate(asteroidPack[Random.Range(0,3)], asteroidPosition, Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
        if (Time.time > nextEnemyLaunchTime)
        {
            Vector3 EnemyPosition = new Vector3(Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2), 0, transform.position.z);
            Instantiate(Enemy, EnemyPosition, Quaternion.identity);
            nextEnemyLaunchTime = Time.time + Random.Range(minEnemyDelay, maxEnemyDelay);
        }
    }
}
