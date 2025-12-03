using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementSmooth : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 120f;
    public bool floating = true;
    public float fixedHeight = 1.5f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Vertical");
        float turnInput = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(turnInput) > 0.1f)
        {
            float yRot = turnInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, yRot, 0);
        }

        if (Mathf.Abs(moveInput) > 0.1f)
        {
            Vector3 moveDir = transform.forward * moveInput;
            controller.Move(moveDir * moveSpeed * Time.deltaTime);
        }

        if (floating)
        {
            Vector3 pos = transform.position;
            pos.y = fixedHeight;
            transform.position = pos;
        }
    }
}
