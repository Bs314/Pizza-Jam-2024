using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameObject levelUpScreen;
    [SerializeField] Throw  throwBombom;
    int experience = 19;
    int lvlPoint = 0;
    public bool isScreenOpened = false;
    void Start()
    {
        lvlPoint = experience;
        levelUpScreen.SetActive(false);
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(horizontal * moveSpeed, vertical * moveSpeed, 0);
        transform.Translate(moveVector * Time.deltaTime); 
        score.text = experience.ToString();
        
        if(lvlPoint>=20 && !isScreenOpened && throwBombom.isReturned)
        {
            lvlPoint -= 20;
            isScreenOpened = true;
            levelUpScreen.SetActive(true);
            Time.timeScale = 0;
            
        }
    }

    public void IncereaseExp(int exp)
    {
        experience += exp;
        lvlPoint += exp;
        isScreenOpened = false;
    }

    


    
}
