using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner2D : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    private List<GameObject> activeEnemies = new List<GameObject>(); // Lista de enemigos activos

    private BoxCollider2D spawnArea; // Área de spawn (Collider 2D)
    private float spawnTimer = 0f; // Temporizador para el spawn
    [Range(1f, 60f)]
    public float spawnInterval = 10f; // Intervalo de tiempo en segundos
    public int maxEnemies = 5; // Límite de enemigos en la escena

    private void Start()
    {
        // Obtén el BoxCollider2D del objeto de spawn
        spawnArea = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Si hay espacio para más enemigos, comienza el temporizador
        if (activeEnemies.Count < maxEnemies)
        {
            spawnTimer += Time.deltaTime;

            // Verifica si han pasado el intervalo de spawn
            if (spawnTimer >= spawnInterval)
            {
                // Restablece el temporizador
                spawnTimer = 0f;

                // Aplica la probabilidad de 1 en 50
                if (Random.Range(1, 51) == 1)
                {
                    SpawnEnemy();
                }
                Debug.Log("pip");
            }
        }
    }

    private void SpawnEnemy()
    {
        // Genera una posición aleatoria dentro del área de spawn
        Vector2 spawnPosition = GetRandomPositionInArea();

        // Crea el enemigo y almacena su referencia
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        activeEnemies.Add(newEnemy);
        Debug.Log("Enemigo generado en: " + spawnPosition);
    }

    private Vector2 GetRandomPositionInArea()
    {
        // Calcula una posición aleatoria dentro del área de spawn
        Vector2 center = spawnArea.bounds.center;
        Vector2 size = spawnArea.bounds.size;

        float x = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float y = Random.Range(center.y - size.y / 2, center.y + size.y / 2);

        return new Vector2(x, y);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        // Remueve el enemigo de la lista de enemigos activos
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
            Debug.Log("Enemigo removido: " + enemy.name);
            Destroy(enemy); // Destruye el enemigo si ya no es necesario
        }
    }
}