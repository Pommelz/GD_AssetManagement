using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// wird automatisch auf den Player bezogen beim raufziehen des Scriptes

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Rigidbody))]


public class PlayerBehaviour : MonoBehaviour
{

    private Scene scene;

    Vector3 screenPoint;
    Vector3 offset;

    // Player Movement
    [Header("Player Movement")]
    float speed = 27.2f;  // 23.0f ---> 27.2.0f
    public float gravity = 0;
    // Vector3 velocity;
    public int invert = 1; // Negative 1 for invert, positive 1 for not

    //Bullet
    [Header("Player Bullets")]
    public Transform[] bulletSpawns;
    double nextFireBullet;
    int bulletLevel = 1; // Anzahl der Schüsse, später noch anpassbar
    int bulletDamage = 1; // Später noch anpassbar
    double fireRate = 0.490; // Später noch anpassbar 0.5 ---> 0.490
    public GameObject bullet;

    [Header("Player")]
    // Leben vom Spieler
    public static int health = 3; //static muss sein sonst reset nach jeder stage
    public static int Life = 3;

    public Material[] Materials;
    public static int currentMaterials;
    // Material End;

    public GameObject Rauchbei1Schaden;
    public GameObject Rauchbei2Schaden;

    //    public Texture[] textures; // Array was die Textures beinhaltet
    //    public int currentTexture; // Über den Wert wird bestimmt welche Texture angezeigt wird

    // Effect wenn Spieler zerstört wird
    public GameObject Explosion;
    public AudioClip HitSound;
    public AudioClip Alarm;
    public AudioClip Respawn;
    public AudioClip Damm;
    public AudioClip LevelUp;
    public AudioClip Holy;
    public AudioClip Chichi;
    //public AudioClip Mother;
    public float countdown = 1f;
    public GameObject Mother;
    AudioSource attachedAudioSource;

    //Resete Spieler
    Vector3 initPosition;
    bool isDead;


    // Update is called once per frame
    void Update()
    {

            //New Movement 30.11.2020
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, invert * vertical, 0);
            Vector3 finaldirection = new Vector3(horizontal, invert * vertical, 100f);
            // Vector3 finaldirection = new Vector3(horizontal, invert * vertical, 6.0f); //alte Version


            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finaldirection), Mathf.Deg2Rad * 0.5f);

            if (transform.position.x > 150)
                transform.position = new Vector3(150, transform.position.y, transform.position.z);
            if (transform.position.x < -150)
                transform.position = new Vector3(-150, transform.position.y, transform.position.z);

            if (transform.position.y > 40)
                transform.position = new Vector3(transform.position.x, 40, transform.position.z);
            if (transform.position.y < -20)
                transform.position = new Vector3(transform.position.x, -20, transform.position.z);




      
    }


}
