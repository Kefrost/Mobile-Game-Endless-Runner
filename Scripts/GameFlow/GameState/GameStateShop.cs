using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStateShop : GameState
{
    public GameObject shopUI;
    public TextMeshProUGUI totalScrap;
    public TextMeshProUGUI currentHatName;
    public HatLogic hatLogic;
    private bool isInit = false;

    public GameObject hatPrefab;
    public Transform hatContainer;
    private HatSO[] hats;

    public override void Construct()
    {
        GameManager.Instance.ChangeCamera(GameCamera.Shop);
        hats = Resources.LoadAll<HatSO>("Hat/");
        shopUI.SetActive(true);
        totalScrap.text = SaveManager.Instance.save.Scrap.ToString("000");
        
        if (!isInit)
        {
            currentHatName.text = hats[SaveManager.Instance.save.CurrentHatIndex].ItemName;
            PopulateShop();
            isInit = true;
        }

    }

    public override void Destruct()
    {
        shopUI.SetActive(false);
    }

    public override void UpdateState()
    {

    }

    public void OnHomeClick()
    {
        GameManager.Instance.ChangeState(GameStateEnum.Init);
    }

    private void PopulateShop()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            int index = i;

            GameObject go = Instantiate(hatPrefab, hatContainer);

            go.GetComponent<Button>().onClick.AddListener(() => OnHatClick(index));

            go.transform.GetChild(0).GetComponent<Image>().sprite = hats[index].Thumbnail;

            go.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = hats[index].ItemName;

            if (SaveManager.Instance.save.UnlockedHatFlag[i] == 0)
            {
                go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = hats[index].ItemPrice.ToString();
            }
            else
            {
                go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Purchased";
            }
        }
    }

    private void OnHatClick(int i)
    {
        if (SaveManager.Instance.save.UnlockedHatFlag[i] == 1)
        {
            SaveManager.Instance.save.CurrentHatIndex = i;
            Debug.Log($"Hat number {i} was clicked!");
            currentHatName.text = hats[i].ItemName;
            hatLogic.SelectHat(i);
            SaveManager.Instance.Save();
        }
        else if(hats[i].ItemPrice <= SaveManager.Instance.save.Scrap)
        {
            SaveManager.Instance.save.Scrap -= hats[i].ItemPrice;
            SaveManager.Instance.save.UnlockedHatFlag[i] = 1;
            SaveManager.Instance.save.CurrentHatIndex = i;
            currentHatName.text = hats[i].ItemName;
            hatLogic.SelectHat(i);
            totalScrap.text = SaveManager.Instance.save.Scrap.ToString("000");
            SaveManager.Instance.Save();
            hatContainer.GetChild(i).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Purchased";
        }
        else
        {
            Debug.Log("Not enough scrap!");
        }
    }
}