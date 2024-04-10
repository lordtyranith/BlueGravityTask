using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager> 
{
    [SerializeField] AudioSource musicBackground;
    [SerializeField] AudioSource SoundClick1;
    [SerializeField] AudioSource SoundClick2;

    public void SoundClicking1()
    {
        SoundClick1.Play();
    }
    public void SoundClicking2()
    {
        SoundClick2.Play();
    }

    public void MuteAndUnmuteAll(bool isOn)
    {
        Debug.Log("Sounds");
        if(isOn) 
        {
           AudioListener.volume = 1f;
        }
        else
        {
            AudioListener.volume = 0f;
        }

        UIManager.Instance.SoundOn = isOn;
    }
  


}
