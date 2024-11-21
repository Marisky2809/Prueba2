using UnityEngine;

public class CajonInteractuar : MonoBehaviour
{
    public GameObject imageToShow;  // Imagen que muestra el cajón
    public GameObject imageToShow2; // Imagen del destornillador
    private bool isPlayerInTrigger = false; // Para saber si el jugador está en el área

    private void Start()
    {
        // Asegurarse de que las imágenes estén desactivadas al inicio si ya se ha recogido el destornillador
        if (GameManager.tieneDestornillador)
        {
            imageToShow.SetActive(false);
            imageToShow2.SetActive(false);
        }
        else
        {
            // Si el jugador no tiene el destornillador, asegúrate de que las imágenes estén desactivadas al inicio
            if (imageToShow != null)
            {
                imageToShow.SetActive(false);
            }

            if (imageToShow2 != null)
            {
                imageToShow2.SetActive(false);
            }
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

            // Opcional: Oculta la imagen cuando el jugador sale del área
            if (imageToShow != null)
            {
                imageToShow.SetActive(false);
                imageToShow2.SetActive(false);
            }
        }
    }

    private void Update()
    {
        // Verifica si el jugador está en el área y presiona la tecla Q
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Q))
        {
            if (!GameManager.tieneMagnet)
            {
                // Si el jugador no tiene el imán, muestra un mensaje
                Debug.Log("Necesitas el imán para abrir el cajón.");
                return; // Sale del método sin interactuar
            }

            // Si el jugador tiene el imán, muestra las imágenes para recoger el destornillador
            if (imageToShow != null && !GameManager.tieneDestornillador)
            {
                imageToShow.SetActive(true);
            }

            if (imageToShow2 != null && !GameManager.tieneDestornillador)
            {
                imageToShow2.SetActive(true);
            }
        }

        // Verifica si el jugador hace clic en la imagen para recoger el destornillador
        if (isPlayerInTrigger && Input.GetMouseButtonDown(0) && imageToShow2.activeSelf)
        {
            if (!GameManager.tieneDestornillador)
            {
                // Marca al jugador como que tiene el destornillador
                GameManager.tieneDestornillador = true;

                // Desactiva las imágenes del cajón
                imageToShow.SetActive(false);
                imageToShow2.SetActive(false);

                Debug.Log("Destornillador recogido");
            }
            else
            {
                Debug.Log("Ya tienes el destornillador.");
            }
        }
    }
}
