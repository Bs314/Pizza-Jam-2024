using System;
using UnityEngine;
using UnityEngine.UI;

public class FollowMouse : MonoBehaviour
{

    Rigidbody2D rb2;
    [SerializeField] float maxTime = 5f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] float stopFactor = 3f;
    [SerializeField] float forceMagnitude = 10f;
    [SerializeField] GameObject levelUpScreen;
    Slider bombomTime;
    CircleCollider2D bombomcollider;

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
        if(forceMagnitude>0.1)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = 0;
            Vector3 moveForce = mouseWorldPosition - transform.position;
            rb2.AddForce(moveForce * forceMagnitude);
            transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
        }
        else
        {
            transform.Rotate(0,0,0);
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
                CircleCollider2D bombomcollider = GetComponent<CircleCollider2D>();
                bombomcollider.enabled = false;
                transform.eulerAngles = Vector3.zero;
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

    public void IncreaseMaxTime()
    {
        maxTime += 1;
        bombomTime.maxValue = maxTime;
        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

}
