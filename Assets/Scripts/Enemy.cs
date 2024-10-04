using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Настройки врага")]
    [Space(10)]
    [Tooltip("Скорость передвижения")]
    [Range(0,10)]
    [SerializeField] private float moveSpeed = 3f;
    [Space(3)]
    [Tooltip("Точка куда переместиться игрок после соприкосновении с врагом")]
    [SerializeField] private Transform playerRespawnPosition; 

    private Rigidbody2D rb;
    private bool movingRight = true; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);  
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            movingRight = !movingRight;  
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = playerRespawnPosition.position;
        }
    }
}