using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.contacts[0].normal.y < -0.5f)
            {
                Stomped();
            }
            else
            {
                LevelManager levelManager = Object.FindFirstObjectByType<LevelManager>();
                if (levelManager != null) {
                    levelManager.RestartLevel();
                }
            }
        }
    }

    void Stomped()
    {
        Destroy(gameObject);
    }
}
