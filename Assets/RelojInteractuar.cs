using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
    public GameObject inputFieldObject; // Campo de texto
    public InputField inputField; // Entrada del jugador
    private bool jugadorCerca = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            Debug.Log("Presiona 'Q' para interactuar con el reloj.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }

    private void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.Q))
        {
            inputFieldObject.SetActive(true);
            inputField.ActivateInputField();
        }
    }

    public void VerificarHora()
    {
        string horaIngresada = inputField.text;

        if (horaIngresada == "11:11")
        {
            GameManager.refrigeradorDesbloqueado = true; // Marca el refrigerador como desbloqueado
            Debug.Log("¡La hora es correcta! El refrigerador ha sido desbloqueado.");
        }
        else
        {
            Debug.Log("Hora incorrecta.");
        }

        inputFieldObject.SetActive(false);
    }
}
