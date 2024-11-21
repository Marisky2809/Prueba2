using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory _instance;  // Instancia �nica del inventario
    private List<string> items = new List<string>();  // Lista de items en el inventario

    // Propiedad para acceder a la instancia global del inventario
    public static Inventory Instance
    {
        get
        {
            // Si no existe una instancia, busca el objeto de inventario en la escena
            if (_instance == null)
            {
                _instance = FindObjectOfType<Inventory>();
                // Si no encuentra ninguna instancia, crea un nuevo objeto de inventario
                if (_instance == null)
                {
                    GameObject inventoryObject = new GameObject("Inventory");
                    _instance = inventoryObject.AddComponent<Inventory>();
                }
                // Asegura que no se destruya al cargar una nueva escena
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    // M�todo para agregar la llave al inventario
    public void AddKey()
    {
        items.Add("Llave");
        Debug.Log("Llave a�adida al inventario");
    }

    // M�todo para agregar el im�n al inventario
    public void AddMagnet(string Magnet)
    {
        items.Add(Magnet);
        Debug.Log(Magnet + " a�adido al inventario.");
    }

    // M�todo para agregar el destornillador al inventario
    public void AddDestornillador(string Destornillador)
    {
        items.Add(Destornillador);
        Debug.Log(Destornillador + " a�adido al inventario.");
    }

    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }

    // M�todo para mostrar los items del inventario (�til para depuraci�n)
    public void ShowInventory()
    {
        foreach (string item in items)
        {
            Debug.Log(item);
        }
    }

    void Awake()
    {
        // Asegura que la instancia persista entre escenas
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Mantener la instancia entre escenas
        }
        else
        {
            Destroy(gameObject); // Destruye el objeto si ya existe una instancia
        }
    }
}
