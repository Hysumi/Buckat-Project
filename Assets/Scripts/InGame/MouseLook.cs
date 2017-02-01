using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

    #region First Person Variables
    
    public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = 0F;
	public float maximumY = 60F;

	float rotationY = 0F;
    float rotationX = 0F;
    
    #endregion

    public static Vector3 playerRotation;

	public void MouseLookAt(GameObject mc)
	{
        if (mc.GetComponent<Rigidbody>())
            mc.GetComponent<Rigidbody>().freezeRotation = true;

        rotationX = mc.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX; //Pega o ângulo atual y + a rotação de X

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        mc.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
       
        playerRotation = new Vector3(rotationX, rotationY);
	}
	
}