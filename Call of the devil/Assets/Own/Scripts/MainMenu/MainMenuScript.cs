using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    public AudioMixer masterMixer;


    public void deleteSave()
    {
        PlayerPrefs.DeleteAll();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void OpenUrl(string value)
    {
        Application.OpenURL(value);
    }

    public void quitApplication()
    {
        Application.Quit();
        Debug.Log("Quit Applikation");
    }

    public float masterLvl = 1;
    public float musicLvl = 1;
    public float sfxLvl = 1;

    public TextMeshProUGUI MasterTxt;
    public TextMeshProUGUI MusicTxt;
    public TextMeshProUGUI SFXTxt;

    private void Start()
    {
        masterLvl = PlayerPrefs.GetFloat("MasterVol", 0.4f);
        sfxLvl = PlayerPrefs.GetFloat("SoundsVol", 0.4f);
        musicLvl = PlayerPrefs.GetFloat("MusicVol", 0.4f);



        if (sfxLvl != 0)
            masterMixer.SetFloat("SoundsVol", Mathf.Log10(sfxLvl) * 20);
        else
            masterMixer.SetFloat("SoundsVol", -80);

        MasterTxt.text = (masterLvl * 100f).ToString() + "%";


        if (musicLvl != 0)
            masterMixer.SetFloat("MusicVol", Mathf.Log10(musicLvl) * 20);
        else
            masterMixer.SetFloat("MusicVol", -80);
        SFXTxt.text = (sfxLvl * 100f).ToString() + "%";

        if (masterLvl != 0)
            masterMixer.SetFloat("MasterVol", Mathf.Log10(masterLvl) * 20);
        else
            masterMixer.SetFloat("MasterVol", -80);
        MusicTxt.text = (musicLvl * 100f).ToString() + "%";



        Time.timeScale = 1f;
    }

    public void decreaseSFX()
    {
        if (sfxLvl <= 0)
            return;
        sfxLvl = Mathf.Round((sfxLvl - 0.1f)*100)/100;
        if (sfxLvl != 0)
            masterMixer.SetFloat("SoundsVol", Mathf.Log10(sfxLvl) * 20);
        else
            masterMixer.SetFloat("SoundsVol", -80);
        SFXTxt.text = (sfxLvl*100f).ToString() + "%";
        PlayerPrefs.SetFloat("SoundsVol", sfxLvl);
    }
    public void increaseSFX()
    {
        if (sfxLvl >= 1)
            return;

        sfxLvl = Mathf.Round((sfxLvl + 0.1f) * 100) / 100;
        masterMixer.SetFloat("SoundsVol", Mathf.Log10(sfxLvl) * 20);
        SFXTxt.text = (sfxLvl * 100f).ToString() + "%";
        PlayerPrefs.SetFloat("SoundsVol", sfxLvl);
    }

    public void decreaseMusic()
    {
        if (musicLvl <= 0)
            return;
        musicLvl = Mathf.Round((musicLvl - 0.1f) * 100) / 100;
        if (musicLvl != 0)
            masterMixer.SetFloat("MusicVol", Mathf.Log10(musicLvl) * 20);
        else
            masterMixer.SetFloat("MusicVol", -80);
        MusicTxt.text = (musicLvl * 100f).ToString() + "%";
        PlayerPrefs.SetFloat("MusicVol", musicLvl);
    }
    public void increaseMusic()
    {
        if (musicLvl >= 1)
            return;
        musicLvl = Mathf.Round((musicLvl + 0.1f) * 100) / 100;
        masterMixer.SetFloat("MusicVol", Mathf.Log10(musicLvl) * 20);
        MusicTxt.text = (musicLvl * 100f).ToString() + "%";
        PlayerPrefs.SetFloat("MusicVol", musicLvl);
    }

    public void decreaseMaster()
    {
        if (masterLvl <= 0)
            return;
        masterLvl = Mathf.Round((masterLvl - 0.1f) * 100) / 100;
        if(masterLvl != 0)
            masterMixer.SetFloat("MasterVol", Mathf.Log10(masterLvl) * 20);
        else
            masterMixer.SetFloat("MasterVol", -80);
        MasterTxt.text = (masterLvl * 100f).ToString() + "%";
        PlayerPrefs.SetFloat("MasterVol", masterLvl);
    }
    public void increaseMaster()
    {
        if (masterLvl >= 1)
            return;
        masterLvl = Mathf.Round((masterLvl + 0.1f) * 100) / 100;
        masterMixer.SetFloat("MasterVol", Mathf.Log10(masterLvl) * 20);
        MasterTxt.text = (masterLvl * 100f).ToString() + "%";
        PlayerPrefs.SetFloat("MasterVol", masterLvl);
    }
}
