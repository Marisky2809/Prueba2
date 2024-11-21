using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Encuentra el objeto SpawnPoint en la escena
        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (spawnPoint != null && player != null)
        {
            // Mueve al jugador a la posición del SpawnPoint
            player.transform.position = spawnPoint.transform.position;
            Debug.Log("Player moved to spawn point at: " + spawnPoint.transform.position);
        }
        else
        {
            Debug.LogWarning("SpawnPoint or Player not found in the scene.");
        }
    }
}
