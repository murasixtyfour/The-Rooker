using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask groundMask;
    public Transform groundCheck;

    public AudioClip jumpClip;

    [HideInInspector] public bool isGrounded;

    Rigidbody rb;
    Vector3 moveDirection;
    float moveSpeed = 30f;
    float jumpForce = 9.81f;

    AudioSource asrc;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        asrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = transform.forward * vertical + transform.right * horizontal;

        isGrounded = Physics.CheckBox(groundCheck.position, new Vector3(0.45f, 0.05f, 0.45f), transform.rotation, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            asrc.PlayOneShot(jumpClip);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }
}
