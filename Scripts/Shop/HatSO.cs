using UnityEngine;

[CreateAssetMenu(fileName = "Hat")]
public class HatSO : ScriptableObject
{
    public string ItemName;
    public int ItemPrice;
    public Sprite Thumbnail;
    public GameObject Model;
}
