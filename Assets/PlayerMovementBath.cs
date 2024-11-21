using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBath : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float sprintSpeed = 6f;
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float staminaCostPerSecond = 10f;
    [SerializeField] private float staminaRegenRate = 5f;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private float currentStamina;
    private Animator playerAnimator;
    private bool isRunning;
    private bool canRun;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        currentStamina = maxStamina;
        playerAnimator = GetComponent<Animator>();
        canRun = true;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        // Verificar si puede correr solo si hay suficiente estamina y está permitido correr
        isRunning = moveInput.magnitude > 0 && Input.GetKey(KeyCode.LeftShift) && currentStamina > 0 && canRun;

        // Regenerar estamina cuando no se está corriendo
        if (!isRunning)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Min(currentStamina, maxStamina);

            // Habilitar correr nuevamente si la estamina está completamente llena
            if (currentStamina >= maxStamina)
            {
                canRun = true;
            }
        }

        // Verificar si el personaje está en el límite y aún tiene input de movimiento
        bool atLimit = (transform.position.x <= -8.26f && moveX < 0) || (transform.position.x >= 8.19f && moveX > 0) ||
                       (transform.position.y <= -2.67f && moveY < 0) || (transform.position.y >= 2.76f && moveY > 0);

        // Actualizar Speed de inmediato sin interpolación
        float targetSpeed = atLimit ? 0 : moveInput.sqrMagnitude;
        playerAnimator.SetFloat("Speed", targetSpeed);

        // Asegurarse de que isRunning se desactive de inmediato cuando dejas de moverte
        playerAnimator.SetBool("isRunning", isRunning && !atLimit);

        // Voltear el personaje en el eje X al moverse a la izquierda o derecha
        if (moveX != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (moveX > 0 ? 1 : -1);
            transform.localScale = scale;
        }

        LimitPosition();
    }

    private void FixedUpdate()
    {
        float currentSpeed = isRunning ? sprintSpeed : speed;

        if (isRunning)
        {
            currentStamina -= staminaCostPerSecond * Time.fixedDeltaTime;
            currentStamina = Mathf.Max(currentStamina, 0);

            // Si la estamina llega a 0, desactivar la opción de correr
            if (currentStamina <= 0)
            {
                canRun = false; // Desactivar la habilidad de correr hasta que la estamina se recupere por completo
            }
        }

        playerRb.MovePosition(playerRb.position + moveInput * currentSpeed * Time.fixedDeltaTime);
    }

    void LimitPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -8.48f, 8.19f);
        pos.y = Mathf.Clamp(pos.y, -2.63f, 1.6f);
        transform.position = pos;
    }
}
