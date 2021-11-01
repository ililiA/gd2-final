using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private UIController ui;

    public int health = 100, mana = 100, xp = 0; //manaPotion = 0, healthPotion = 0;

    

    public float regenTimer = 1, manaRegenInterval = 1;

    PlayerSaveAndLoad save;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetHealthSlider(health);
        ui.SetManaSlider(mana);
        ui.SetXPSlider(xp);
        //ui.SetManaPotion(manaPotion);
        //ui.SetHealthPotion(healthPotion);


        save = GetComponent<PlayerSaveAndLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mana < 100)
        {
            if(regenTimer > manaRegenInterval)
            {
                mana += 5;
                regenTimer = 0;
                ui.SetManaSlider(mana);
            }
            else
            {
                regenTimer += Time.deltaTime;
            }
        }
    }

    public void ChangeHealth(int byAmount)
    {
        health += byAmount;

        if(health <= 0)
        {
            // replace this with something better later
            //Application.LoadLevel(0);

            //call the loadHealth function
            save.Load();
        }

        if(health > 100)
        {
            health = 100;
        }

        ui.SetHealthSlider(health);
    }

    public void ChangeXP(int byAmount)
    {
        xp += byAmount;

        ui.SetXPSlider(xp);
    }

    public void ChangeMana(int byAmount)
    {
        mana += byAmount;

        ui.SetManaSlider(mana);
    }

    /*
    public void ChangeManaPotion(int byAmount)
    {
        manaPotion += byAmount;

        ui.SetManaPotion(manaPotion);
    }

    public void ChangeHealthPotion(int byAmount)
    {
        healthPotion += byAmount;

        ui.SetHealthPotion(manaPotion);
    }
    */
    
}
