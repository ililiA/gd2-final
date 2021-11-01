using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    PlayerHealth hp;
    PlayerHealth mana;
    PlayerHealth manaPotion;
    PlayerHealth healthPotion;

    void Start()
    {
        hp = this.GetComponent<PlayerHealth>();
        Debug.Log("health = " + hp.health);

        mana = this.GetComponent<PlayerHealth>();
        Debug.Log("mana = " + mana.health);

        manaPotion = this.GetComponent<PlayerHealth>();
        Debug.Log("Mana Potions = " + manaPotion.health);

        healthPotion = this.GetComponent<PlayerHealth>();
        Debug.Log("Health Potions = " + healthPotion.health);
    }

    public void Save()
    {
        Debug.Log("Saved!");

        PlayerPrefs.SetInt("hp", hp.health);
        PlayerPrefs.SetInt("mana", mana.health);

        PlayerPrefs.SetFloat("posX", transform.position.x);
        PlayerPrefs.SetFloat("posY", transform.position.y);
        PlayerPrefs.SetFloat("posZ", transform.position.z);

        PlayerPrefs.SetInt("manaPotion", manaPotion.health);
        PlayerPrefs.SetInt("healthPotion", healthPotion.health);
    }

    public void Load()
    {
        Debug.Log("Loading!");

        hp.health = PlayerPrefs.GetInt("hp", 100);
        mana.health = PlayerPrefs.GetInt("mana", 100);

        manaPotion.health = PlayerPrefs.GetInt("manaPotion");
        healthPotion.health = PlayerPrefs.GetInt("healthPotion");

        Vector3 newPosition;

        newPosition.x = PlayerPrefs.GetFloat("posX");
        newPosition.y = PlayerPrefs.GetFloat("posY");
        newPosition.z = PlayerPrefs.GetFloat("posZ");

        this.transform.position = newPosition;
    }

    

    
}
