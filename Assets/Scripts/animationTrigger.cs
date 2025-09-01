using UnityEngine;

public class animationTrigger : MonoBehaviour
{
    [SerializeField] public Animator animator;
    public AudioSource source;

    Vector3[] positions = new Vector3[6];
    

    void Start()
    {
        animator.enabled = true;
        positions[0] = new Vector3(0.5f, -1f, 15f);
        positions[1] = new Vector3(-4.5f, 0f, 6f);
        positions[2] = new Vector3(5f, 0f, 8f);
        positions[3] = new Vector3(5f, 0f, 15f);
        positions[4] = new Vector3(-4f, 0f, 15f);
        positions[5] = new Vector3(0f, -2f, 6f);
    }

    void OnTriggerEnter(Collider Pod)
    {   
        if (Pod.gameObject.tag == "TidePod")
        {
            Debug.Log("Child Collision!");
            source.Play();
            animator.SetTrigger("munchTrigger");
        }

        Invoke("teleport", 1f);

        
    }

    void teleport()
    {
        int randInt = Random.Range(0, 5);
        transform.position = positions[randInt];
    }
}


