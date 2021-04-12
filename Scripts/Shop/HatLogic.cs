using System.Collections.Generic;
using UnityEngine;

public class HatLogic : MonoBehaviour
{
    [SerializeField] private Transform hatContainer;
    private HatSO[] hats;
    private List<GameObject> hatModels = new List<GameObject>();

    private void Start()
    {
        hats = Resources.LoadAll<HatSO>("Hat/");
        SpawnHats();
        SelectHat(SaveManager.Instance.save.CurrentHatIndex);
    }

    private void SpawnHats()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            hatModels.Add(Instantiate(hats[i].Model, hatContainer));
        }
    }

    public void DisableAllHats()
    {
        foreach (var hat in hatModels)
        {
            hat.SetActive(false);
        }
    }

    public void SelectHat(int index)
    {
        DisableAllHats();
        hatModels[index].SetActive(true);
    }
}
