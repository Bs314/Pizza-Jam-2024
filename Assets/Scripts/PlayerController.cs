using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] TextMeshProUGUI score;
    int experience = 0;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(horizontal * moveSpeed, vertical * moveSpeed, 0);
        transform.Translate(moveVector * Time.deltaTime); 
        score.text = experience.ToString();
    }

    public void IncereaseExp(int exp)
    {
        experience += exp;
    }


    
}
