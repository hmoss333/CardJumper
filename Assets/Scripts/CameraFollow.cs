using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public Transform player;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Temporary vector
        Vector3 temp = player.position;
        //temp.x = temp.x - gameObject.transform.position.x;
        //temp.y = temp.y - gameObject.transform.position.y;
        temp.z = -10f;
        // Assign value to Camera position
        //transform.position = temp * Time.deltaTime; //"drunk" camera follow; save for later
        transform.position = temp;
    }
}
