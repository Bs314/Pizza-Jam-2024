using Unity.Mathematics;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   
    [SerializeField] float hitPoints = 10f;
    [SerializeField] float hitDuration = 1f;
    [SerializeField] GameObject exp;
    bool isHitted = false;
    float hitDurationSave;
    private void Start() {
        hitDurationSave = hitDuration;
    }

    private void Update() {
        if(isHitted)
        {
            hitDuration -= Time.deltaTime;
            if(hitDuration<=0)
            {
                isHitted = false;
                hitDuration = hitDurationSave;
            }    
        }
    }
    public void BomerangHits(float damagePoints)
    {
        if(!isHitted)
        {
            hitPoints -= damagePoints;
            if(hitPoints<=0)
            {
                Instantiate(exp,transform.position,quaternion.identity);
                Destroy(gameObject);
            }
            
            else
            {
                isHitted = true;
            }
        }
    }
}
