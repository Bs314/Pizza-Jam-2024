using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   
    [SerializeField] float hitPoints = 10f;

    public void BomerangHits(float damagePoints)
    {
        hitPoints -= damagePoints;
        if(hitPoints<=0)
        {Destroy(gameObject);}

    }

    


}
