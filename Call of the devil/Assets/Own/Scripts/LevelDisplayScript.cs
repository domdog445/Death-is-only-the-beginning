using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelDisplayScript : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI LevelTxt;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        LevelTxt.text = "Level #" + scene.buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
