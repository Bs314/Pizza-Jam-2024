using UnityEngine;

public class BombomDamage : MonoBehaviour
{

    [SerializeField] float damagePoints = 10f;
    [SerializeField] ParticleSystem ps;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy"))
        {
            ps.Play();
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            enemyHealth.BomerangHits(damagePoints);        
        }
    }
}
