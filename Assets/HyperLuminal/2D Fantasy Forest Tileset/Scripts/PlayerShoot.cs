using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    //bool justLaunched;
    //Rigidbody2D archerArrow;
    //Rigidbody2D archerArrowBody;
    //Object archerArrow;

    //Barrel vars
    public GameObject barrelPrefab;
    public Transform barrelSpawn;
    Vector3 newBarrelTransformPosition = new Vector3(0, 0, 0);
    public Rigidbody2D barrelRigidBody;
    public BoxCollider2D barrelBoxCollider2D;
    private float lastShot = 0.0f;
    private float fireRate = 0.5f;
    public int barrelForce = 1000;
    //bool isShooting = false;
    public AudioClip shootSound;
    public AudioSource source;
    private float volumeLevel = 0.3f;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        barrelSpawn.position += newBarrelTransformPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.LeftControl))
        {
            FireNewArrow();
        }

    }

    void FireNewArrow()
    {
        if (Time.time > fireRate + lastShot)
        {
            //Instantiate a new Clone of a barrel GameObject
            GameObject barrelGameObject = (GameObject)Instantiate(barrelPrefab, barrelSpawn.position, barrelSpawn.rotation);
            barrelRigidBody = barrelGameObject.GetComponent<Rigidbody2D>();
            barrelBoxCollider2D = barrelGameObject.GetComponent<BoxCollider2D>();
            source.PlayOneShot(shootSound, volumeLevel);

            //Set the new barrel's tag so it is recognized as a barrel in game to allow for special conditions such as collision and destruction
            barrelGameObject.tag = "BarrelTag";

            //Get the input directions to fire the direction you're facing
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            //Add velocity to barrel
            if (horizontal > 0)
            {
                barrelRigidBody.AddForce(new Vector2(barrelForce, 0));
                barrelBoxCollider2D.isTrigger = false;
            }
            else if (horizontal < 0)
            {
                barrelRigidBody.AddForce(new Vector2(-barrelForce, 0));
                barrelBoxCollider2D.isTrigger = false;
            }

            if (vertical > 0)
            {
                barrelRigidBody.AddForce(new Vector2(0,barrelForce));
                barrelBoxCollider2D.isTrigger = false;
            }
            if (vertical < 0)
            {
                barrelRigidBody.AddForce(new Vector2(0, -barrelForce));
                barrelBoxCollider2D.isTrigger = false;
            }
            //Reset time since last shot
            lastShot = Time.time;

            //Destroy the barrel so that doesn't fly forever off screen
            Destroy(barrelGameObject, 3.0f);
        }
        else
        {
            return;
        }
    }
    
}