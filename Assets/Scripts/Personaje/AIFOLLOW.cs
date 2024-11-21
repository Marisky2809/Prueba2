using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AIFOLLOW : MonoBehaviour
{

    public GameObject player;
    private float speed;

    private float distance;

    private void Start()
    {
        speed = 2;
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direccion = player.transform.position - transform.position;
        direccion.Normalize();
        float angle = Mathf.Atan2(direccion.x, direccion.y) * Mathf.Rad2Deg;

        

        if (distance < 4)
        {

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle); speed = 0;

        }

        else
        {


            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle); speed = 2;


        }


    }


}
