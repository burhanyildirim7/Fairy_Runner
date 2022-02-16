using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaziScriptFuck : MonoBehaviour
{
    private int _levelNumber;


    void Start()
    {
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");

        if (_levelNumber > 1)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }

        Destroy(gameObject, 2f);
    }


}
