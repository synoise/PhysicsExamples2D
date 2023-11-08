using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvetsShowcas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");  
    }

    void FixedUpdate()
    {
        Debug.Log("FixedUpdate");  
    }

    void OnDestroy()    {
        Debug.Log("OnDestroy");  
    }
    void OnGUI()    {
        Debug.Log("OnGUI");  
    }
    void UIEvents()    {
        Debug.Log("UIEvents");  
    }
}
