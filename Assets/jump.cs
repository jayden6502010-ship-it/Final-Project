using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class VRJump : MonoBehaviour
{
    [Header("Input Action")]
    [SerializeField] private InputActionReference jumpActionReference;

    [Header("Jump Settings")]
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -9.81f;

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        // Subscribe to the jump button press event
        if (jumpActionReference != null)
        {
            jumpActionReference.action.Enable();
            jumpActionReference.action.performed += OnJump;
        }
    }

    private void OnDisable()
    {
        // Unsubscribe to clean up memory
        if (jumpActionReference != null)
        {
            jumpActionReference.action.performed -= OnJump;
        }
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;

        // Reset downward velocity when touching the ground
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -0.5f; // Small offset keeps the player snapped to the ground
        }

        // Apply gravity continuously
        playerVelocity.y += gravity * Time.deltaTime;

        // Move the CharacterController based on gravity/jump velocity
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        // Only allow jumping if the VR player is grounded
        if (!isGrounded) return;

        // Formula to calculate exact force needed for target jump height: sqrt(height * -2 * gravity)
        playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}

