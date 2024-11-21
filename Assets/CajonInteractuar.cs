using UnityEngine;

public class CajonInteractuar : MonoBehaviour
{
    public GameObject imageToShow;  // Imagen que muestra el caj�n
    public GameObject imageToShow2; // Imagen del destornillador
    private bool isPlayerInTrigger = false; // Para saber si el jugador est� en el �rea

    private void Start()
    {
        // Asegurarse de que las im�genes est�n desactivadas al inicio si ya se ha recogido el destornillador
        if (GameManager.tieneDestornillador)
        {
            imageToShow.SetActive(false);
            imageToShow2.SetActive(false);
        }
        else
        {
            // Si el jugador no tiene el destornillador, aseg�rate de que las im�genes est�n desactivadas al inicio
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

            // Opcional: Oculta la imagen cuando el jugador sale del �rea
            if (imageToShow != null)
            {
                imageToShow.SetActive(false);
                imageToShow2.SetActive(false);
            }
        }
    }

    private void Update()
    {
        // Verifica si el jugador est� en el �rea y presiona la tecla Q
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Q))
        {
            if (!GameManager.tieneMagnet)
            {
                // Si el jugador no tiene el im�n, muestra un mensaje
                Debug.Log("Necesitas el im�n para abrir el caj�n.");
                return; // Sale del m�todo sin interactuar
            }

            // Si el jugador tiene el im�n, muestra las im�genes para recoger el destornillador
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

                // Desactiva las im�genes del caj�n
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
