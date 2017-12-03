using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    #region Variáveis de Cenário

    bool start = false;
    public float rotationSpeedY;
    public Terrain terrain;
    public GameObject explosion;
    public GameObject sky;

    #endregion

    #region Variáveis do Kitten

    public float kittenSpeed;
    public float minDistance;
    public GameObject kitten;

    #endregion

    #region Variáveis do Bucket

    public float bucketSpeed;
    float rot_x, rot_y, rot_z;
    public GameObject bucket;

    #endregion

    #region Temporizador

    public float maxTime;
    float time = 0;

    #endregion

    #region Variáveis de Menu

    public Canvas menu;

    #endregion

    void Start()
    {
        terrain.enabled = false;
        sky.GetComponent<MeshRenderer>().enabled = false; 
        rot_x = Random.Range(-360, 360);
        rot_y = Random.Range(-360, 360);
        rot_z = Random.Range(-360, 360);
        menu.enabled = false;
    }
    void Update()
    {
        #region Scene

        if (start)
        {
            time += Time.deltaTime;
            transform.Rotate(0, rotationSpeedY * Time.deltaTime, 0);
            terrain.enabled = true;
            menu.enabled = true;
            sky.GetComponent<MeshRenderer>().enabled = true;
            Camera.main.clearFlags = CameraClearFlags.Skybox;
        }

        #endregion

        #region Kitten e Bucket 

        else
            start = MoveKittenAndBucket(kitten, bucket, kittenSpeed, bucketSpeed, rot_x, rot_y, rot_z);

        #endregion

    }

    private bool MoveKittenAndBucket(GameObject kitten, GameObject bucket, float speedKitten, float speedBucket, float bucketRotX, float bucketRotY, float bucketRotZ)
    {
        kitten.transform.LookAt(bucket.transform);
        kitten.transform.position += kitten.transform.forward * speedKitten * Time.deltaTime;
        
        bucket.transform.position += new Vector3(0, 0, speedBucket * Time.deltaTime);
        bucket.transform.Rotate(bucketRotX * Time.deltaTime, bucketRotY * Time.deltaTime, bucketRotZ * Time.deltaTime);

        if (Vector3.Distance(kitten.transform.position, bucket.transform.position) <= minDistance)
        {
            Instantiate(explosion, kitten.transform.position + new Vector3(0, 0.1f, minDistance), new Quaternion());
            kitten.transform.position = new Vector3(250, -10, 250);
            bucket.transform.position = new Vector3(250, -10, 250);
            time = 0;
            return true;
        }

        return false;
    }

    public void StartGame()
    {
        
    }
}
