using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; // Asigna el transform del jugador desde el Inspector
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10); // Ajuste de distancia para la cámara
    [SerializeField] private float followSpeed = 5f; // Velocidad para suavizar el movimiento

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 targetPosition = playerTransform.position + offset; // Posición objetivo con el offset
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime); // Movimiento suave
        }
    }
}
