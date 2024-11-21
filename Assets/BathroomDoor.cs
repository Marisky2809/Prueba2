using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomDoor : MonoBehaviour
{
    public string requiredItem = "Llave"; // Nombre del ítem necesario para abrir la puerta
    public GameObject doorClosed; // Representa la puerta cerrada
    public GameObject doorOpen; // Representa la puerta abierta
    public Inventory inventory; // Referencia al sistema de inventario

    private bool isPlayerInTrigger = false; // Para saber si el jugador está en el área

    private void Start()
    {
        // Comprobar si la puerta ya ha sido desbloqueada al iniciar la escena
        if (PlayerPrefs.GetInt("BathroomDoorUnlocked", 0) == 1)
        {
            // Si la puerta ya está desbloqueada, la ponemos abierta
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
        }
        else
        {
            // Si no, la puerta permanece cerrada
            doorClosed.SetActive(true);
            doorOpen.SetActive(false);
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
            if (inventory != null && inventory.HasItem(requiredItem))
            {
                // Si el jugador tiene el ítem requerido, abre la puerta
                doorClosed.SetActive(false);
                doorOpen.SetActive(true);

                // Guardamos que la puerta ha sido desbloqueada
                PlayerPrefs.SetInt("BathroomDoorUnlocked", 1);
                PlayerPrefs.Save(); // Guarda los cambios

                // Mensaje de depuración
                Debug.Log("Puerta abierta con éxito.");
            }
            else
            {
                // Mensaje de depuración si no tiene la llave
                Debug.Log("No tienes la llave para abrir esta puerta.");
            }
        }
    }
}
