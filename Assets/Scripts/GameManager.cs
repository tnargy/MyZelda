using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;

        canChangeScene = true;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    static Dictionary<int, Vector3> savedPositions = new Dictionary<int, Vector3>();
    public static bool canChangeScene;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (savedPositions.ContainsKey(scene.buildIndex))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = savedPositions[scene.buildIndex];
        }
    }

    public void LoadScene(string sceneName)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        savedPositions[sceneIndex] = GameObject.FindGameObjectWithTag("Player").transform.position;
        SceneManager.LoadScene(sceneName);
    }
}
