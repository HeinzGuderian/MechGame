using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRadarBearingLine : MonoBehaviour
{
	public GameObject playerMech;
	public Transform startPoint; //på källan till sis-linjebäringen
	public Transform endPoint; //på playerMech
	public Transform parentPosition;

	public Vector3 moveCapsuleCenter;
	float offset;
	LineRenderer line;
	CapsuleCollider capsule;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
                endPoint = gameObject.transform; //endpoint är positionen för objektet som detta skript är på
        startPoint = playerMech.transform; //startPoint är positionen för playerMech
        //capsule behövs inte än så länge
        capsule = gameObject.GetComponent<CapsuleCollider>();
        
        parentPosition = gameObject.GetComponentInParent<Transform>();

        capsule.direction = 2; //z-axis for easier to implement LookAt.
        //just nu ritas linjen till playerMech, som hämtas i editorn. i senare version
        //måste playerMech hämtas in beroende faktisk radar, inte hänvisning i editorn.
        //till detta kan colliders användas som kan avgöra huruvida två objekt har radarkoll på varandra osv.
        
    }
    
    Vector3 GetPoint()
	{
    //get the positions of our transforms
    Vector3 pos1 = startPoint.position ; //blir startPoint i min kod
    Vector3 pos2 = parentPosition.position ; //blir parentPosition.transform
    
    //get the direction between the two transforms -->
    Vector3 dir = (pos2 - pos1).normalized ;
 
    //get a direction that crosses our [dir] direction
    //NOTE! : this can be any of a buhgillion directions that cross our [dir] in 3D space
    //To alter which direction we're crossing in, assign another directional value to the 2nd parameter
    Vector3 perpDir = Vector3.Cross(dir, Vector3.right) ;
 
    //get our midway point
    Vector3 midPoint = (pos1 + pos2) / 2f ;
 
    //get the offset point
    //This is the point you're looking for.
    Vector3 offsetPoint = midPoint + (perpDir * offset) ;
    //change offsetPoint from worldSpace to localSpace
    //offsetPoint = offsetPoint.InverseTransformPoint();
    return offsetPoint;
	}

    // Update is called once per frame
    void Update()
    {
        //Rita ut en linje mellan startPoint och endPoint
        line.SetPosition(0, startPoint.position);
        line.SetPosition(1, endPoint.position);
        endPoint = gameObject.transform; //endpoint är positionen för objektet som detta skript är på
        startPoint = playerMech.transform; //startPoint är positionen för playerMech

       	//just nu hamnar centrumpunkten på collidern mitt på SIS-källan, förskjut den mot egna mechen?
        capsule.height = (startPoint.position - endPoint.position).magnitude; //detta fungerar bra. Capsule Height blir så stor som det behövs.
        
        capsule.center = gameObject.transform.InverseTransformPoint(GetPoint());
        //kapseln tittar på endPoint:
        capsule.transform.LookAt(startPoint.position);
    
    }


}
