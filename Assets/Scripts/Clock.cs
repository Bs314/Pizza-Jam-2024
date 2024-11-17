using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    

    float clockTime;
    [SerializeField] TextMeshProUGUI clock;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clockTime += Time.deltaTime;   
        float minutes = Mathf.FloorToInt(clockTime / 60);
        float seconds = Mathf.FloorToInt(clockTime % 60);

        clock.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
}
