using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Propiedad est�tica para acceder a la instancia

    public static bool tieneLlave = false; // Propiedad est�tica para saber si el jugador tiene la llave
    public static bool espejoCambiado = false; // Variable est�tica para recordar si el espejo fue cambiado
    public static bool refrigeradorDesbloqueado = false; // Propiedad est�tica para almacenar si el refrigerador est� desbloqueado
    public static bool refrigeradorAbierto = false;
    public static bool tieneMagnet = false; // Hacer est�ticas todas las propiedades necesarias
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

    // M�todo para cambiar el estado del refrigerador
    public static void DesbloquearRefrigerador()
    {
        refrigeradorDesbloqueado = true;
    }

   
}
