using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveSpeed;

    private float[] rangeX, rangeY;
    private MoveSide currentMove;
    private bool isMove = false;
    private Vector3 startPos;

    enum MoveSide
    {
        Up,
        Right,
        Down,
        Left
    }

    private void Start()
    {
        transform.position = new Vector3(0f, 0f, -5f);
        rangeX = GlobalParameters.Instance.RangeX;
        rangeY = GlobalParameters.Instance.RangeY;
        GetComponent<Rigidbody>().isKinematic = true;
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentMove = MoveSide.Left;
            isMove = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentMove = MoveSide.Right;
            isMove = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentMove = MoveSide.Up;
            isMove = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentMove = MoveSide.Down;
            isMove = true;
        }

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

    void Update()
    {
        if (!isMove)
            return;
        movePlayer();
    }

    private void movePlayer()
    {
        if (currentMove == MoveSide.Up)
        {
            if (transform.position.y < startPos.y + GlobalParameters.Instance.MoveStep && startPos.y + GlobalParameters.Instance.MoveStep < rangeY[1])
                transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed, transform.position.z);
            else
            {
                isMove = false;
                startPos = transform.position;
            }
        }
            

        //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 1.1f, transform.position.y, transform.position.z), moveSpeed);

        //if (side == MoveSide.Left)
        //    while (transform.position.x > rangeX[0])
        //        transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
        //if (side == MoveSide.Right)
        //    while (transform.position.x < rangeX[1])
        //        transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
        //if (side == MoveSide.Down)
        //    while (transform.position.y > rangeY[0])
        //        transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed, transform.position.z);
        //if (side == MoveSide.Up)
        //    while (transform.position.y < rangeY[1])
        //        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed, transform.position.z);
    }

    
}
