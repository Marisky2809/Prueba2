using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    public Animator animator; // Referencia al Animator del personaje
    public string nombreTrigger = "isAgarro"; // Nombre del Trigger en el Animator

    private bool isPlayerInTrigger = false; // Para saber si el jugador est� cerca del objeto
    private bool animacionEjecutada = false; // Para evitar m�ltiples reproducciones

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && !animacionEjecutada)
        {
            animacionEjecutada = true; // Marca que la animaci�n ya fue ejecutada
            animator.SetTrigger(nombreTrigger); // Reproducir la animaci�n

            // Opcional: Desactivar el objeto despu�s de que el jugador lo agarre
            gameObject.SetActive(false);
        }
    }
}
