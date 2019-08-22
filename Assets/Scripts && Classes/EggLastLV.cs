using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class EggLastLV : MonoBehaviour
{
    Rigidbody rgb;
    // Use this for initialization
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = new Vector2(0, -15);
        rgb.velocity = velocity;
    }

}
