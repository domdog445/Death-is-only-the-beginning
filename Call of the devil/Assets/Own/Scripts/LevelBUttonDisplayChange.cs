using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBUttonDisplayChange : MonoBehaviour
{
    [SerializeField]
    int LevelNumber;
    [SerializeField]
    Color color;

    [SerializeField]
    Button fbutton;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Level-"+LevelNumber) == 1)
        {
            GetComponent<Image>().color = color;
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
