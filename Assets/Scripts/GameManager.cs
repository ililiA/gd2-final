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
        }
    }
    void Start()
    {
        player.transform.position = startPosition.position;
    }
    public void Transition()
    {
        startPosition = GameObject.FindWithTag("StartPosition").transform;
        player = GameObject.FindWithTag("Player");

        player.transform.position = startPosition.position;
        //player.transform.rotation = startPosition.rotation;
        Debug.Log("moving to start");

        //save = this.GetComponent<PlayerSaveAndLoad>();
        //save.Save();
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
