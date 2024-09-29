using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmoothHealthBarUI : PlayerHealthBarUI
{
    public override void ManageHealthBar()
    {
        float maxDelta = 100f;
        Slider.value = Mathf.MoveTowards(Slider.value, Health.CurrentHealthValue, maxDelta * Time.deltaTime);
    }
}