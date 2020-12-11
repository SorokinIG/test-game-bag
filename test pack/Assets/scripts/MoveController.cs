using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    float distance = 9; 

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = UnityEngine.Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDrag();
        }
    }
}
