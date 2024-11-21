using UnityEngine;

public class Magnet : MonoBehaviour
{
    private bool jugadorCerca = false;

    private void Start()
    {
        // Si el jugador ya tiene el magneto, desactiva el objeto del magneto en la escena
        if (GameManager.tieneMagnet)
        {
            gameObject.SetActive(false);  // Desactiva el magneto si ya fue recogido
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            Debug.Log("Presiona 'E' para recoger el magnet.");
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
            RecogerMagnet();
        }
    }

    private void RecogerMagnet()
    {
        if (!GameManager.tieneMagnet)  // Si el jugador no tiene el magneto
        {
            Debug.Log("Magnet recogido");
            GameManager.tieneMagnet = true;  // Marca que el jugador tiene el magneto
            Destroy(gameObject);  // Elimina el magneto de la escena para evitar que vuelva a aparecer
        }
        else
        {
            Debug.Log("Ya tienes el magneto.");
        }
    }
}
