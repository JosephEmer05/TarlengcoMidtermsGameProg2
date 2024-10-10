using UnityEngine;
using System.Collections.Generic;

public class DetectionRadiusTrigger : MonoBehaviour
{
    private PlayerController playerController;
    private HashSet<GameObject> enemiesInRange = new HashSet<GameObject>();

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        if (enemiesInRange.Count > 0)
        {
            playerController.ShootBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemiesInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(collision.gameObject);
        }
    }
}
