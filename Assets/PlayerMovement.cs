using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private int moveSpeed = 10;
    [SerializeField]
    private float moveDirectionX;

    private bool isFacingRight = true;

    void Update()
    {
        moveDirectionX = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Flip();
    }

    private void Move() 
    {
        rb.linearVelocity = new Vector2(moveDirectionX * moveSpeed , rb.linearVelocityY);
    }

    private void Flip()
    {
        if (moveDirectionX > 0 && !isFacingRight || moveDirectionX < 0 && isFacingRight) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
