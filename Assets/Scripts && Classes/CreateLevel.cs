using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateLevel : MonoBehaviour
{
    public GameObject[] blockPrefabs, fireprefabs;
    public int numberOfFirstLevelInBuilder = 1;
    public LvFeatures[] Levels;
    private GameObject blocks, fire;
    // Use this for initialization
    public void CreateLv()
    {
        blocks = new GameObject
        {
            name = "BLOCKS"
        };
        fire = new GameObject
        {
            name = "FIRE"
        };
        StartCoroutine(CreateFlore());
        StartCoroutine(CreateBackground());
        StartCoroutine(CreateLeftWall());
        StartCoroutine(CreateRightWall());
    }

    private IEnumerator CreateFlore()
    {
        for (int i = 1; i < Levels[SceneManager.GetActiveScene().buildIndex - numberOfFirstLevelInBuilder].lenght; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject o = Instantiate(blockPrefabs[Random.Range(1, blockPrefabs.Length)], new Vector3(i - 8.5f, -4.5f, j), Quaternion.identity);
                o.transform.parent = blocks.transform;
            }
        }
        yield return new WaitForSeconds(0);
    }

    private IEnumerator CreateBackground()
    {
        int i;
        GameObject o = blocks;
        for (i = 0; i <= Levels[SceneManager.GetActiveScene().buildIndex - numberOfFirstLevelInBuilder].lenght; i++)
        {
            for (int j = 0; j < 21; j++)
            {
                o = Instantiate(blockPrefabs[Random.Range(0, blockPrefabs.Length)], new Vector3(i - 8.5f, j - 4.5f, 5f), Quaternion.identity);
                o.transform.parent = blocks.transform;
            }
        }
        o = fire;
        for (i = -3; i < Levels[SceneManager.GetActiveScene().buildIndex - numberOfFirstLevelInBuilder].lenght - 7; i = i + 7)
        {
            o = Instantiate(fireprefabs[Random.Range(0, fireprefabs.Length)], new Vector3(i, -1.15f, 4.154f), Quaternion.Euler(0, 270, 0));
            o.transform.parent = fire.transform;
        }
        for (i = -3; i < Levels[SceneManager.GetActiveScene().buildIndex - numberOfFirstLevelInBuilder].lenght; i = i + 7)
        {
            o = Instantiate(fireprefabs[Random.Range(0, fireprefabs.Length)], new Vector3(i - 3.5f, 7.15f, 4.154f), Quaternion.Euler(0, 270, 0));
            o.transform.parent = fire.transform;
        }
        Destroy(o);
        yield return new WaitForSeconds(0);
    }

    private IEnumerator CreateLeftWall()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 21; j++)
            {
                GameObject o = Instantiate(blockPrefabs[Random.Range(0, blockPrefabs.Length)], new Vector3(-8.5f, j - 4.5f, i), Quaternion.identity);
                o.transform.parent = blocks.transform;
            }
        }
        yield return new WaitForSeconds(0);
    }

    private IEnumerator CreateRightWall()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 21; j++)
            {
                GameObject o = Instantiate(blockPrefabs[Random.Range(0, blockPrefabs.Length)], new Vector3(Levels[SceneManager.GetActiveScene().buildIndex - numberOfFirstLevelInBuilder].lenght - 8.5f, j - 4.5f, i), Quaternion.identity);
                o.transform.parent = blocks.transform;
            }
        }
        yield return new WaitForSeconds(0);
    }
}
