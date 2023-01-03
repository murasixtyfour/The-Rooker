using System;
using UnityEngine;
using TMPro;

public class FinishTrigger : MonoBehaviour
{
    public GameControl gc;
    public GameObject hud;

    public int sceneIndex;

    SceneControl sc;

    bool isActivated;
    AudioSource asrc;

    TextMeshProUGUI label, value;
    double timer;

    void Awake()
    {
        sc = gc.GetComponent<SceneControl>();
        asrc = GetComponent<AudioSource>();

        label = hud.transform.Find("Label").GetComponent<TextMeshProUGUI>();
        value = hud.transform.Find("Value").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        label.text = sc.buildIndex.ToString();
    }

    void Update()
    {
        if (!isActivated)
        {
            timer += Time.deltaTime;
            timer = Math.Clamp(timer, 0.0, 3599.99);

            value.text = TimeSpan.FromSeconds(timer).ToString("mm':'ss'.'ff");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActivated = true;
            if (GameControl.data.scores[sc.buildIndex - 1] > timer)
            {
                GameControl.data.scores[sc.buildIndex - 1] = timer;
                gc.SaveGame();
            }

            asrc.Play();
            StartCoroutine(sc.Fade(SceneControl.FadeDirection.In, 0f, sceneIndex));            
        }
    }
}
