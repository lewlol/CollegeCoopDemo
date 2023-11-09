using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    Camera cam;

    Vector2 movementInput;
    Vector2 rotate;

    public float runSpeed;
    public float rotateSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        float horizontal = movementInput.x;
        float vertical = movementInput.y;

        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        Vector3 finalMovement = transform.position + movement * runSpeed * Time.deltaTime;
        transform.position = finalMovement;

        if(rotate != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(rotate.x, rotate.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, -targetAngle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnRotate(InputAction.CallbackContext ctx) => rotate = ctx.ReadValue<Vector2>();

    private void OnEnable()
    {
        
    }
}
