using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button startButton;
    public GameObject titleScreen;
    private Vector3 playerSpawnPos = new Vector3(0, 1, 0);
    public SpawnManager spawnManager;
    public GameObject player;
    void Start()
    {
                
    }

    public void StartGame()
    {
        spawnManager.ActivateSpawning();
        titleScreen.gameObject.SetActive(false);
        Instantiate(player, playerSpawnPos, Quaternion.identity);
    }
}
