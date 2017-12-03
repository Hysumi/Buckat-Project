using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenNPC : MonoBehaviour {

    public Transform player;
    public float speed;
    public float minDistance;
    public GameObject explosion;
    public bool explode = false;

    private void Start()
    {
        StartCoroutine(MoveKitten());
    }

    IEnumerator MoveKitten()
    {
        while (!explode)
        {
            transform.LookAt(player);
            transform.position += transform.forward * speed * Time.deltaTime;


            if (Vector3.Distance(transform.position, player.position) <= minDistance)
            {
                //Acaba o Jogo
            }
            yield return null;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().tag == "Bucket")
        {
            explode = true;
            Instantiate(explosion, new Vector3(this.gameObject.transform.position.x, -10, this.gameObject.transform.position.z), new Quaternion());

            //transform.position = initialPos;
            //Player.score += 3;
            //speed += 0.5f;
        }
    }
}
