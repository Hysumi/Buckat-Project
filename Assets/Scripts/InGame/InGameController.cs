using UnityEngine;
using System.Collections;

public class InGameController : MonoBehaviour {

    #region Sky

    public GameObject sky;
    Clouds clouds = new Clouds();

    #endregion

    #region Controller

    MouseLook ms = new MouseLook();
    public float cameraDistance;
    public Vector3 projectileAdjust;

    #endregion

    GameObject bucket;
    public GameObject projectile;

    void Update()
    {
        clouds.CloudsRotation(sky);
        ms.MouseLookAt(this.gameObject);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            bucket = (GameObject) Instantiate(projectile, Camera.main.transform.forward * cameraDistance + projectileAdjust, 
                new Quaternion(this.gameObject.transform.rotation.x, this.gameObject.transform.rotation.y, this.gameObject.transform.rotation.z, this.gameObject.transform.rotation.w));
        }
       
    }

}
