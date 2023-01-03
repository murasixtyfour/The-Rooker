using UnityEngine;

public class LightLerp : MonoBehaviour
{
    [HideInInspector] public Quaternion initRotation;
    [HideInInspector] public Quaternion targetRotation; 

    void Awake ()
    {
        initRotation = transform.rotation;
        targetRotation = initRotation;
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.01f);
    }
}
