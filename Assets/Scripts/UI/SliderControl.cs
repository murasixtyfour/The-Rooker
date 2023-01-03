using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderControl : MonoBehaviour
{
    public int index;
    public TextMeshProUGUI value;  

    Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider.value = GameControl.data.options[index];
    }

    public void resetValue()
    {
        if (slider != null)
        {
            slider.value = 50f;
            updateValue();
        }
    }

    public void updateValue()
    {
        if (slider != null)
        {
            GameControl.data.options[index] = slider.value;
            value.text = slider.value.ToString();
        }
    }
}
