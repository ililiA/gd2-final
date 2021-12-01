using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextToPlayer : MonoBehaviour
{
    public TextMeshProUGUI playerText;

    public bool doesNotHaveYellowKey = true;
    public bool doesNotHaveRedKey = true;
    public bool doesNotHaveBlueKey = true;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Topaz"))
        {
            doesNotHaveYellowKey = false;
            Debug.Log("You've found the Topaz Key!");
            playerText.text = "You've found the Topaz Key!";
        }
        else if(other.gameObject.CompareTag("Sapphire"))
        {
            doesNotHaveBlueKey = false;
            Debug.Log("You've found the Sapphire Key!");
            playerText.text = "You've found the Sapphire Key!";
        }
        else if(other.gameObject.CompareTag("Ruby"))
        {
            doesNotHaveRedKey = false;
            Debug.Log("You've found the Ruby Key!");
            playerText.text = "You've found the Ruby Key!";
        }

        /*
        if(other.gameObject.CompareTag("TheEnd"))
        {
             if(doesNotHaveYellowKey == false && doesNotHaveBlueKey == false && doesNotHaveRedKey == false)
            {    
                playerText.text = "";
            }
            else
            {
                Debug.Log("You need all three keys to cross the barrier!");
                playerText.text = "You need all three keys to cross the barrier!";
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            playerText.text = "";
        }
    }
}
