using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarEspejo : MonoBehaviour
{
    public GameObject mirrorWithReflection; // Espejo con el reflejo
    public GameObject mirrorWithoutReflection; // Espejo sin el reflejo

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

    private void Start()
    {
        // Al cargar la escena, verifica si el espejo ha sido cambiado previamente
        if (GameManager.espejoCambiado)
        {
            CambiarEspejo(); // Cambia el espejo si ya fue cambiado previamente
        }
    }

    private void Update()
    {
        // Verifica si el jugador est� en el �rea y presiona la tecla Q
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Q))
        {
            CambiarEspejo();
        }
    }

    private void CambiarEspejo()
    {
        // Cambia el espejo
        mirrorWithReflection.SetActive(false);
        mirrorWithoutReflection.SetActive(true);

        // Marca que el espejo ha sido cambiado
        GameManager.espejoCambiado = true;

        // Opcional: Desactivar el trigger para evitar m�ltiples interacciones
        gameObject.SetActive(false);
    }
}
