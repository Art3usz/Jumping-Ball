using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    // Use this for initialization
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EndLiveStart()
    {
        StartCoroutine(EndLive());
    }

    IEnumerator EndLive()
    {
        audioSource.Play();
        yield return new WaitForSecondsRealtime(3);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            transform.position = new Vector3(player.transform.position.x, 0.7f, -15);
    }
}
