using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBucket : MonoBehaviour {

    Vector3 movement, initialPos;
    public float speed = 2; //Velocidade do movimento do balde
    public bool explode = false;

    void Start ()
    {
        initialPos = this.gameObject.transform.position;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while(!explode)
        {
            transform.position += transform.forward * speed *Time.deltaTime;
            if (Vector3.Distance(transform.position, initialPos) > 200) 
            {
               // Destroy(this.gameObject);
                explode = true;
            }
            yield return null;
        }
    }

}
