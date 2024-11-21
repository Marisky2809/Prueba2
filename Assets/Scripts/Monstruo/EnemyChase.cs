using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 3f; 
    private Transform player; 
    private float chaseDuration = 10f; 
    private float chaseTimer; 

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        chaseTimer = chaseDuration; 
    }

    void Update()
    {
        
        if (player != null)
        {
            
            ChasePlayer();

           
            chaseTimer -= Time.deltaTime;

            
            if (chaseTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void ChasePlayer()
    {
        
        Vector3 direction = (player.position - transform.position).normalized;

        
        transform.position += direction * speed * Time.deltaTime;
    }
}