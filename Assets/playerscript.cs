using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public Vector3 worldposition;
    Vector3 screenposition;
    Vector3 normalizedpos;
    public GameObject bulletinstantiatepos;
    public GameObject bullet;
    public GameObject bulletparent;
    Ray ray;
    bool ishit;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


        //Debug.Log("the mouseposition"+Input.mousePosition);
        if (Input.GetMouseButton(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit myraycasthit;
            
            if (Physics.Raycast(ray, out myraycasthit, 100f))
            {
                //Debug.Log(myraycasthit.transform.name);
                if (myraycasthit.collider.gameObject.tag == "battlefield")
                {
                  
                    
                    screenposition = Input.mousePosition;
                    worldposition = Camera.main.ScreenToWorldPoint(new Vector3(screenposition.x, screenposition.y, -10f));

                    normalizedpos = worldposition.normalized;
                    normalizedpos = new Vector3(normalizedpos.x, normalizedpos.y, 0f);
                    transform.up = -normalizedpos;
                }
            }
            //else
            //{
            //    Debug.Log("not battlefied");
            //}
        }
        if(Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        {
            transform.position += (transform.up*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position -= (transform.up * Time.deltaTime);
        }
        //if(Input.GetMouseButtonDown(0))
        //{
        //    GameObject instantiatedbullet = Instantiate(bullet,bulletinstantiatepos.transform.position,Quaternion.identity);
        //    bulletparent.transform.parent = bulletparent.transform;
        //   Rigidbody2D bulletrigidbody;
        //    bulletrigidbody = instantiatedbullet.GetComponent<Rigidbody2D>();
        //    bulletrigidbody.velocity = transform.up*2f;
        //    bulletrigidbody.transform.up = bulletrigidbody.velocity.normalized;
           
        //}

        //if(Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        //{

        //}


    }
    public void firebullet()
    {
        GameObject instantiatedbullet = Instantiate(bullet, bulletinstantiatepos.transform.position, Quaternion.identity);
        bulletparent.transform.parent = bulletparent.transform;
        Rigidbody2D bulletrigidbody;
        bulletrigidbody = instantiatedbullet.GetComponent<Rigidbody2D>();
        bulletrigidbody.velocity = transform.up * 2f;
        bulletrigidbody.transform.up = bulletrigidbody.velocity.normalized;
    }
}
