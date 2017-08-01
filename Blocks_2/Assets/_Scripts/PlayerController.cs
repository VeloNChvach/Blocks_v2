using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        transform.position = new Vector3(0f, 0f, -5f);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
            movePlayer(MoveSide.Left);
        if (Input.GetKeyDown(KeyCode.D))
            movePlayer(MoveSide.Right);
        if (Input.GetKeyDown(KeyCode.W))
            movePlayer(MoveSide.Up);
        if (Input.GetKeyDown(KeyCode.S))
            movePlayer(MoveSide.Down);


        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal * horizontalSpeed, moveVertical * verticalSpeed, zPos);
        //GetComponent<Rigidbody>().velocity = movement * speed;

        //GetComponent<Rigidbody>().position = new Vector3
        //  (
        //      Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
        //      Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
        //      GetComponent<Rigidbody>().position.z
        //  );

        //GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }

    private void movePlayer(MoveSide side)
    {
        if (side == MoveSide.Left)
            transform.position = new Vector3(transform.position.x - 1.1f, transform.position.y, transform.position.z);
    }

    enum MoveSide
    {
        Up,
        Right,
        Down,
        Left
    }
}
