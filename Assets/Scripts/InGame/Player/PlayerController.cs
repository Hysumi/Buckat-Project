using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    #region Controller

    MouseLook ms = new MouseLook();
    public float cameraDistance;
    public Vector3 projectileAdjust;

    #endregion

    GameObject bucket;
    public GameObject projectile;
    public int wave;

    void Update()
    {
        ms.MouseLookAt(this.gameObject, wave);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            bucket = (GameObject) Instantiate(projectile, Camera.main.transform.forward * cameraDistance + projectileAdjust, 
                new Quaternion(this.gameObject.transform.rotation.x, this.gameObject.transform.rotation.y, this.gameObject.transform.rotation.z, this.gameObject.transform.rotation.w));
        }
       
    }

}
