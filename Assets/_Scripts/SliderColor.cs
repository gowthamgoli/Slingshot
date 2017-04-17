using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour {

    //public Slider mainSlider;

    public Slider mainSlider;
    public Text SliderValue;
    public Image Fill;
    public Image handle;
    public Image background;

    float x = 0.75f;
    float y = 1.25f;
    float z;


    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        Debug.Log(mainSlider.value);
        Fill.color = Color.Lerp(Color.red, Color.green, mainSlider.value/100);
        handle.color = Color.Lerp(Color.red*y, Color.green*y, mainSlider.value / 100);
        background.color = Color.Lerp(Color.red*x, Color.green*x, mainSlider.value / 100);
        SliderValue.text = mainSlider.value.ToString();
        SliderValue.color = Color.Lerp(Color.red, Color.green, mainSlider.value / 100);
    }
}
