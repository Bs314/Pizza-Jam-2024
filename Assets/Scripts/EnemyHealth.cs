using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   
    [SerializeField] float hitPoints = 10f;
    [SerializeField] float hitDuration = 1f;
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
            {Destroy(gameObject);}
            else
            {
                isHitted = true;
            }
        }
    }
}
