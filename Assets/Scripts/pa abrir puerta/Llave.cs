using UnityEngine;

public class Llave : MonoBehaviour
{
    private bool jugadorCerca = false;


    private void Start()
    {
        if (GameManager.tieneLlave)
        {
            // Si el jugador ya tiene la llave, desactiva el objeto de la llave
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            Debug.Log("Presiona 'E' para recoger la llave.");
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
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            RecogerLlave();
        }
    }

    private void RecogerLlave()
    {
        if (!GameManager.tieneLlave)  // Si el jugador no tiene la llave
        {
            Debug.Log("Llave recogida");
            GameManager.tieneLlave = true;  // Marca que el jugador tiene la llave
            Destroy(gameObject);  // Elimina la llave de la escena
        }
        else
        {
            Debug.Log("Ya tienes la llave.");
        }

        
    }
}
