using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 mouseDelta;
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    { 
        mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Debug.Log(mouseDelta);
    }
}
