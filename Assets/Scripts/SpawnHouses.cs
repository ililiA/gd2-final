using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHouses : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] houses;
    public GameObject[] rubble;

    //following along/different from mine
    public Transform player;
    public GameObject aiPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform point in spawnPoints)
        {
            float chanceToSpawnHouse = Random.value;
            float chanceToSpawnRubble = Random.value;
            Debug.Log("Chance to spawn house: " + chanceToSpawnHouse);
            Debug.Log("Chance to spawn rubble: " + chanceToSpawnRubble);
            if(Random.value < .75f)
            {
                GameObject newHouse = Instantiate(houses[Random.Range(0, houses.Length)]);
                newHouse.transform.position = point.position;
                newHouse.transform.rotation = point.rotation;
                // spawn in 2-5 AI
                int numberOfAI = Random.Range(2, 3);
                for(int i = 0; i < numberOfAI; i += 1)
                {
                    GameObject ai = Instantiate(aiPrefab, point.position, point.rotation);
                    ai.GetComponent<EnemyHealth>().player = player;
                }
            }
            else
            {
                GameObject newRubble = Instantiate(rubble[Random.Range(0, rubble.Length)]);
                newRubble.transform.position = point.position;
                newRubble.transform.rotation = point.rotation;
            }
        }
    }

}
