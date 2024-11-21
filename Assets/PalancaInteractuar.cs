using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaInteractuar : MonoBehaviour
{
    public GameObject PalancaUp; // Palanca en su estado inicial
    public GameObject PalancaDown; // Palanca en su estado activado

    private bool isPlayerInTrigger = false; // Para saber si el jugador está en el área

    private void Start()
    {
        // Comprobar el estado de la palanca en el GameManager al cargar la escena
        if (GameManager.palancaLiberada)
        {
            // Si la palanca ya ha sido liberada, muestra la palanca activada
            PalancaUp.SetActive(false);
            PalancaDown.SetActive(true);
        }
        else
        {
            // Si la palanca no ha sido liberada, muestra la palanca en su estado inicial
            PalancaUp.SetActive(true);
            PalancaDown.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta si el jugador entra en el área de interacción
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Detecta si el jugador sale del área de interacción
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
            // Verifica si el jugador tiene el destornillador
            if (GameManager.tieneDestornillador)
            {
                // Cambia la palanca de posición
                PalancaUp.SetActive(false);
                PalancaDown.SetActive(true);

                // Marca la palanca como liberada en el GameManager
                GameManager.palancaLiberada = true;

                // Opcional: Desactivar el trigger para evitar múltiples interacciones
                gameObject.SetActive(false);
                Debug.Log("La palanca ha sido liberada.");
            }
            else
            {
                Debug.Log("Necesitas un destornillador para liberar la palanca.");
            }
        }
    }
}
