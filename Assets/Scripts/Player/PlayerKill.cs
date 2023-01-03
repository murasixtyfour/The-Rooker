using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    public SceneControl sc;
    public Transform chamberLight;

    public LayerMask opaqueMask;
    public Transform opaqueCheck;

    public AudioClip deathClip;

    PlayerMovement pm;
    AudioSource asrc;

    void Awake()
    {
        pm = GetComponent<PlayerMovement>();
        asrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!Physics.Raycast(opaqueCheck.position, -chamberLight.forward, Mathf.Infinity, opaqueMask) && pm.isGrounded)
        {
            Kill();
        }
    }

    public void Kill()
    {
        asrc.PlayOneShot(deathClip);
        StartCoroutine(sc.Fade(SceneControl.FadeDirection.In, 1f, sc.buildIndex));
    }
}
