using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveSpeed = 0.1f;

    private float[] rangeX, rangeY;
    private bool isMove = false;
    private Vector3 startPos;

    private void Start()
    {
        transform.position = new Vector3(0f, 0f, -5f);
        rangeX = GlobalParameters.Instance.RangeX;
        rangeY = GlobalParameters.Instance.RangeY;

        gameObject.AddComponent<Rigidbody>().isKinematic = true;
        startPos = transform.position;
    }

    private void Update()
    {
        movePlayer();


    }

    private void movePlayer()
    {
        if (Input.GetKeyDown(KeyCode.A))
            StartCoroutine(MoveLeft());
        //if (Input.GetKeyDown(KeyCode.D))
        //    StartCoroutine(MoveRight());
        if (Input.GetKeyDown(KeyCode.W))
            StartCoroutine(MoveUp());
        if (Input.GetKeyDown(KeyCode.S))
            StartCoroutine(MoveDown());

    }

    private IEnumerator MoveUp()
    {
        if (startPos.y + GlobalParameters.Instance.MoveStep <= GlobalParameters.Instance.RangeY[1] + 0.01f)
        {
            while (transform.position.y < startPos.y + GlobalParameters.Instance.MoveStep)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed, transform.position.z);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            startPos = transform.position;
        }
    }

    private IEnumerator MoveDown()
    {
        if (startPos.y - GlobalParameters.Instance.MoveStep >= GlobalParameters.Instance.RangeY[0] - 0.01f)
        {
            while (transform.position.y > startPos.y - GlobalParameters.Instance.MoveStep)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed, transform.position.z);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            startPos = transform.position;
        }
    }

    private IEnumerator MoveLeft()
    {
        Debug.Log(startPos.x - GlobalParameters.Instance.MoveStep);
        Debug.Log(GlobalParameters.Instance.RangeY[0] - 0.01f);
        if (startPos.x - GlobalParameters.Instance.MoveStep >= GlobalParameters.Instance.RangeY[0] - 0.01f)
        {
            while (transform.position.x > startPos.x - GlobalParameters.Instance.MoveStep)
            {
                transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            startPos = transform.position;
        }
    }

}
