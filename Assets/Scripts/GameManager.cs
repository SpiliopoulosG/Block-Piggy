using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    int score = 0;
    bool gameStarted = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !gameStarted)
        {
            gameStarted = true;
            StartSpawning();
            tapText.SetActive(false);
        }
    }

    void StartSpawning() 
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock() 
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(block, spawnPos, Quaternion.identity);

        score++;

        scoreText.text = score.ToString();
    }
}
