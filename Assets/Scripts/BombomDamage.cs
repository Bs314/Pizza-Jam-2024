using UnityEngine;

public class BombomDamage : MonoBehaviour
{

    [SerializeField] float damagePoints = 10f;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy"))
        {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        enemyHealth.BomerangHits(damagePoints);        
        }
    }
}
