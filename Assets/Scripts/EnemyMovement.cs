using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float followSpeed = 3f;  
    PlayerController pController;
    Vector3 moveDirection;
    void Start()
    {
        pController = FindAnyObjectByType<PlayerController>(); 
    }

 
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        moveDirection = pController.transform.position - transform.position;
        moveDirection = moveDirection.normalized;
        transform.Translate(moveDirection * followSpeed * Time.deltaTime);
    }
}
