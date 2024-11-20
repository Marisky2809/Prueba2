using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        Vector3 rotation = new Vector3(-vertical, horizontal, 0f) * rotationSpeed * Time.deltaTime;

        transform.Rotate(rotation);
    }
}
