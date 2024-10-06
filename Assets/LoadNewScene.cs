using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public float delay = 15;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneRoutine());
    }

    // Update is called once per frame
    IEnumerator LoadSceneRoutine(){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SnapExamplesReworked");
    }
}
