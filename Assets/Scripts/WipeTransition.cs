using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WipeTransition : MonoBehaviour
{
    public Animator transition;
    public Button NewRunButton;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            NewRunButton.onClick.AddListener(TriggerNewRun);
        }
        
    }
    void TriggerNewRun()
    {
        StartCoroutine(LoadGame(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadGame(int levelIndex)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
