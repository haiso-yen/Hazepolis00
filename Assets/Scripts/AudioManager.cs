using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer audioMixer;    // 秈︽北Mixer跑秖

    public void SetMasterVolume(float volume)    // 北秖ㄧ计
    {
        audioMixer.SetFloat("MasterVolume", volume);
        // MasterVolumeи忌臩ㄓMaster把计
    }

    public void SetMusicVolume(float volume)    // 北璉春贾秖ㄧ计
    {
        audioMixer.SetFloat("MusicVolume", volume);
        // MusicVolumeи忌臩ㄓMusic把计
    }

    public void SetSoundEffectVolume(float volume)    // 北秖ㄧ计
    {
        audioMixer.SetFloat("SoundEffectVolume", volume);
        // SoundEffectVolumeи忌臩ㄓSoundEffect把计
    }
}