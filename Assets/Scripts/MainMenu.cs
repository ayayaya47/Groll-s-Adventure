using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject logOn;
    public GameObject signIn;
    public GameObject instruction;
    public GameObject setting;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);

    }

    public void InstructionsGame()
    {
        instruction.SetActive(true);
        
    }

    public void SettingGame()
    {
        setting.SetActive(true);
        
    }

    public void BackMenu()
    {
        instruction.SetActive(false);
        setting.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();

    }
    public void LogOn()
    {
        logOn.SetActive(true);
    }
    public void SignIn()
    {
        signIn.SetActive(true);
        logOn.SetActive(false);
    }
    public void ReturnLog()
    {
        signIn.SetActive(false);
        logOn.SetActive(true);
    }
    public void LogSuccess()
    {
        
        logOn.SetActive(false);
    }

    public void SetVolume(float value)
    {
        audioMixer.SetFloat("BGM", value);
        audioMixer.SetFloat("SE", value);
    }
    public void SetVolume2(float value)
    {
        
        audioMixer.SetFloat("SE", value);
    }
}
