using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToDoor : MonoBehaviour
{
    public string targetSceneName; // Nombre de la escena a cargar
    private bool isPlayerInTrigger = false; // Para saber si el jugador está dentro del trigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta si el jugador entra en el trigger
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Detecta si el jugador sale del trigger
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void Update()
    {
        // Verifica si el jugador está en el área y presiona la tecla Q
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Q))
        {
            // Carga la escena objetivo
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
