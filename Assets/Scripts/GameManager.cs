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
    public GameObject playText;
    public GameObject exitText;
    public TextMeshProUGUI scoreText;
    int score = 0;
    
    void Start()
    {
        Time.timeScale = 0;
    }

    void StartSpawning() 
    {
        InvokeRepeating(nameof(SpawnBlock), 0.5f, spawnRate);
    }

    private void SpawnBlock() 
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(block, spawnPos, Quaternion.identity);

        score++;

        scoreText.text = score.ToString();
    }

    public void StartGame() {
        Time.timeScale = 1;
        StartSpawning();
        playText.SetActive(false);
        exitText.SetActive(false);
    }

    public void ExitGame() {
        Debug.Log("Exit Application");
        Application.Quit(); 
    }
}
