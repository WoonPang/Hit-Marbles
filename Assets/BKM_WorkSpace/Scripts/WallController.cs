using UnityEngine;
using UnityEngine.EventSystems;

public class WallController : MonoBehaviour
{
    private Vector3 offset;

    public bool isSelect = false;

    public GameObject SelectUI;
    void Start()
    {
        SelectUI.SetActive(false);
    }

    void Update()
    {
        TurnWall();
    }

    private void TurnWall() // 벽 회전 함수
    {
        if (!isSelect) return;

        float direction = Input.GetAxisRaw("Horizontal");
        if (direction != 0)
        {
            transform.Rotate(Vector3.forward * direction);
        }
    }
    void OnMouseDown()
    {
        Debug.Log("드래그 시작!!");
        WallManager.instance.DeselectWallAll(gameObject);
        isSelect = true;
        SelectUI.SetActive(true);

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        offset = transform.position - worldPosition;
    }
    void OnMouseDrag()
    {
        Debug.Log("드래그 중!!!");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;


        transform.position = worldPosition;
    }
}
