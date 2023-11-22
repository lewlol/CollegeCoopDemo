using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerRotation : MonoBehaviour
{
    public float rotateSpeed; 
    Vector2 rotate;
    private void Update()
    {
        if (rotate != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(rotate.x, rotate.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, -targetAngle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
    public void OnRotate(InputAction.CallbackContext ctx) => rotate = ctx.ReadValue<Vector2>();
}
