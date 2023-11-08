using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinball : MonoBehaviour
{
    
    public Quaternion initialAngular;   
    bool rotate = false;
    void Update()
    {

        //Input.mousePosition;
        
            
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.transform.Rotate(Vector3.forward * 3.0f);
        }
        

        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.transform.transform.rotation = initialAngular;
        }
    }

    void Start()
        {
            Debug.Log(this);
            initialAngular = this.transform.transform.rotation;
        }


}
