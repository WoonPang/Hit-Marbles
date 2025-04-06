using UnityEngine;
using UnityEngine.UI;

public class WallCreateButtonController : MonoBehaviour
{
    [SerializeField]
    private GameObject selectUI;
    
    [SerializeField]
    private CreateWallUIManager createWallUI;

    public bool isSelect;

    public Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    private void OnEnable()
    {
        UpdateSelect(false);
    }

    public void UpdateSelect(bool _click)
    {
        isSelect = _click;
        selectUI.SetActive(_click);
    }

    public void SelectButton1()
    {
        SelectButton(0);
    }
    public void SelectButton2()
    {
        SelectButton(1);
    }
    public void SelectButton3()
    {
        SelectButton(2);
    }
    private void SelectButton(int prefabNum)
    {
        if (isSelect)
        {
            Debug.Log("벽 생성!!");

            UpdateSelect(false);
            WallManager.instance.CreatWallAndInsertArray(prefabNum);
            createWallUI.DeActivateSelectWallUI();

            
            
            return;
        }

        Debug.Log("버튼 선택중...");

        createWallUI.DeSelectButtonAll(this);
        UpdateSelect(true);

        
    }
}
