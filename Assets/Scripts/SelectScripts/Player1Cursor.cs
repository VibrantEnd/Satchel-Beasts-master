using UnityEngine;
using UnityEngine.Windows;

public class Player1Cursor : MonoBehaviour
{
    private Vector2 input;
    private Rigidbody2D rigidBody;
    private float Speed = 5f;

    private bool holdingPin;
    [SerializeField] GameObject Pin;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        holdingPin = true;
    }
    private void Update()
    {
        CursorMovement();
        PinState();
        if (holdingPin)
        {
            Pin.transform.position = transform.position;
        }
        
    }
    void CursorMovement()
    {
        float moveX = UnityEngine.Input.GetAxisRaw("P1Horiz");
        float moveY = UnityEngine.Input.GetAxisRaw("P1Vert");

        input.x = UnityEngine.Input.GetAxisRaw("P1Horiz");
        input.y = UnityEngine.Input.GetAxisRaw("P1Vert");
        input.Normalize();
    }
    private void FixedUpdate()
    {
        rigidBody.linearVelocity = input * Speed;
        
    }
    private void PinState()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.G))
        {
            holdingPin = !holdingPin;
        }
        
    }
}
