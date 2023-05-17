using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    [SerializeField]
    public AudioMixer audioMixer;

    [SerializeField]
    public Slider MaterSlider;
    [SerializeField]
    public Slider SFXSlider;

    public void matervolume()
    {
        audioMixer.SetFloat("Master", MaterSlider.value * 50);

    }
    public void SFXvolume()
    {
        audioMixer.SetFloat("SFX", SFXSlider.value * 50);

    }

}
