using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Propiedad estática para acceder a la instancia

    public static bool tieneLlave = false; // Propiedad estática para saber si el jugador tiene la llave
    public static bool espejoCambiado = false; // Variable estática para recordar si el espejo fue cambiado
    public static bool refrigeradorDesbloqueado = false; // Propiedad estática para almacenar si el refrigerador está desbloqueado
    public static bool refrigeradorAbierto = false;
    public static bool tieneMagnet = false; // Hacer estáticas todas las propiedades necesarias
    public static bool tieneDestornillador = false;
    public static bool palancaLiberada = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Asegura que el GameManager persista entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para cambiar el estado del refrigerador
    public static void DesbloquearRefrigerador()
    {
        refrigeradorDesbloqueado = true;
    }

   
}
