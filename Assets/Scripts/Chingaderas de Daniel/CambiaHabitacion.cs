using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiaHabitacion : MonoBehaviour
{
    public string targetSceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta si el jugador entra en el trigger
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
