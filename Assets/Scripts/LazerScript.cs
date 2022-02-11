using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    Rigidbody lazer;
    public static float damage = 50;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        lazer = GetComponent<Rigidbody>();
        lazer.position = new Vector3(lazer.position.x, 0, lazer.position.z);
        lazer.velocity = new Vector3(transform.forward.x, 0, transform.forward.z) * speed;
        //lazer.velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
