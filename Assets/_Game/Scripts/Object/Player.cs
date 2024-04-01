using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float speed;
    [SerializeField] private Transform cube;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Swipe swipeControl;

    private bool isMoving;
    private bool isPaused;
    private RaycastHit hit;
    private Stack<GameObject> bricks;

    void Start()
    {
        OnInit();
    }

    void Update()
    {
        if (isPaused == true)
        {
            return;
        }

        MoveTarget();

        if (isMoving == true)
        {
            return;
        }

        SetRaycastRotation();
    }

    public void OnInit()
    {
        isPaused = false;
        isMoving = false;
        speed = 20f;
        bricks = new Stack<GameObject>();

        ChangeIdle();
    }

    private void SetRaycastRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || swipeControl.GetMove() == Direction.Left)
        {
            cube.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow) || swipeControl.GetMove() == Direction.Right)
        {
            cube.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow) || swipeControl.GetMove() == Direction.Up)
        {
            cube.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (Input.GetKey(KeyCode.DownArrow) || swipeControl.GetMove() == Direction.Down)
        {
            cube.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }

    private void MoveTarget()
    {
        if (Physics.Raycast(cube.position, cube.TransformDirection(Vector3.forward), out hit, 100f, wallLayer))
        {
            isMoving = true;

            Vector3 target = transform.position + cube.TransformDirection(Vector3.forward) * (hit.distance - 0.5f);
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target) < 0.00001f)
            {
                isMoving = false;
            }
        }
    }

    public void ChangeIdle()
    {
        anim.Play(StringCache.Action.IDLE);
    }

    public void ChangeWin()
    {
        anim.Play(StringCache.Action.WIN);
    }

    public void AddBrick(GameObject obj)
    {
        bricks.Push(obj);
    }

    public void RemoveBrick()
    {
        Destroy(bricks.Pop());
    }

    public void ResetBrick()
    {
        bricks.Clear();
    }

    public int GetBricksSize()
    {
        return bricks.Count;
    }

    public void PausePlayer()
    {
        isPaused = true;
    }

    public void IncreasePosition(Vector3 pos)
    {
        playerTransform.position += pos;
    }
}
