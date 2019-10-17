using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public Slider slider;
    public AsyncOperation operation;
    public GameObject button;
    //public GameObject text;

    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(operation.progress);
            slider.value = progress;
            
            
            //text.SetActive(false);
            if(slider.value == 1)
            {
                button.SetActive(true);
                operation.allowSceneActivation = false;
                break;
            }
           
            
            yield return null;
        }
        
    }
    public void ActivateScene()
    {
        operation.allowSceneActivation = true;
        
    }
}
