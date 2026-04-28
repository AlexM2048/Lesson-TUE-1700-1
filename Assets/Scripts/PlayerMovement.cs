using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");

    [Header("Move")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float gravityForce = 9.81f;

    [Header("Look")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float mouseSensivity = 2f;
    [SerializeField] private float lookLimit = 90f;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private float xRotation = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction = transform.rotation * direction;

        animator.SetBool(IsRunning, direction != Vector3.zero);

        characterController.Move(direction * speed * Time.deltaTime);

        if (characterController.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                characterController.Move(Vector3.up * jumpForce);
            }
        }
        else
        {
            characterController.Move(Vector3.down * gravityForce * Time.deltaTime);
        }
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -lookLimit, lookLimit);

        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent(out PickUp pickUp))
        {
            print($"{pickUp.name} подобран игроком!");
            Destroy(pickUp.gameObject);
        }
    }
}
