using UnityEngine;

public class CreateWallUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] selectButtons;
    [SerializeField]
    private GameObject selectWallUI;

    private void Awake()
    {
        gameObject.SetActive(true);
    }

    private void CreateWall()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ActivateSelectWallUI();
    }

    public void ActivateSelectWallUI()
    {
        selectWallUI.SetActive(true);
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
        selectWallUI.SetActive(false);
    }
}
