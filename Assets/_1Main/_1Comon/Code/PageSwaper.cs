using TMPro;
using UnityEngine;

public class PageSwaper : MonoBehaviour
{
    private Vector2 currentPos;
    private Vector2 startPos;
    public TMP_Text text;

    private Pages pages;

    private void Awake()
    {
        pages = FindObjectOfType<Pages>();
        currentPos = transform.position;
        startPos = transform.position;
    }

    private void Update()
    {
        text.text = transform.position.ToString();

        if (Input.touchCount > 0)
        {
            Move();
        }
        else 
        {
            if (SwapPage()) return;

            currentPos = startPos;
            transform.position = startPos;
        }
    }

    private  bool SwapPage()
    {
        if (transform.position.x > 3)
        {
            return pages.NextPage(); 
        }
        else if (transform.position.x < -3)
        {
            return pages.PreviousPage(); 
        }

        return false;
    }

    private void Move()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Moved) return;

        currentPos.x -= Mathf.Sign(touch.deltaPosition.x - (touch.deltaPosition.x / 2)) * Time.deltaTime * 5;
        transform.position = currentPos;
    }
}
