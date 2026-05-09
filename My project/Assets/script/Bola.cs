using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Bola : MonoBehaviour
{

    private Rigidbody2D rb;
    private float Speed = 8f;
    private float maxSpeed = 20f;
    private float increaseSpeed = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float x = Random.value > 0.5f ? -1 : 1;
        float y = Random.Range(0.5f, 05f);

        rb.linearVelocity = new Vector2(x, y).normalized * Speed;
    }


    private void FixedUpdate()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Speed += increaseSpeed;
            if (Speed > maxSpeed)
            {
                Speed = maxSpeed;
            }

            float impactoY = transform.position.y - collision.transform.position.y;
            float directionX = collision.gameObject.CompareTag("Player") ? 1 : 1;
            Vector2 direction = new Vector2(directionX, impactoY).normalized;
            rb.linearVelocity = direction * Speed;

        }

        
    }
}
