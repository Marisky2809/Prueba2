using UnityEngine;

public class Refrigerador : MonoBehaviour
{
    public GameObject refrigeradorCerrado; // Imagen del refrigerador cerrado
    public GameObject refrigeradorAbierto; // Imagen del refrigerador abierto
    public GameObject magnet; // El im�n dentro del refrigerador
    private bool jugadorCerca = false; // Indica si el jugador est� cerca

    private void Start()
    {
        // Configura el estado inicial basado en el GameManager
        if (GameManager.refrigeradorDesbloqueado)  // Acceso est�tico
        {
            refrigeradorCerrado.SetActive(false);
            refrigeradorAbierto.SetActive(true);

            // Verifica si el jugador ya ha recogido el magneto
            if (!GameManager.tieneMagnet)  // Si el jugador no tiene el magneto, lo muestra
            {
                magnet.SetActive(true); // Hace visible el im�n
            }
            else
            {
                magnet.SetActive(false); // Si el jugador ya tiene el magneto, lo oculta
            }
        }
        else
        {
            refrigeradorCerrado.SetActive(true);
            refrigeradorAbierto.SetActive(false);
            magnet.SetActive(false); // Oculta el im�n si el refrigerador est� cerrado
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            Debug.Log("Presiona 'Q' para interactuar con el refrigerador.");
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
            if (GameManager.refrigeradorDesbloqueado)  // Acceso est�tico
            {
                AbrirRefrigerador();
            }
            else
            {
                Debug.Log("El refrigerador est� cerrado.");
            }
        }
    }

    private void AbrirRefrigerador()
    {
        refrigeradorCerrado.SetActive(false);
        refrigeradorAbierto.SetActive(true);

        // Aseg�rate de que el im�n solo sea visible si no ha sido recogido
        if (!GameManager.tieneMagnet)  // Verifica si el jugador no tiene el magneto
        {
            magnet.SetActive(true); // Hace visible el im�n
        }
        else
        {
            magnet.SetActive(false); // Oculta el im�n si ya fue recogido
        }

        Debug.Log("Refrigerador abierto.");
    }
}
