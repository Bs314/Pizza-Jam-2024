using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Throw : MonoBehaviour
{
    
    [SerializeField] GameObject bomerangPassive;
    [SerializeField] GameObject bomerangActive;

    bool isReturned = true;
    void Start()
    {
        
    }

   
    void Update()
    {

        if(Input.GetMouseButtonDown(0) && isReturned)
        {
            isReturned = false;
            bomerangPassive.SetActive(false);

            Instantiate(bomerangActive, transform.position, quaternion.identity);

        }

    }


    

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("bombom"))
        {
            Destroy(other.gameObject);
            isReturned = true;
            bomerangPassive.SetActive(true);

        }       
    }
}
