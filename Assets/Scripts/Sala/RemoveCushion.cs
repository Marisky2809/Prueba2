using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCushion : MonoBehaviour
{
    public GameObject sofaWithCushion; // El sofá con cojín
    public GameObject sofaWithoutCushion; // El sofá sin cojín

    private bool isPlayerInTrigger = false; // Para saber si el jugador está en el área

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
            // Cambia el sofá
            sofaWithCushion.SetActive(false);
            sofaWithoutCushion.SetActive(true);

            // Mensaje de depuración
            Debug.Log("El cojín ha sido removido.");
        }
    }
}
