// handle collision with enemies and firing magic
// haarryy?                sIr
// advanced potions like felix felicis too
// sound of silence

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

    public Rigidbody magicBullet;
    public Transform hand;
    ItemController item;

    [Header("Audio")]
    
    public AudioSource aud;
    public AudioClip magicClip;
    [Range(0f, 1f)]
    public float magicVolume = .5f;

    [SerializeField]
    private int manaPotion = 0;
    public TextMeshProUGUI manaPotionText;

    [SerializeField]
    private int healthPotion = 0;
    public TextMeshProUGUI healthPotionText;

    private PlayerSaveAndLoad save;
    public GameManager transition;
    public UIController ui;
    public Rigidbody rb;

    public int yellowKey = 0;
    public int blueKey = 0;
    public int redKey = 0;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if(rb == null)
        {
            rb = this.GetComponent<Rigidbody>();
        }
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
        //this means it's on the same object!!!
        //if script function is on another object you have to find the other object then the script
        transition = GameObject.Find("Game Manager").GetComponent<GameManager>();

        rb.velocity = Vector3.zero;                 //set speed to zero
        rb.angularVelocity = Vector3.zero;          //set rotation to zero
    }

    // this should go to the input manager script
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(item != null)
            {
                if(hp.mana > 0)
                {
                    item.Fire();
                    hp.ChangeMana(-10);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(item != null)
            {
                item.Drop();
                item = null;
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            hp.ChangeHealth(-10);
            //taking damage
        }

        if(other.gameObject.CompareTag("Pickupable"))
        {
            if(item == null)
            {
                // we can pick up the object
                item = other.gameObject.GetComponent<ItemController>();
                // move the object to our hand
                other.gameObject.transform.position = hand.position;
                // make the object a child of the hand so it follows
                other.gameObject.transform.SetParent(hand);
                // make the object fave the same direction as the hand
                other.gameObject.transform.rotation = hand.rotation;
                // keep the gun from falling
                other.GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                Debug.Log("Already holding something.");
            }
        }

        if(other.gameObject.CompareTag("HealthPotion"))
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

        if(other.gameObject.CompareTag("SnowRuinTransition"))
        {
            Debug.Log("running transition");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:1);
            transition.Transition();
            //load next scene
        }
        else if(other.gameObject.CompareTag("ForestHavenTransition"))
        {
            Debug.Log("running transition");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:0);
            transition.Transition();
        }
        else if(other.gameObject.CompareTag("EmberMountainsTransition"))
        {
            Debug.Log("running transition");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:2);
            transition.Transition();
        }

        Debug.Log(other.tag);
        if(other.gameObject.CompareTag("Topaz"))
        {
            yellowKey += 1;
            Destroy(other.gameObject);
        }
        Debug.Log(other.tag);
        if(other.gameObject.CompareTag("Sapphire"))
        {
            blueKey += 1;
            Destroy(other.gameObject);
        }
        Debug.Log(other.tag);
        if(other.gameObject.CompareTag("Ruby"))
        {
            redKey += 1;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("TheEnd"))
        {
            if(yellowKey > 0 && blueKey > 0 && redKey > 0)
            {    
                yellowKey -= 1;
                blueKey -= 1;
                redKey -= 1;
                
                Debug.Log("running transition");
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:3);
                transition.Transition();
            }
            else
            {
                Debug.Log("You need all three keys to cross the barrier!");
            }
        }

        if(other.gameObject.CompareTag("Ice"))
        {
            rb.drag = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Ice"))
        {
            rb.drag = 5;
        }
    }
}
