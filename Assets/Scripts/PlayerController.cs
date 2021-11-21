// handle collision with enemies and firing magic
// haarryy?                sIr
// advanced potions like felix felicis too

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth hp;

    [SerializeField]
    private PlayerHealth mana;

    [SerializeField]
    private Rigidbody magicBullet;

    [SerializeField]
    private Transform hand;

    [SerializeField]
    private int manaPotion = 0;
    public TextMeshProUGUI manaPotionText;

    [SerializeField]
    private int healthPotion = 0;
    public TextMeshProUGUI healthPotionText;

    private PlayerSaveAndLoad save;

    public UIController ui;

    public Rigidbody rb;

    void Start()
    {
        if(hp == null)
        {
            hp = this.GetComponent<PlayerHealth>();
        }
        if(mana == null)
        {
            mana = this.GetComponent<PlayerHealth>();
        }

        //manaPotion = this.GetComponent<PlayerHealth>();
        //healthPotion = this.GetComponent<PlayerHealth>();

        save = this.GetComponent<PlayerSaveAndLoad>();
    }

    // this should go to the input manager script
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(hp.mana > 0)
            {
                Fire();
                hp.ChangeMana(-10);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(manaPotion > 0)
            {
                manaPotion -= 1;
                manaPotionText.text = "Mana Potions: " + manaPotion.ToString();
                hp.ChangeMana(50);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(healthPotion > 0)
            {
                healthPotion -=1;
                healthPotionText.text = "Health Potions: " + healthPotion.ToString();
                hp.ChangeHealth(25);
            }
        }
    }

    void Fire()
    {
        Rigidbody copy = Instantiate(magicBullet, hand.position, hand.rotation);
        //copy.transform.Translate(Vector3.forward * 2); // move the bullet in front of the player
        copy.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse); // shoot bullet forward
        copy.GetComponent<BulletController>().owner = hp;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            hp.ChangeHealth(-10);
        }

        else if(other.gameObject.CompareTag("HealthPotion"))
        {
            healthPotion += 1;
            healthPotionText.text = "Health Potions: " + healthPotion.ToString();
            Destroy(other.gameObject);
            //ui.SetHealthPotion(healthPotion.health);
            //play drink audio clip
        }
        else if(other.gameObject.CompareTag("Food"))
        {
            hp.ChangeHealth(10);
            Destroy(other.gameObject);
            //play eat audio clip
        }

        else if(other.gameObject.CompareTag("ManaPotion"))
        {
            manaPotion += 1;
            manaPotionText.text = "Mana Potions: " + manaPotion.ToString();
            Destroy(other.gameObject);
            //ui.SetManaPotion(manaPotion.health);
            //play drink audio clip
        }
        else if(other.gameObject.CompareTag("Checkpoint"))
        {
            //call the save function
            save.Save();
        }

        else if(other.gameObject.CompareTag("ManaPotion"))
        {
            rb.drag = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("ManaPotion"))
        {
            rb.drag = 5;
        }
    }
}
