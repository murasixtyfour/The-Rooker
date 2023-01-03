using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public GameControl gc;

    public GameObject prefabButton;
    public TextMeshProUGUI value;

    SceneControl sc;

    void Awake()
    {
        sc = gc.GetComponent<SceneControl>();
    }

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            int j = i;
            GameObject newButton = Instantiate(prefabButton, prefabButton.transform.position, prefabButton.transform.rotation, transform);

            RectTransform rt = newButton.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(rt.position.x + (j % 4) * 240f, rt.position.y - Mathf.Floor(j / 4) * 64f);

            TextMeshProUGUI label = newButton.transform.Find("Label").GetComponent<TextMeshProUGUI>();
            label.text = (j + 1).ToString();

            TextMeshProUGUI value = newButton.transform.Find("Value").GetComponent<TextMeshProUGUI>();
            value.text = GameControl.data.scores[j] != 3600 ? TimeSpan.FromSeconds(GameControl.data.scores[j]).ToString("mm':'ss'.'ff") : "";

            Button button = newButton.GetComponent<Button>();
            button.onClick.AddListener(() => sc.LoadScene(j + 1));
        }

        value.text = GameControl.data.secrets.Count(c => !c).ToString() + "/16";
    }
}
