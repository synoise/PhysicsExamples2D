// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//     // ventSystems;
// public class main_pinball : MonoBehaviour
// {
//     public GameObject rotatedObject; 
//     public double rotationSpeed = 1;
//     public double maxAngular = 0.9;  
//     public Quaternion initialAngular;   
//     bool rotate = false;
//     // public Vector3 rotationSpeed1 = new Vector3(0, 0, 0);
//  
//     void Update() 
//     {
//         // Debug.Log( rotatedObject.transform.rotation.z + " _ _ "+maxAngular +" _ "+initialAngular);
//         // if (Input.GetKey(KeyCode.Space) &&  rotatedObject.transform.rotation.z <  maxAngular)
//         if (Input.GetKey(KeyCode.Space) )
//         {  
//             Debug.Log("space key was pressed "+ rotatedObject.transform.rotation.z +" _ /"+ (initialAngular.z+0.2) +"///"+ (rotatedObject.transform.rotation.z < (initialAngular.z+0.2) ));
//             rotatedObject.transform.Rotate(Vector3.forward * 3.0f );
//             // rotatedObject.transform.Rotate();
//         }
//         else
//         {
//             rotatedObject.transform.rotation = initialAngular;
//         }
//
//         if (Input.GetKeyUp(KeyCode.Space))
//         {
//             Debug.Log("space key was UPUP" + initialAngular);
//             rotatedObject.transform.rotation = initialAngular;
//             // rotatedObject.transform.rotation.eulerAngles.z = 0.0f
//         }
//         
//         void Start()
//         {
//             // rotatedObject = this.gameObject;
//             initialAngular = rotatedObject.transform.rotation;
//         }
//
//         // rotationSpeed += 0.000001f;
//         // rotatedObject.transform.Rotate(0 ,0,rotationSpeed);
//         // rotatedObject.transform.Rotate(Vector3.forward * 10 * Time.deltaTime);
//         // Debug.Log( rotatedObject.transform.rotation.z + " _ " +rotatedObject.transform.rotation.y+ " _ " + rotatedObject.transform.rotation);
//
//     }
//     
//     // Start is called before the first frame update
//
//
//     // Update is called once per frame
//     void FixedUpdate()
//     {
//         
//     }
// }
