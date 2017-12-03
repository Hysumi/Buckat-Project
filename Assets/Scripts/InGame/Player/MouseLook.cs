using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

    #region First Person Variables
    
    float sensitivityX = 15F;
    float sensitivityY = 15F;

	float minimumX = -45F;
	float maximumX = 45F;

	float minimumY = 0F;
	float maximumY = 60F;

	float rotationY = 0F;
    float rotationX = 0F;
    
    #endregion

    public static Vector3 playerRotation;

	public void MouseLookAt(GameObject mc, int wave)
	{
        if (mc.GetComponent<Rigidbody>())
            mc.GetComponent<Rigidbody>().freezeRotation = true;

        if(wave < 4)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = Mathf.Clamp(rotationX, minimumX * wave, maximumX * wave);
        }
        else
        {
            rotationX = mc.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX; //Pega o ângulo atual y + a rotação de X
            rotationX = Mathf.Clamp(rotationX, -360, 360);
        }

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        mc.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
       
        playerRotation = new Vector3(rotationX, rotationY);
	}
	
}