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
    public float kittenHeight; //Altura do kitten em relação ao chão

    public int wave = 1;
    public int maxEnemys = 10;

    #endregion

    #region Temporizador

    public float summonDelay;
    float time = 0;

    #endregion

    #region Spawn

    public float minSpawnDistance, maxSpawnDistance;
    public float smoothSpawn; //Ajuste para que o Spawn haja de maneira mais uniforme
    bool isSpawn = true;

    #endregion

    void Start()
    {
        pc = GetComponent<PlayerController>();
        pc.wave = wave;
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
        
        if(isSpawn)//maxenemy > kittenList.Count && 
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

    Vector3 GetSpawnPosition() //Função para definir a posição em que o inimigo irá dar Spawn
    {
        Vector3 spawnPos;
        float x, z;
        switch (wave)
        {
            case 1: /*
                    * Ângulo de visão: -45~45.
                    */
                x = Random.Range(-maxSpawnDistance, maxSpawnDistance);
                if(Mathf.Abs(x) > Mathf.Sqrt(2) * minSpawnDistance / 2) //Caso o valor de X esteja fora do ângulo de visão
                {
                    z = Random.Range(Mathf.Abs(x), maxSpawnDistance);
                }
                else
                {
                    z = Random.Range(Mathf.Sqrt(Mathf.Pow(minSpawnDistance, 2) - Mathf.Pow(x, 2)), maxSpawnDistance);
                }

                spawnPos = new Vector3(x, kittenHeight, z); 
                return spawnPos;
            case 2:/*
                    * Ângulo de visão: -90~90.
                    */
                x = Random.Range(-maxSpawnDistance, maxSpawnDistance) * smoothSpawn;
                if(Mathf.Abs(x) > maxSpawnDistance) //Ajuste para que tenha uma maior chance de Z tender a 0
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
            case 3:/*
                    * Ângulo de visão: -135~135.
                    */
                z = Random.Range(-maxSpawnDistance, maxSpawnDistance);
                if (z >= 0)
                {
                    z *= smoothSpawn;
                    if (Mathf.Abs(z) > maxSpawnDistance) //Ajuste para que tenha uma maior chance de X tender a 0
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
                    if (Mathf.Abs(z) > Mathf.Sqrt(2) * minSpawnDistance / 2) //Caso o valor de Z esteja dentro do ângulo de visão
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
            case 4:/*
                    * Ângulo de visão: 360.
                    */
                x = Random.Range(-maxSpawnDistance, maxSpawnDistance) * smoothSpawn; 
                if (Mathf.Abs(x) > maxSpawnDistance) //Ajuste para que tenha uma maior chance de Z tender a 0
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
            default:/*
                    * Ângulo base de visão: 360.
                    */
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
