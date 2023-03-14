using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, Random.Range(3f, 5f));
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.name== "bullet(Clone)")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }
   

}
