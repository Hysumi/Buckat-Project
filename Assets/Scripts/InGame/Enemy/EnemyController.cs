using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    #region Player variables

    public int score = 0;
    PlayerController pc;

    #endregion

    #region Enemy variables 

    public GameObject kitten;
    public List<GameObject> kittenList;
    public float kittenHeight;

    public int wave = 1, actualWaveCap = 6;
    public int maxEnemys = 20;
    public int actualEnemysLenght;

    #endregion

    #region Temporizador

    public float summonDelay;
    float time = 0;

    #endregion

    #region Spawn


    public float minSpawnDistance, maxSpawnDistance;
    public float smoothSpawn;
    bool isSpawn = true;

    #endregion

    void Start()
    {
        pc = GetComponent<PlayerController>();
        pc.wave = wave;
        actualEnemysLenght = Mathf.RoundToInt(actualWaveCap * Mathf.Log(actualWaveCap, maxEnemys));
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > summonDelay)
        {
            time = 0;
            isSpawn = true;
        }

        if (Input.GetKeyDown(KeyCode.A)) //DEFINIR QUANDO UMA WAVE MUDA
        {
            //print(actualWaveCap * Mathf.Log(actualWaveCap, maxEnemys));
            wave++;
            pc.wave = wave;
        }
        
        if(isSpawn)//actualEnemysLenght > kittenList.Count && 
        {
            SummonKitten();
            isSpawn = false;
        }
    }

    void SummonKitten()
    {
        Vector3 enemyPos = GetSpawnPosition();
        GameObject k = (GameObject)Instantiate(kitten, enemyPos, new Quaternion());
        kittenList.Add(k);
    }

    Vector3 GetSpawnPosition()
    {
        Vector3 spawnPos;
        float x, z;
        switch (wave)
        {
            case 1:
                x = Random.Range(-maxSpawnDistance, maxSpawnDistance);
                if(Mathf.Abs(x) > Mathf.Sqrt(2) * minSpawnDistance / 2)
                {
                    z = Random.Range(Mathf.Abs(x), maxSpawnDistance);
                }
                else
                {
                    z = Random.Range(Mathf.Sqrt(Mathf.Pow(minSpawnDistance, 2) - Mathf.Pow(x, 2)), maxSpawnDistance);
                }
                spawnPos = new Vector3(x, kittenHeight, z); 
                return spawnPos;
            case 2:
                x = Random.Range(-maxSpawnDistance, maxSpawnDistance) * smoothSpawn;
                if(Mathf.Abs(x) > maxSpawnDistance)
                {
                    x = Mathf.Sign(x) * (maxSpawnDistance - Random.Range(0, maxSpawnDistance-minSpawnDistance));
                    z = Random.Range(Mathf.Sqrt(Mathf.Pow(maxSpawnDistance, 2) - Mathf.Pow(x, 2)), maxSpawnDistance) / smoothSpawn;
                }
                else if (Mathf.Abs(x) > minSpawnDistance)
                {
                    z = Random.Range(Mathf.Sqrt(Mathf.Pow(maxSpawnDistance, 2) - Mathf.Pow(x, 2)), maxSpawnDistance);
                }
                else
                {
                    z = Random.Range(Mathf.Sqrt(Mathf.Pow(minSpawnDistance, 2) - Mathf.Pow(x, 2)), maxSpawnDistance);
                }
                spawnPos = new Vector3(x, kittenHeight, z);
                return spawnPos;
            case 3:
                z = Random.Range(-maxSpawnDistance, maxSpawnDistance);
                if (z >= 0)
                {
                    z *= smoothSpawn;
                    if (Mathf.Abs(z) > maxSpawnDistance)
                    {
                        z = Mathf.Sign(z) * (maxSpawnDistance - Random.Range(0, maxSpawnDistance - minSpawnDistance));
                        x = Mathf.Sign(Random.Range(-1, 1)) * Random.Range(Mathf.Sqrt(Mathf.Pow(maxSpawnDistance, 2) -
                            Mathf.Pow(z, 2)), maxSpawnDistance) / smoothSpawn;
                    }
                    else if (Mathf.Abs(z) > minSpawnDistance)
                    {
                        x = Mathf.Sign(Random.Range(-1, 1)) * Random.Range(Mathf.Sqrt(Mathf.Pow(maxSpawnDistance, 2) -
                            Mathf.Pow(z, 2)), maxSpawnDistance);
                    }
                    else
                    {
                        x = Mathf.Sign(Random.Range(-1, 1)) * Random.Range(Mathf.Sqrt(Mathf.Pow(minSpawnDistance, 2) -
                            Mathf.Pow(z, 2)), maxSpawnDistance);
                    }
                    spawnPos = new Vector3(x, kittenHeight, z);
                    return spawnPos;
                }
                else
                {
                    if (Mathf.Abs(z) > Mathf.Sqrt(2) * minSpawnDistance / 2)
                    {
                        x = Mathf.Sign(Random.Range(-1, 1)) * Random.Range(Mathf.Abs(z), maxSpawnDistance);
                    }

                    else
                    {
                        x = Mathf.Sign(Random.Range(-1, 1)) * Random.Range(Mathf.Sqrt(Mathf.Pow(minSpawnDistance, 2) - 
                                Mathf.Pow(z, 2)), maxSpawnDistance);
                    }
                }
                spawnPos = new Vector3(x, kittenHeight, z);
                return spawnPos;
            case 4:
                x = Random.Range(-maxSpawnDistance, maxSpawnDistance) * smoothSpawn;
                if (Mathf.Abs(x) > maxSpawnDistance)
                {
                    x = Mathf.Sign(x) * (maxSpawnDistance - Random.Range(0, maxSpawnDistance - minSpawnDistance));
                    z = Random.Range(Mathf.Sqrt(Mathf.Pow(maxSpawnDistance, 2) - Mathf.Pow(x, 2)), maxSpawnDistance) / smoothSpawn;
                }
                else if (Mathf.Abs(x) > minSpawnDistance)
                {
                    z = Mathf.Sign(Random.Range(-1, 1)) * Random.Range(Mathf.Sqrt(Mathf.Pow(maxSpawnDistance, 2) - Mathf.Pow(x, 2)) - 1, maxSpawnDistance);
                }
                else
                {
                    z = Mathf.Sign(Random.Range(-1, 1)) * Random.Range(Mathf.Sqrt(Mathf.Pow(minSpawnDistance, 2) - Mathf.Pow(x, 2)) - 1, maxSpawnDistance);
                }
                spawnPos = new Vector3(x, kittenHeight, z);
                return spawnPos;
            default:
                x = Random.Range(-maxSpawnDistance, maxSpawnDistance) * smoothSpawn;
                if (Mathf.Abs(x) > maxSpawnDistance)
                {
                    x = Mathf.Sign(x) * (maxSpawnDistance - Random.Range(0, maxSpawnDistance - minSpawnDistance));
                    z = Random.Range(Mathf.Sqrt(Mathf.Pow(maxSpawnDistance, 2) - Mathf.Pow(x, 2)), maxSpawnDistance) / smoothSpawn;
                }
                else if (Mathf.Abs(x) > minSpawnDistance)
                {
                    z = Mathf.Sign(Random.Range(-1, 1)) * Random.Range(Mathf.Sqrt(Mathf.Pow(maxSpawnDistance, 2) - Mathf.Pow(x, 2)) - 1, maxSpawnDistance);
                }
                else
                {
                    z = Mathf.Sign(Random.Range(-1, 1)) * Random.Range(Mathf.Sqrt(Mathf.Pow(minSpawnDistance, 2) - Mathf.Pow(x, 2)) - 1, maxSpawnDistance);
                }
                spawnPos = new Vector3(x, kittenHeight, z);
                return spawnPos;
        }
    }
}
