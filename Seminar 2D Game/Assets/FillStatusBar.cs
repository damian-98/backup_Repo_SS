using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FillStatusBar : MonoBehaviour
{
    public EnemyAction enemyHealth;
    public Image fillImage;
    private Slider Slider;
    public Vector3 Offset;

    void Awake()
    {
            Slider = GetComponent<Slider>();
    }

    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        // Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(CurrentHealth, MaxHealth, Slider.normalizedValue);
    }
    void Update()
    {
        // Slider.transform.position = GetComponent<Camera>().main.WorldToScreenPoint(transform.parent.position + Offset);
        if (Slider.value <= Slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (Slider.value > Slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillValue = enemyHealth.CurrentHealth / enemyHealth.MaxHealth;

        if (fillValue <= Slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }
        else if (fillValue > Slider.maxValue / 3)
        {
            fillImage.color = Color.green;
        }
        Slider.value = fillValue;

    }
}
