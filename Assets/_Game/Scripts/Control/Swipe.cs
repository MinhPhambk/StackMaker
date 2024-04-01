using UnityEngine;

public class Swipe : MonoBehaviour
{
    [SerializeField] private float swipeRange;

    private Direction move;
    private Vector2 startTouch, swipeDelta;
    private bool isDraging;

    void Start()
    {
        swipeRange = 125;
        isDraging = false;
        move = Direction.Stop;
    }

    void Update()
    {
        SwipeControl();
    }

    private void SwipeControl()
    {
        move = Direction.Stop;

        if (Input.GetMouseButtonDown(0))
        {
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            ResetSwipe();
        }

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                ResetSwipe();
            }
        }

        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if (swipeDelta.magnitude > swipeRange)
        {
            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
            {
                if (swipeDelta.x < 0)
                {
                    move = Direction.Left;
                }   
                else
                {
                    move = Direction.Right;
                }   
            }
            else
            {
                if (swipeDelta.y < 0)
                {
                    move = Direction.Down;
                }    
                else
                {
                    move = Direction.Up;
                }    
            }
        }
    }

    private void ResetSwipe()
    {
        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;
    }

    public Direction GetMove()
    {
        return move;
    }
}