using UnityEngine;
using System.Collections;

public class RotateBucket : MonoBehaviour {

    float rot_x, rot_y, rot_z; //Rotação do balde

    void Start () {
        rot_x = Random.Range(-360, 360);
        rot_y = Random.Range(-360, 360);
        rot_z = Random.Range(-360, 360);
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            gameObject.transform.Rotate(rot_x * Time.deltaTime, rot_y * Time.deltaTime, rot_z * Time.deltaTime); //Rotaciona o Balde
            yield return null;
        }
    }


}
