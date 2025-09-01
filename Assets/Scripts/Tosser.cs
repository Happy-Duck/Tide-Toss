using UnityEngine;
using UnityEngine.InputSystem;

public class Tosser : MonoBehaviour
{

    
    public AudioSource source;
    public AudioClip plop;
    public AudioClip whoosh;

    Rigidbody rb;
    [SerializeField] float spFactor = 0.01f;
    [SerializeField] public Animator animator;

    public System.Action floorCollision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        animator.speed = 0;
    }

    bool swiping = false;
    Vector2 swipe = Vector2.zero;
    float swipeTime = 0f;

    bool fresh = true;

    // Update is called once per frame
    void Update()
    { 
        //Reset DEBUG FUNCTION
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(0f, -0.8f, 1f);
            rb.linearVelocity = Vector3.zero;
            animator.Update(0);
            rb.useGravity = false;

        }

        if (Mouse.current.leftButton.wasPressedThisFrame && fresh)
        {
            swiping = true;
            swipe = Vector2.zero;
            swipeTime = 0;

        }

        if (Mouse.current != null && swiping && fresh)
        {
            //Debug.Log(Mouse.current.delta.value);
            swipe += Mouse.current.delta.value;

            // COME BACK TO THIS FOR SWIPE SPEED
            //Debug.Log(Time.deltaTime);
            //swipeTime += Time.deltaTime;
            
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame && swiping && fresh)
        {
            source.PlayOneShot(whoosh);
            swiping=false;
            Vector3 speed = new Vector3(swipe.x * spFactor , swipe.y * spFactor , swipe.y * spFactor ); //swipe.y*spFactor/swipeTime, swipe.y * spFactor / swipeTime);
            //Debug.Log(speed);
            animator.speed = 1;
            OnToss(speed);
        }

    }

    void OnToss(Vector3 speed)
    {
        rb.useGravity=true;
        rb.AddForce(speed, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "kid" && fresh)
        {
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "floor" && fresh)
        {
            
            if (source != null) source.PlayOneShot(plop);
            if (animator != null) animator.speed = 0;
            if (rb != null) Destroy(rb);
            floorCollision?.Invoke();
            fresh = false;

            //pod_index++;
            //if (pod_index == pod_array.Length - 1)
            //{
            //    Destroy(pod_array[0]);
            //    pod_index = 0;
            //    Debug.Log("Test!");

            //    for (int i = 0; i < pod_array.Length - 2; i++)
            //    {
            //        pod_array[i+1] = pod_array[i];
            //    }

            //}

        }
    }

}
