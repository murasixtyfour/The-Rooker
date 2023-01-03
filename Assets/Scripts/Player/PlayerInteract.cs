using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask itemMask;
    public Transform itemCheck;

    PlayerLook pl;

    Rigidbody rb;
    Vector3 moveDirection;
    float moveSpeed = 30f;

    void Awake()
    {
        pl = GetComponent<PlayerLook>();
    }

    void Update()
    {
        if (rb != null)
        {
            moveDirection = itemCheck.position - rb.transform.position;
            if (Input.GetButtonUp("Fire1")) rb = null;
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit hit;
                if (Physics.Linecast(pl.cam.position, itemCheck.position, out hit, itemMask))
                {
                    Transform transform = hit.transform;
                    if (transform.CompareTag("Item")) rb = transform.GetComponent<Rigidbody>();
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (rb != null) rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }
}
