using System;
using TMPro;
using UnityEngine;

public class ExpMovement : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int exp;
    
    PlayerController playerController;
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();  
    }

    
    void Update()
    {
        Vector3 moveDirection = playerController.transform.position - transform.position;
        moveDirection = moveDirection.normalized;
        transform.Translate(moveDirection*moveSpeed*Time.deltaTime);    
        
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            playerController.IncereaseExp(exp);
            Destroy(gameObject);
        }
    }

}
