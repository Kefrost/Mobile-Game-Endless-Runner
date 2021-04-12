using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get { return instance; } }
    private static SaveManager instance;

    public SaveState save;
    private const string saveFileName = "data.opa";
    private BinaryFormatter formatter;

    public Action<SaveState> OnLoad;
    public Action<SaveState> OnSave;

    private void Awake()
    {
        instance = this;
        formatter = new BinaryFormatter();
        Load();
    }

    public void Load()
    {
        try
        {
            FileStream file =  new FileStream(Application.persistentDataPath + saveFileName, FileMode.Open, FileAccess.Read);
            save = (SaveState)formatter.Deserialize(file);
            file.Close();
            OnLoad?.Invoke(save);
        }
        catch (Exception)
        {
            Debug.Log("Save not found!");
            Save();
        }
    }

    public void Save()
    {
        if (save == null)
        {
            save = new SaveState();
        }

        save.LastSaveTime = DateTime.Now;

        FileStream file = new FileStream(Application.persistentDataPath + saveFileName, FileMode.OpenOrCreate, FileAccess.Write);
        formatter.Serialize(file, save);
        file.Close();

        OnSave?.Invoke(save);
    }
}
