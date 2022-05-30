using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalLight : MonoBehaviour
{

    [SerializeField]
    GameObject WinScreen;

    [SerializeField]
    AudioSource audiosource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();


            PlayerPrefs.SetInt("Level-" + scene.buildIndex,1);
            Debug.Log("Win");
            WinScreen.SetActive(true);
            Time.timeScale = 0;
            audiosource.Play();

        }
        
    }

}
