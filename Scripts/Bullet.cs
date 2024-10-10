using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                Destroy(collision.gameObject);
                FindObjectOfType<PlayerController>().IncrementScore();
            }
            Destroy(gameObject);
        }
    }
}
