using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D " + col.collider.tag);
        if (col.gameObject.CompareTag("Avatar"))
        {
            Debug.Log("AAA ");
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        //     this.destroyCancellationToken();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
