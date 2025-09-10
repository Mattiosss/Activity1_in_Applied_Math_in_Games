using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical");   

        
        Vector3 moveDir = new Vector3(moveX, moveY, 0);

        
        if (moveDir.magnitude > 1)
            moveDir.Normalize();

        
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
