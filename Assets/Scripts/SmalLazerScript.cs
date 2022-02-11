using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmalLazerScript : MonoBehaviour
{
    Rigidbody lazer;
    public float speed;
    public static float damage = 25;
    // Start is called before the first frame update
    void Start()
    {
        lazer = GetComponent<Rigidbody>();
        lazer.position = new Vector3(lazer.position.x, 0, lazer.position.z);
        lazer.velocity = new Vector3(transform.forward.x,0, transform.forward.z)*speed;
        //if (lazer.rotation.y > 0)
        //    lazer.velocity = new Vector3(speed, 0, speed);
        //if (lazer.rotation.y < 0)
        //    lazer.velocity = new Vector3(-speed, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
