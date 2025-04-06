using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;

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
    private List<GameObject> redWalls = new List<GameObject>();
    [SerializeField]
    private List<GameObject> blueWalls = new List<GameObject>();

    public const int Blue = 1;
    public const int Red = 2;

    private float count = 0;
    [SerializeField]
    private int turn = Red;

    //private string turn = "Blue";

    public bool isActiveWallManageUI = false;

    
    public int Turn
    {
        get => turn;
        set => turn = value;
    }

    public float Count()
    {
        return blueWalls.Count + redWalls.Count;
    }

    public void ChangeTurn()
    {
        if (turn == Blue)
            turn = Red;
        else
            turn = Blue;
    }

    public void CreatWallAndInsertArray(int prefabNum)
    {
        List<GameObject> walls= new List<GameObject>();

        if (turn == Blue)
            walls = blueWalls;
        else
            walls = redWalls;

        if (walls.Count >= 3)
        {
            Debug.Log("벽을 더이상 생성할 수 없습니다....");
            return;
        }
            

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                    Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        GameObject wall = Instantiate(wallPrefab[prefabNum], worldPosition, Quaternion.identity);


        SpriteRenderer wallColor = wall.GetComponent<SpriteRenderer>();
        if (turn == Blue)
            wallColor.color = Color.blue;
        else
            wallColor.color = Color.red;

        if (wallColor == null)
            Debug.Log("스프라이트 렌더러 없음!!");
        walls.Add(wall);

        
        count += 0.5f;



        /*for (int i = 0; i < walls.Length; i++)
        {
            if (walls[i] == null)
            {
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                    Camera.main.WorldToScreenPoint(transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                GameObject wall = Instantiate(wallPrefab[prefabNum], worldPosition, Quaternion.identity);
                walls[i] = wall;
                walll.Add(walls[i]);
                return;
            }
        }
        Debug.Log("벽을 더이상 생성할 수 없습니다....");*/

    }

    public void DeselectWallAll(GameObject wall = null)
    {
        
        for (int i = 0; i < redWalls.Count; i++)
        {
            if (redWalls[i] != null && redWalls[i] != wall)
            {
                redWalls[i].GetComponent<WallController>().isSelect = false;
                redWalls[i].GetComponent<WallController>().SelectUI.SetActive(false);
            }
        }

        for (int i = 0; i < blueWalls.Count; i++)
        {
            if (blueWalls[i] != null && blueWalls[i] != wall)
            {
                blueWalls[i].GetComponent<WallController>().isSelect = false;
                blueWalls[i].GetComponent<WallController>().SelectUI.SetActive(false);
            }
        }
    }
}
