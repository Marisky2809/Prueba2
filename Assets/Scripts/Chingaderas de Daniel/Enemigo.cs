using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject jugador;
    public GameObject enemigo;
    private Vector3 direction;

    public float velocidad;
    public float buffo = 0.2f;
    public float limVelocidad = 3;

    public float MuyCerca = 2;
    public float AlgoCerca = 5;

    public SpriteRenderer corazon;


    public float TiempoBuffer = 2f;
    private bool buffer = false;

    private void Start()
    {
        StartCoroutine(BucleCorrutina());
        buffer = false;
    }

    void Update()
    {
        if (buffer)
        {
            buffer = false;
            StartCoroutine(BucleCorrutina());
        }

        direction = jugador.transform.position - enemigo.transform.position;
        enemigo.transform.Translate(direction.normalized * velocidad * Time.deltaTime);

        if(direction.magnitude < MuyCerca)
        {
            Debug.Log("Cagaste");
            corazon.color = Color.white;
        }
        else if (direction.magnitude < AlgoCerca)
        {
            Debug.Log("Aguas");
            corazon.color = Color.gray;
        }
        else if(direction.magnitude > AlgoCerca)
        {
            Debug.Log("No hay pedo");
            corazon.color = Color.black;
        }
    }

    private IEnumerator BucleCorrutina()
    {
        yield return new WaitForSeconds(TiempoBuffer);
        buffer = true;
        if(velocidad < limVelocidad)
        {
            velocidad += buffo;
        }
    }
}
