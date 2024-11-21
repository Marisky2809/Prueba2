using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCushion : MonoBehaviour
{
    public GameObject sofaWithCushion; // El sof� con coj�n
    public GameObject sofaWithoutCushion; // El sof� sin coj�n

    private bool isPlayerInTrigger = false; // Para saber si el jugador est� en el �rea

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta si el jugador entra en el �rea de interacci�n
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Detecta si el jugador sale del �rea de interacci�n
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void Update()
    {
        // Verifica si el jugador est� en el �rea y presiona la tecla Q
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Q))
        {
            // Cambia el sof�
            sofaWithCushion.SetActive(false);
            sofaWithoutCushion.SetActive(true);

            // Mensaje de depuraci�n
            Debug.Log("El coj�n ha sido removido.");
        }
    }
}
