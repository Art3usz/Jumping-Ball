using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonScript : MonoBehaviour
{

    public void LoadScene(int number)
    {
        SceneManager.LoadSceneAsync(number);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
