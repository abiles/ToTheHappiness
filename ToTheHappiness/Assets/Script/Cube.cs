using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    Vector3 startPoint;
    Vector3 endPoint;
    public float duration = 100.0f;
    float zAxis;
    bool keepMoving = true;
    bool collisionWithBlcok = false;
    Ray ray;
    RaycastHit hit;

    void Start () {
        startPoint = transform.position;
        zAxis = transform.position.z;
        GetEndPoint();
	}

    void Update()
    {

        if(collisionWithBlcok)
        {
            Vector3 moveVector = endPoint - startPoint;
            moveVector.x = -moveVector.x;
            startPoint = transform.position;
            endPoint = startPoint + moveVector;

            collisionWithBlcok = false;
        }

        if (keepMoving)
        {
            transform.position = Vector3.Lerp(transform.position,
                                              endPoint,
                                              1 / (duration * (Vector3.Distance(transform.position, endPoint))));
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Cube"))
        {
             keepMoving = false;
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Block"))
        {
            collisionWithBlcok = true;
        }
    }


    void GetEndPoint()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            endPoint = hit.point;
            endPoint.z = zAxis;
        }
    }

   
}
