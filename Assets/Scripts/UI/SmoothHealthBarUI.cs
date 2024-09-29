using UnityEngine;

public class SmoothHealthBarUI : HealthBarUI
{
    public override void ManageHealthBar()
    {
        float maxDelta = 100f;
        Slider.value = Mathf.MoveTowards(Slider.value, Health.CurrentHealthValue, maxDelta * Time.deltaTime);
    }
}