using UnityEngine;
using UnityEngine.UI;

public class FollowMouse : MonoBehaviour
{

    Rigidbody2D rb2;
    [SerializeField] float maxTime = 5f;
    [SerializeField] float stopFactor = 3f;
    [SerializeField] float forceMagnitude = 10f;
    Slider bombomTime;
    

    float recordForce;
    float firstForceMagnitude;
    float timeLeft;
    void Start()
    {
        bombomTime = FindFirstObjectByType<Slider>();
        recordForce = forceMagnitude;
        rb2 = GetComponent<Rigidbody2D>();
        bombomTime.maxValue = maxTime;
        bombomTime.value = maxTime;
        timeLeft = maxTime;
        firstForceMagnitude = forceMagnitude;
    }

    void Update()
    {
        MoveBombom();
        UpdateSlider();
    }

   

    private void UpdateSlider()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            forceMagnitude -= stopFactor * Time.deltaTime;
        }
        bombomTime.value = timeLeft;
    }

    private void MoveBombom()
    {
        if(forceMagnitude>0)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = 0;
            Vector3 moveForce = mouseWorldPosition - transform.position;
            rb2.AddForce(moveForce * forceMagnitude);
        }
        else
        {
            rb2.linearVelocity = Vector3.zero;
            forceMagnitude = 0;
        }
        
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("Player"))
        {
            
            Throw th = other.GetComponent<Throw>();
            if(th.isItGone)
            {
                
                FollowMouse followMouse = GetComponent<FollowMouse>();
                followMouse.enabled = false;
                rb2.linearVelocity = Vector2.zero;
                transform.SetParent(other.transform);
                transform.localPosition = Vector3.zero;
                timeLeft = maxTime;
                forceMagnitude = firstForceMagnitude;
            }
 
        }
    }

}
