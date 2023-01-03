using UnityEngine;

public class SolarTrigger : MonoBehaviour
{
    public LightLerp ll;
    public Quaternion rotation;

    bool isActivated;
    AudioSource asrc;

    void Awake()
    {
        asrc = GetComponent<AudioSource>();             
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item") && !isActivated)
        {
            isActivated = true;
            ll.targetRotation = rotation;

            asrc.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item") && isActivated)
        {
            isActivated = false;
            ll.targetRotation = ll.initRotation;
        }
    }
}
