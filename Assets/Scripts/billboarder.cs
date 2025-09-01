using UnityEngine;

public class billboarder : MonoBehaviour
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //keep plane facing camera
        transform.rotation = Camera.main.transform.rotation; 

    }
}
