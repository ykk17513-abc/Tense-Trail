using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
  
    private Rigidbody rb;
    private Vector3 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();// Character controller (자유롭게 조절) 
    }

    void Update()
    {
        float h = 0;
        float v = 0;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed) h = -1;
            if (Keyboard.current.dKey.isPressed) h = 1;
            if (Keyboard.current.wKey.isPressed) v = 1;
            if (Keyboard.current.sKey.isPressed) v = -1;
        }

        moveDirection = new Vector3(h, 0f, v).normalized;
    }

    private void FixedUpdate()
    {
        Vector3 nextPosition =
            rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
        
        rb.MovePosition(nextPosition);
    }
}