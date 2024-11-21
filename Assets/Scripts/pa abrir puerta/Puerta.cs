using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public string escenaDestino; // Nombre de la escena a cargar
    private bool jugadorCerca = false; // Indica si el jugador está cerca de la puerta
    private bool puertaDesbloqueada = false; // Indica si la puerta está desbloqueada

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true; // El jugador está en el área del trigger
            Debug.Log("Presiona 'Q' para interactuar con la puerta.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false; // El jugador salió del área del trigger
        }
    }

    private void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.Q)) // Si el jugador presiona Q cerca de la puerta
        {
            if (!puertaDesbloqueada && GameManager.tieneLlave) // Accediendo a la propiedad estática
            {
                DesbloquearPuerta(); // Desbloquea la puerta si tiene la llave
            }
            else if (puertaDesbloqueada)
            {
                CambiarEscena(); // Cambia de escena si la puerta ya está desbloqueada
            }
            else
            {
                Debug.Log("No tienes la llave para desbloquear la puerta.");
            }
        }
    }

    private void DesbloquearPuerta()
    {
        puertaDesbloqueada = true;
        Debug.Log("¡Puerta desbloqueada!");
        // Aquí puedes añadir una animación o un efecto visual si quieres
    }

    private void CambiarEscena()
    {
        if (!string.IsNullOrEmpty(escenaDestino))
        {
            Debug.Log("Cambiando a la escena: " + escenaDestino);
            SceneManager.LoadScene(escenaDestino); // Cambia a la escena especificada
        }
        else
        {
            Debug.LogError("No se ha asignado una escena de destino.");
        }
    }
}
