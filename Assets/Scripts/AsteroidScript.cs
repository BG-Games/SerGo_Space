using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    Rigidbody asteroid;
    public float rotationSpeed = 50f;
    public float speed = 20f;
    float mult;
    public float hp = 150;
    float a = 3f;
    float score = 0;
    // Start is called before the first frame update
    void Start()
    {

        mult = Random.Range(0.5f, 2);
        hp = hp / mult;
        score = a/ mult;
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        asteroid.velocity = new Vector3(0, 0, -speed * mult);
        asteroid.transform.localScale /= mult;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Grinder")
            return;
       
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);
            ControllerScript.isStarted = false;
            PlayerScript.alive = false;
        }
        if (other.tag == "Enemy")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        ///
        if (other.tag == "Lazer")
        {
            Destroy(other.gameObject);
            hp -= LazerScript.damage;
            if (hp <= 0)
            {
                Destroy(gameObject);
                ControllerScript.score += (int)(mult * a);
            }
        }
        if (other.tag == "SmallLazer")
        {
            Destroy(other.gameObject);
            hp -= SmalLazerScript.damage;
            if (hp <= 0)
            {
                Destroy(gameObject);
                ControllerScript.score += (int)(mult * a);
            }
        }
        if (hp <= 0)
        {
            GameObject newExplosion = Instantiate(asteroidExplosion, asteroid.transform.position, Quaternion.identity);
            newExplosion.transform.localScale /= mult;
        }
        ///



    }
}
