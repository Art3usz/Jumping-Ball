using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float distance = 0.51f;
    public Camera camera;
    private Rigidbody rigidbody;
    private AudioSource audioSource;
    public Vector2 speedAndJumpForce;
    public GameObject firePacticle;
    public AudioClip jumpSound, winSound;
    public int numberGoal = 1;
    private bool takeGoal = false;
    private readonly int currentCollectGoal = 0;

    // Use this for initialization
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<CreateLevel>().CreateLv();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Danger")
        {
            if (takeGoal)
            {
                return;
            }

            camera.GetComponent<CameraMovement>().EndLiveStart();
            Instantiate(firePacticle, transform.position, new Quaternion(0, 0, 90, 1));
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Goal")
        {
            Destroy(collision.gameObject);
            StartCoroutine(TakeGoal());
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        //Jump
        if (Physics.Raycast(transform.position, -Vector3.up, distance) && Input.GetAxis("Jump") != 0)
        {
            rigidbody.AddForce(new Vector3(0, speedAndJumpForce.y, 0), ForceMode.Impulse);
            audioSource.clip = jumpSound;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {


        //Movement 
        Vector2 speed = new Vector2
        {
            x = speedAndJumpForce.x * Input.GetAxis("Horizontal"),
            y = (rigidbody.velocity.y > 9) ? 9 : rigidbody.velocity.y
        };

        rigidbody.velocity = speed;
    }

    private IEnumerator TakeGoal()
    {
        takeGoal = true;
        audioSource.clip = winSound;
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        int nr = SceneManager.GetActiveScene().buildIndex + 1;
        if (nr >= SceneManager.sceneCountInBuildSettings)
        {
            nr = 1;
        }

        SceneManager.LoadSceneAsync(nr);
    }

}
