using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private Transform player;
    private float speed;

    public void Initialize(Transform targetPlayer, float moveSpeed)
    {
        player = targetPlayer;
        speed = moveSpeed;
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
