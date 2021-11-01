using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingLoading : MonoBehaviour
{
    int health = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Health", Random.Range(1, 99));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("health = " + health);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetHealth();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("my x position is " + transform.position.x);
            Debug.Log("my y position is " + transform.position.y);
            Debug.Log("my z position is " + transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            //saving location
            Debug.Log("Saving Position: " + transform.position);
            SetPosition();
        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            //moving back to saved location
            Debug.Log("Loading Save");
            GetPosition();
        }
    }

    void GetHealth()
    {
        health = PlayerPrefs.GetInt("Health", 100);
    }

    //save the postion of this gameobject as 3 floats
    void SetPosition()
    {
        PlayerPrefs.SetFloat("posX", transform.position.x);
        PlayerPrefs.SetFloat("posY", transform.position.y);
        PlayerPrefs.SetFloat("posZ", transform.position.z);
    }

    void GetPosition()
    {
        Vector3 newPosition;

        newPosition.x = PlayerPrefs.GetFloat("posX");
        newPosition.y = PlayerPrefs.GetFloat("posY");
        newPosition.z = PlayerPrefs.GetFloat("posZ");

        this.transform.position = newPosition;
        
    }

    /*
        lots of comments yay
        ~comment block~

        pseudocode is plain english laid out like code
        Q: how do we get the xyz of a vector3 into floats?
            A: transform.position.x
        Q: what do I do with the floats then to save them?
        Q: how do I load those floats back into the player position?
    */
}
