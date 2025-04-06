using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CreateWallUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] selectButtons;
    [SerializeField]
    private GameObject selectWallUI;
    [SerializeField]
    private TextMeshProUGUI selectText;


    private void Awake()
    {
        //gameObject.SetActive(true);
        ActivateSelectWallUI(true);
        
    }

private void CreateWall()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // UI 테스트용
        {
            ActivateSelectWallUI();
            WallManager.instance.DeselectWallAll();
            
        }
            
    }

    public void ActivateSelectWallUI(bool isFirst = false)
    {
        WallManager.instance.isActiveWallManageUI = true;
        //selectWallUI.SetActive(true);
        if (WallManager.instance.Count() < 6)
        {
            if (isFirst)
                WallManager.instance.Turn = WallManager.Blue;
            else
                WallManager.instance.ChangeTurn();

            ChangeButtonColor();
            selectWallUI.SetActive(true);
            ChangeSelectText();
            WallManager.instance.DeselectWallAll();
        }

        else
            Debug.Log("벽 최대 생성 완료..");
        
    }

    private void ChangeSelectText()
    {
        if (WallManager.instance.Turn == WallManager.Blue)
            selectText.text = "<= " + "Select Wall Style " + (int)(WallManager.instance.Count() / 2 + 1);
        else
            selectText.text = "Select Wall Style " + (int)(WallManager.instance.Count() / 2 + 1)+ " =>";
    }

    public void DeSelectButtonAll(WallCreateButtonController _button)
    {
        foreach (var button in selectButtons)
        {
            if (button != _button)
                button.GetComponent<WallCreateButtonController>().UpdateSelect(false);
        }
    }

    public void DeActivateSelectWallUI()
    {
        WallManager.instance.isActiveWallManageUI = false;
        selectWallUI.SetActive(false);
        
    }

    private void ChangeButtonColor()
    {

        foreach (var button in selectButtons)
        {
            ColorBlock color = button.GetComponent<WallCreateButtonController>().button.colors;
            if (WallManager.instance.Turn == WallManager.Red)
                color.normalColor = Color.red;
            else if (WallManager.instance.Turn == WallManager.Blue)
                color.normalColor = Color.blue;

            button.GetComponent<WallCreateButtonController>().button.colors = color;
        }
        
    }
}
