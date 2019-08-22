using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour {

    public GameObject arrow;
    public Vector2 speedArrow;
    public Vector3 angleArrow;
    [Range(0, 7)]
    public float delayInSecondsBeforeStartSpawn=0;
    public float howOftenToSpawn = 1f; 
    private void Start()
    {
        StartCoroutine(SpawnArrows());
    }
    IEnumerator SpawnArrows()
    {
        yield return new WaitForSeconds(delayInSecondsBeforeStartSpawn);
        while (true)
        {           
            Instantiate(arrow, transform.position,Quaternion.Euler(angleArrow)).GetComponent<Rigidbody>().velocity=speedArrow;
            yield return new WaitForSeconds(howOftenToSpawn);
        }
    }
}
