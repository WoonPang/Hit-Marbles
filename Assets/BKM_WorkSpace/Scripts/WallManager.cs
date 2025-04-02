using UnityEngine;
using UnityEngine.UIElements;

public class WallManager : MonoBehaviour
{
    #region singleton
    static public WallManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
            Destroy(gameObject);
    }
    #endregion singleton

    [SerializeField]
    private GameObject[] wallPrefab;

    [SerializeField]
    private GameObject[] walls = new GameObject[3];

    public void CreatWallAndInsertArray(int prefabNum)
    {
        for (int i = 0; i < walls.Length; i++)
        {
            if (walls[i] == null)
            {
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                    Camera.main.WorldToScreenPoint(transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                GameObject wall = Instantiate(wallPrefab[prefabNum], worldPosition, Quaternion.identity);
                walls[i] = wall;
                return;
            }
        }
        Debug.Log("벽을 더이상 생성할 수 없습니다....");

    }

    public void DeselectWallAll(GameObject wall)
    {
        for (int i = 0; i < walls.Length; i++)
        {
            if (walls[i] != null && walls[i] != wall)
            {
                walls[i].GetComponent<WallController>().isSelect = false;
                walls[i].GetComponent<WallController>().SelectUI.SetActive(false);
            }
        }
    }
}
