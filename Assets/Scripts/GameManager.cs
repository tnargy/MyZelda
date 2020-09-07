using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GandyLabs.MyZelda
{
    public class GameManager : MonoBehaviour
    {
        public bool isPaused = false;
        public VectorValue loadPosition;

        public static GameManager Instance { get; private set; }
        private void Awake() 
        {
            if (Instance == null)
            {
                Instance = this;
                LoadScene(loadPosition.savedWorldPosition.ToString());
            }
            else
                Destroy(this.gameObject);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void Pause(float timeSpan)
        {
            StartCoroutine(PauseGame(timeSpan));
        }

        IEnumerator PauseGame(float timeSpan)
        {
            isPaused = true;
            yield return new WaitForSeconds(timeSpan);
            isPaused = false;
        }
    }
}