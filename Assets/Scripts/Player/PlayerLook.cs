using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform cam;

    float rotationX;
    float rotationY;

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        rotationX -= mouseY * GameControl.data.options[1] / 50f;
        rotationY += mouseX * GameControl.data.options[1] / 50f;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        cam.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.rotation = Quaternion.Euler(0, rotationY, 0);  
    }
}
