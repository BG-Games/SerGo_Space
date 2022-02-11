using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject PlayerShip;
    public GameObject lazer;
    public GameObject Gun;
    public GameObject playerExplosion;
    float nextShotTime = 0;
    public float shotDilay = 0.1f;
    Rigidbody Enemy;
    public float speed = 25f;
    public float hp = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerShip = PlayerScript.pl;
        Enemy = GetComponent<Rigidbody>();
        //Enemy.velocity = new Vector3(0, 0, -speed);
        Enemy.velocity = new Vector3(transform.forward.x, 0, transform.forward.z)* speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerScript.alive)
            return;
        if (PlayerShip.transform.position.z < transform.position.z)
            Enemy.velocity = new Vector3(transform.forward.x, 0, transform.forward.z) * speed;
        else
            Enemy.velocity = new Vector3(transform.forward.x, 0, 0) * speed;
        /////////////
        var test = PlayerShip.transform.position - Enemy.transform.position;

        //var gipotenuza = Mathf.Sqrt( Mathf.Pow(PlayerShip.transform.position.x - Enemy.transform.position.x, 2) + Mathf.Pow(PlayerShip.transform.position.z - Enemy.transform.position.z, 2));
        //var zyach = Mathf.Asin(Mathf.Abs((PlayerShip.transform.position.x - Enemy.transform.position.x)  / gipotenuza));

        //Enemy.rotation = Quaternion.Euler(new Vector3(0, Mathf.Rad2Deg * zyach, 0));
        //Enemy.rotation = Quaternion.Euler(new Vector3(0,test.x - test.z, 0));
        Enemy.transform.LookAt(PlayerShip.transform);
        //    Enemy.rotation = Quaternion.Euler(new Vector3(0, Mathf.Rad2Deg *
        //Mathf.Atan((Mathf.Abs(PlayerShip.transform.position.x - Enemy.transform.position.x)) / (Mathf.Abs(PlayerShip.transform.position.z - Enemy.transform.position.z)))
        //, 0));

       // Debug.Log("x = "+ (PlayerShip.transform.position.x - Enemy.transform.position.x) + "   y ="+ (PlayerShip.transform.position.z - Enemy.transform.position.z));
        ////////////////
        if (Time.time > nextShotTime)
        {
            Instantiate(lazer, Gun.transform.position, Gun.transform.rotation);
            nextShotTime = Time.time + shotDilay;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lazer")
        {
            Destroy(other.gameObject);
            hp -= LazerScript.damage;
            if (hp <= 0)
            {
                Instantiate(playerExplosion, Enemy.transform.position, Quaternion.identity);
                Destroy(gameObject);
                ControllerScript.score += 100;
            }
        }
        if (other.tag == "SmallLazer")
        {
            Destroy(other.gameObject);
            hp -= SmalLazerScript.damage;
            if (hp <= 0)
            {
                Instantiate(playerExplosion, Enemy.transform.position, Quaternion.identity);
                Destroy(gameObject);
                ControllerScript.score += 10;
            }
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            Instantiate(playerExplosion, Enemy.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);
            ControllerScript.isStarted = false;
            PlayerScript.alive = false;
        }
        }
}
