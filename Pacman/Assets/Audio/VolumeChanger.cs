using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        musicSlider.value = AudioSingleton.getInstance().music;
        SFXSlider.value = AudioSingleton.getInstance().sfx;
    }

    public void SetSFX()
    {
        audioMixer.SetFloat("SFX", SFXSlider.value);
    }

    public void SetMusic()
    {
        audioMixer.SetFloat("Music", musicSlider.value);
    }
}