using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour
{
    float randomRange = 2, newRange;
    int x, y, z;
    bool changed = false;

    #region Temporizador

    float maxTime = 10;
    float time = 0;

    #endregion

    public void CloudsRotation(GameObject sky)
    {
        time += Time.deltaTime;
        if (time > maxTime)
        {
            time = 0;
            changed = true;
        }

        if(changed)
        {
            time = 0;
            if (newRange > 0)
                newRange -= Time.deltaTime;
            else
            {
                changed = false;
                newRange = 0;
                randomRange = Random.Range(0.5f, 10f);
                x = Random.Range(0, 2);
                y = Random.Range(0, 2);
                z = Random.Range(0, 2);
            }
        }
        else
        {
            if (newRange < randomRange)
                newRange += Time.deltaTime;
        }

        sky.transform.Rotate(x*Time.deltaTime*newRange, y*Time.deltaTime*newRange, z*Time.deltaTime*newRange);
    }
}
