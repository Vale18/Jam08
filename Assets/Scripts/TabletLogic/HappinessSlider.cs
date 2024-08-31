using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessSlider : MonoBehaviour
{
    public Slider zufriedenheitsSlider; 
    public Image fillImage; 

    public float fallRate = 1f;

    private float zufriedenheit = 70; 

    private Color startColor = Color.red;
    private Color endColor = Color.green;

    void Start()
    {
        // Setze den Startwert des Sliders
        zufriedenheitsSlider.maxValue = 100;
        zufriedenheitsSlider.minValue = 0;
        zufriedenheitsSlider.value = zufriedenheit;

        // Initiale Farbsetzung
        UpdateBarColor();


    }
    // Update is called once per frame
    void Update()
    {
        DecreaseHappiness(fallRate * Time.deltaTime);
    }

    public void IncreaseHappiness(float amount)
    {
        zufriedenheit = Mathf.Clamp(zufriedenheit + amount, 0, 100);
        zufriedenheitsSlider.value = zufriedenheit;
        UpdateBarColor();
    }

    public void DecreaseHappiness(float amount)
    {
        zufriedenheit = Mathf.Clamp(zufriedenheit - amount, 0, 100);
        if(zufriedenheit == 0)
        {
            // Game Over
        }
        zufriedenheitsSlider.value = zufriedenheit;
        UpdateBarColor();
    }

    [ContextMenu("ColorBar")]
    private void UpdateBarColor()
    {
        // Interpolation zwischen den Farben basierend auf der Zufriedenheit
        float t = zufriedenheit / 100f; // Normalisiere den Wert auf einen Bereich zwischen 0 und 1
        fillImage.color = Color.Lerp(startColor, endColor, t);
    }
    
    [ContextMenu("Test")]
    public void TestMethod()
    {
        Debug.Log("Test");
    }
}

