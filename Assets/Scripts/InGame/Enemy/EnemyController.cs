using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    #region Player variables

    public int wave = 1;
    public int score = 0;
    PlayerController pc;

    #endregion

    #region Enemy variables 

    public GameObject kitten;
    public List<GameObject> kittenList;
    public float kittenHeight;

    public int maxEnemys = 20, actualWaveCap = 6;
    public int actualEnemysLenght;

    public float spawnDistance;
    bool isSpawn = true;

    #endregion

    #region Temporizador

    public float summonDelay = 1;
    float time = 0;

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
            print(actualWaveCap * Mathf.Log(actualWaveCap, maxEnemys));
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
        Vector3 spawnPos = new Vector3(999,999);

        switch (wave)
        {
            case 1:
                float x1 = Random.Range(-spawnDistance, spawnDistance);
                print("x1: " + x1);
                float z1 = Random.Range(Mathf.Sqrt(Mathf.Pow(spawnDistance, 2) - Mathf.Pow(x1 / 5,2)), 150);
                print("z1: " + z1);
                spawnPos = new Vector3(x1, kittenHeight, z1);
                return spawnPos;
            case 2:
                float x2 = Random.Range(-250, 250);
                float z2 = Random.Range(0, 250);
                spawnPos = new Vector3(x2, kittenHeight, z2);
                return spawnPos;
            case 3:
                float x3 = Random.Range(-250, 250);
                float z3 = Random.Range(- (Mathf.Abs(x3) - 1), 250);
                spawnPos = new Vector3(x3, kittenHeight, z3);
                return spawnPos;
            case 4:
                float x4 = Random.Range(-250, 250);
                float z4 = Random.Range(250, 250);
                spawnPos = new Vector3(x4, kittenHeight, z4);
                return spawnPos;
        }

        return spawnPos;

    }
}
