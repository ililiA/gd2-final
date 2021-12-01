using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public enum itemType {Wand};

    public itemType thisItem = itemType.Wand;

    public Rigidbody magicBullet;
    public float bulletSpeed = 50;
    public Transform bulletSpawn;

    [Header("Audio")]
    
    public AudioSource aud;
    public AudioClip magicClip;
    [Range(0f, 1f)]
    public float magicVolume = .5f;

    Rigidbody rb;

    private PlayerHealth hp;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //AudioClip aud = GameObject.FindWithTag("Player");
    }

    public void Fire()
    {
        Rigidbody copy = Instantiate(magicBullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        //copy.transform.Translate(Vector3.forward * 2); // move the bullet in front of the player
        copy.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse); // shoot bullet forward
        copy.GetComponent<BulletController>().owner = hp;
        aud.PlayOneShot(magicClip);
    }

    public void Drop()
    {
        this.transform.SetParent(null);
        // set rigidbody to is Kinematic = false
        rb.isKinematic = false;
        // throw item forward
        // Vector3.forward or Vector3.back depending on orientation
        this.transform.Translate(Vector3.forward *3);
        rb.AddRelativeForce(Vector3.forward * 10, ForceMode.Impulse);
    }
}
