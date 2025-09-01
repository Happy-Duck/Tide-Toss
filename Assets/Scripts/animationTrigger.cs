using UnityEngine;

public class animationTrigger : MonoBehaviour
{
    [SerializeField] public Animator animator;
    public AudioSource source;

    void Start()
    {
        animator.enabled = true; 
    }

    void OnTriggerEnter(Collider Pod)
    {   
        if (Pod.gameObject.tag == "TidePod")
        {
            Debug.Log("Collision!");
            source.Play();
            animator.SetTrigger("munchTrigger");
        }
    }
}
