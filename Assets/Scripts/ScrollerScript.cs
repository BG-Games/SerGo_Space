using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerScript : MonoBehaviour
{
    public float speed = 15;
    Vector3 startPos;
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        offset = Mathf.Repeat(Time.time * speed,200);
        transform.position = startPos + new Vector3(0, 0, -offset);
    }
}
