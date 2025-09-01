using TMPro.Examples;
using UnityEngine;

public class handController : MonoBehaviour
{

    [SerializeField] Animator leftAnimator;
    [SerializeField] Animator rightAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Right Hand Triggered");
            rightAnimator.SetTrigger("RightHandTrigger");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Left Hand Triggered");
            leftAnimator.SetTrigger("LeftHandTrigger");
        }
    }
}
