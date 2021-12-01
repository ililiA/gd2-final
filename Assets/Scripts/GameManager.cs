//transitions and whatnot
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Transform startPosition;

    private PlayerSaveAndLoad save;

    // before any other Start() functions
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(startPosition == null)
        {
            Debug.LogError("<color=red>You have not selected a start position.</color>");
            startPosition = GameObject.FindWithTag("StartPosition").transform;
            Debug.Log("found start!");
        }
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
            Debug.Log("Found player!");
        }
    }
    
    public void Transition()
    {
        Debug.Log("moving to start!");

        if(startPosition == null)
        {
            Debug.LogError("<color=red>You have not selected a start position.</color>");
            startPosition = GameObject.FindWithTag("StartPosition").transform;
            Debug.Log("found start!");
        }
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
            Debug.Log("Found player!");
        }
        
        player.transform.position = startPosition.position;
        player.transform.rotation = startPosition.rotation;

        save = this.GetComponent<PlayerSaveAndLoad>();
        save.Save();
    }

    void Update()
    {
        if(startPosition == null)
        {
            Debug.LogError("<color=red>You have not selected a start position.</color>");
            startPosition = GameObject.FindWithTag("StartPosition").transform;
            Debug.Log("found start!");
        }
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }
}
