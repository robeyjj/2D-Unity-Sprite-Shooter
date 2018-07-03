using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class DestroyColliders : MonoBehaviour
{
    public AudioClip hitSound;
    public AudioSource source;
    private float volumeLevel = 1.0f;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If an arrow shoots an enemy
        if (gameObject.tag == "arrowTag" && collision.collider.gameObject.tag == "arrowTarget")
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
        //If the Player runs into an enemy
        else if (gameObject.tag == "Player" && collision.collider.gameObject.tag == "arrowTarget")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //If the Player runs into a snowball
        else if (gameObject.tag == "Player" && collision.collider.gameObject.tag == "snowballTag")
        {
            source.PlayOneShot(hitSound, volumeLevel);
           //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (gameObject.tag == "snowballTag" && collision.collider.gameObject.tag == "snowFloor")
        {
            Destroy(gameObject);
        }
        else if ((gameObject.tag == "BarrelTag" && collision.gameObject.tag == "DangerousTile") || gameObject.tag == "DangerousTile" && collision.gameObject.tag == "BarrelTag")
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
    }
}