using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;



public class RadarCameraStickToMech : MonoBehaviour
//create a transform position that can be copied from the ownMech and placed onto camera once every frame

{
    public GameObject ownMech;
    private Vector3 camPosition;
    // Start is called before the first frame update
    void Awake()
    {
        //find the grameobject transform of ownMech
        camPosition.x = 0;
        camPosition.y = 800;
        camPosition.z = 0;
        transform.position = ownMech.GetComponent<Transform>().position + camPosition;
 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ownMech.GetComponent<Transform>().position + camPosition;

        }
}
