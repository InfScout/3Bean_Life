using UnityEngine;
using UnityEngine.UI;   
public class Bars : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxBar(float Bar)
    {
        slider.maxValue = Bar;
        slider.value = Bar;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetBar(float barAmmount)
    {
        slider.value = barAmmount;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
