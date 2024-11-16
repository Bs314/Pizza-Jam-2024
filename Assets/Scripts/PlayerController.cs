using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
        
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(horizontal * moveSpeed, vertical * moveSpeed, 0);
        transform.Translate(moveVector * Time.deltaTime); 
    }

    
}
