using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake() => Instance = this;
    
    public void LoadScene(string sceneName, Vector2 spawnLocation)
    {
        SceneManager.LoadScene(sceneName);
        if (spawnLocation.Equals(Vector2.zero))
            return;
            
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnLocation;
    }
}
