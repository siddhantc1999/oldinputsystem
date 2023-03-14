using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    Vector3 randomposition;

    bool delaystart = true;
    Vector2 enemypos;
    public GameObject enemyobject;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (delaystart)
        {
            delaystart = false;
            StartCoroutine(instantiateenemies());
            
        }
    }

    IEnumerator instantiateenemies()
    {
        for(int i=0;i<5;i++)
        {
            Vector3 randomviewpoint = new Vector2(UnityEngine.Random.Range(-0.0001f,1.0001f), UnityEngine.Random.Range(-0.0001f, 1.0001f));
            Vector3 screenpoint = Camera.main.ViewportToWorldPoint(new Vector3(randomviewpoint.x, randomviewpoint.y,10f));
            GameObject newenemyobject = Instantiate(enemyobject,screenpoint,Quaternion.identity);
            newenemyobject.transform.parent = parent.transform; 
}
        yield return new WaitForSeconds(UnityEngine.Random.Range(5f, 6f));
        
        delaystart = true;
    }
}
