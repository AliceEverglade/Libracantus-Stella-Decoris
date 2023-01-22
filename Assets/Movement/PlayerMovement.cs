using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cam;

    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private Vector3 move;
    [SerializeField] private float turnSmoothVelocity;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private Vector3 playerMovementVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = new Vector3(GetInput().x, 0f, GetInput().y).normalized;

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            playerMovementVector = moveDir * movementSpeed;
        }
        if (direction.magnitude < 0.1f)
        {
            playerMovementVector = new Vector3(0f, 0f, 0f);
        }

        rb.velocity = playerMovementVector;
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
