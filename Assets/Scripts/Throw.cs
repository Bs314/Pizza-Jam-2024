using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Throw : MonoBehaviour
{
    
    [SerializeField] GameObject bomerangPassive;
    [SerializeField] Slider bombomTimer;
    public GameObject levelUpScreen;
    
    public bool isReturned = true;
    public bool isItGone = false;
    void Start()
    {
        bombomTimer.value=bombomTimer.maxValue;
    }

   
    void Update()
    {

        if(Input.GetMouseButtonDown(0) && isReturned && !levelUpScreen.activeSelf)
        {
            bomerangPassive.transform.SetParent(null);
            CircleCollider2D bombomCollider = bomerangPassive.GetComponent<CircleCollider2D>();
            bombomCollider.enabled = true;
            FollowMouse fm = bomerangPassive.GetComponent<FollowMouse>();
            fm.enabled = true;
            isReturned = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("bombom"))
        {
            isItGone = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("bombom") && isItGone)
        {
            isItGone = false;
            isReturned = true;
            bombomTimer.value=bombomTimer.maxValue;
        }     
    }
}
