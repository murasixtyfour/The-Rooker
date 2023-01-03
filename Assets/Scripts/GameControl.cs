using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public float[] options = new float[] { 50f, 50f };
        public double[] scores = Enumerable.Repeat(3600.0, 16).ToArray();
        public bool[] secrets = Enumerable.Repeat(true, 16).ToArray();
    }
    public static Data data;

    string path;

    void Awake()
    {
        data = new Data();

        path = Application.persistentDataPath + "/data.sav";
        LoadGame();
    }

    void Start()
    {
        Application.targetFrameRate = 120;
    }

    void Update()
    {
        AudioListener.volume = data.options[0] / 100f;
    }

    public void SaveGame()
    {
        FileStream stream = new FileStream(path, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            data = formatter.Deserialize(stream) as Data;
            stream.Close();         
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnableCursor(bool isEnabled)
    {
        Cursor.lockState = isEnabled ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isEnabled;
    }
}
