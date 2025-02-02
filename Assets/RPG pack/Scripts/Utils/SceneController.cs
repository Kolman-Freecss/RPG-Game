﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
   
    public string sceneName = "";

   
    public GameObject loadBarObject;
    Slider slider;

    
    AsyncOperation async;

    
    public void CallLoadLevel()
    {
        slider = loadBarObject.GetComponent<Slider>();
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    
    private IEnumerator LoadSceneAsync(string levelName)
    {
        loadBarObject.SetActive(true);
        async = SceneManager.LoadSceneAsync(levelName);
        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            slider.value = async.progress;
            if(async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

   
    public void QuitGame()
    {
        Debug.Log("Exit game pressed, bye bye!.");
        Application.Quit();
    }
}
