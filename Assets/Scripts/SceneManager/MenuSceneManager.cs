using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuSceneManager : MonoBehaviour
{
    public void PlayGame()
    {
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click);
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click);
        Application.Quit();
    }





}
