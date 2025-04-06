using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class WallController : MonoBehaviour
{
    private Vector3 offset;

    public bool isSelect = false;

    public GameObject SelectUI;

    private SpriteRenderer wallColor;
    private int wallType;

    void Start()
    {
        SelectUI.SetActive(false);
        wallColor = GetComponent<SpriteRenderer>();

        if (wallColor.color == Color.red)
            wallType = WallManager.Red;
        else
            wallType = WallManager.Blue;

    }

    void Update()
    {
        TurnWall();
    }

    private void TurnWall() // 벽 회전 함수
    {
        if (!isSelect || WallManager.instance.isActiveWallManageUI == true) return;

        float direction = Input.GetAxisRaw("Horizontal");
        if (direction != 0)
        {
            transform.Rotate(Vector3.forward * direction);
        }
    }
    void OnMouseDown()
    {
        if ((WallManager.instance.isActiveWallManageUI == true) ||
            (wallType != WallManager.instance.Turn))
            return;
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
        if ( (WallManager.instance.isActiveWallManageUI == true) || 
            (wallType != WallManager.instance.Turn) )
            return;
        Debug.Log("드래그 중!!!");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;


        transform.position = worldPosition;
    }
}
