using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float startDelay = 2.0f;
    private float spawnInterval = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnAnimal",startDelay,spawnInterval);
    }

    void Update()
    {
    }

    void SpawnAnimal()
    {
        int animalIndex = Random.Range(0,animalPrefabs.Length);
        int spawnPosition = Random.Range(-9,9);
        Instantiate(animalPrefabs[animalIndex], new Vector3(-20,0,spawnPosition), animalPrefabs[animalIndex].transform.rotation);
    }
}
