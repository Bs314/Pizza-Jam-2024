using UnityEngine;

public class MouseIcon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;   
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = 0;    
            transform.position = mouseWorldPosition;
    }
}
