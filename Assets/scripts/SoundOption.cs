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

    public void  setmatervolume()
    {
        audioMixer.SetFloat("Master", Mathf.Log(MaterSlider.value) * 20);

    }
    public void setSFXvolume()
    {
        audioMixer.SetFloat("SFX", Mathf.Log(SFXSlider.value) * 20);

    }

}
