using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{
    PlayerHealth manaPotion;
    PlayerHealth healthPotion;
    
    // Start is called before the first frame update
    void Start()
    {
        manaPotion = this.GetComponent<PlayerHealth>();

        healthPotion = this.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("HealthPotion"))
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("ManaPotion"))
        {
            Destroy(other.gameObject);
        }
    }
}
