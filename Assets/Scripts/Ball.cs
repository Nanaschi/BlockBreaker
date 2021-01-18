
using UnityEngine;


public class Ball : MonoBehaviour
{
    //configuration param;
    [SerializeField] Paddle paddle1;
    bool hasStarted = false;
    [SerializeField] float xBallVelocity = 2f;
    [SerializeField] float yBallVelocity = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;



    // state
    Vector2 paddleToBallVector2;

    // cached component we use this when we use ccomponents or scrripts/ classes more than 1 time

    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector2 = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>(); //cashed reference
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!hasStarted) // interesting way of negating
        {
            LockTheBallToPaddle();
            LunchBallOnClick();
                      
        }
    }

    private void LunchBallOnClick()
    {
        if (Input.GetMouseButtonDown (0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xBallVelocity, yBallVelocity);
        }
    }

    private void LockTheBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector2;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2 
            (Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range (0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
