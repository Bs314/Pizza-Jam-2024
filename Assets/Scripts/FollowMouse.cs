using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    Rigidbody2D rb2;
    CircleCollider2D cc2;
    
    [SerializeField] float forceMagnitude = 10f;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        cc2 = GetComponent<CircleCollider2D>();
        
    }

    void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0; 

        Vector3 moveForce = mouseWorldPosition - transform.position;
        rb2.AddForce(moveForce * forceMagnitude);


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        cc2.isTrigger = false;
    }

}
