using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PostProcess : MonoBehaviour
{
    Volume volume;
    Vignette vignette;
    private Color goodColor, devilColor;
    ThirdPersonMovement place;

    private void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
        goodColor = new Color32(255, 255, 255,255);
        devilColor = new Color32(255, 25, 25,255);
        place = FindObjectOfType<ThirdPersonMovement>();
    }
    private void Update()
    {
        
        
        if (place.isGood == true)
        {
            vignette.color.value = goodColor;
            vignette.intensity.value = 0.25f;
        }
        else
        {
            vignette.color.value = devilColor;
            vignette.intensity.value = 1;
        }
    }
}
