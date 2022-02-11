using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public GameObject lazer;
    public GameObject smallLazer;
    public GameObject LazerGunMiddle;
    public GameObject LeftGun;
    public GameObject RightGun;
    public GameObject playerExplosion;
    public float shotDilay = 0.33f;
    float smalShotDilay;
    float nextShotTime = 0;
    float nextSmalShotTime = 0;
    Rigidbody player;
    public float speed;
    public float tilt;
    public static GameObject pl;
    public static bool alive;
    Vector3 startPos;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        smalShotDilay = shotDilay / 2;

        pl = gameObject;
        player = GetComponent<Rigidbody>();
        //Player.velocity = new Vector3(20, 0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ControllerScript.isStarted)
            return;

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //if (Input.GetMouseButtonDown(0))
        //    startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //else if (Input.GetMouseButton(0))
        //{
        //    float posX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
        //    float posZ = Camera.main.ScreenToWorldPoint(Input.mousePosition).z - startPos.z;
        //    player.velocity = new Vector3(posX, 0, posZ) * speed;
        //    player.position = Vector3.MoveTowards(player.position, new Vector3(player.position.x+posX, 0, player.position.z+posZ), speed * Time.deltaTime);
        //    player.position = Vector3.SmoothDamp(player.position, new Vector3(player.position.x + posX, 0, player.position.z + posZ), ref velocity, speed * Time.deltaTime);
        //}
        //else
        //    player.velocity = new Vector3(0, 0, 0) * speed;
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //player.velocity = new Vector3(mousePos.x, 0, mousePos.z) * speed;
        //player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);




        float positionX = Mathf.Clamp(mousePos.x, -45.7f, 45.3f);
        float positionZ = Mathf.Clamp(mousePos.z+7, -81, 78);
        player.position = Vector3.MoveTowards(player.position, new Vector3(positionX, 0, positionZ), speed * Time.deltaTime);
        //player.position = new Vector3(positionX, 0, positionZ);

        player.rotation = Quaternion.Euler(player.position.z * 0.5f, 0, -player.position.x * tilt);
        if (Time.time > nextShotTime && Input.GetMouseButton(0))
        {
            Instantiate(lazer, LazerGunMiddle.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDilay;
        }
        if (Time.time > nextSmalShotTime && Input.GetMouseButton(0))
        {
            Instantiate(smallLazer, LeftGun.transform.position, LeftGun.transform.rotation);
            Instantiate(smallLazer, RightGun.transform.position, RightGun.transform.rotation);
            nextSmalShotTime = Time.time + smalShotDilay;
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyLazer")
        {
            alive = false;
            Instantiate(playerExplosion, player.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);
            ControllerScript.isStarted = false;

        }
    }

}
