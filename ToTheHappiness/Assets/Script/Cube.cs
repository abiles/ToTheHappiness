using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    public int moveSpeed;

    Vector3 startPoint;
    Vector3 endPoint;
    float zAxis;
    Ray ray;
    RaycastHit hit;
    Vector3 moveDir;
    Rigidbody rb;
    bool isFirstCollisionToBottom = true;
    bool isFirstCollisionToCube = true;


    void Start () {
        rb = GetComponent<Rigidbody>();
        InitVelocity();
	}

    void Update()
    {
      

	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Block"))
        {
            if (collision.gameObject.tag == "BottomBlock")
            {
                if(isFirstCollisionToBottom)
                {
                    isFirstCollisionToBottom = false;
                    
                    Debug.Log("Collision to bottom");
                    rb.velocity = Vector3.zero;
                    rb.rotation = Quaternion.identity;
                }

            }
            else
            {
                Debug.Log("Collision to side");

                ChangeMoveDir();
            }
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Cube"))
        {
            if (isFirstCollisionToCube)
            {
                isFirstCollisionToCube = false;

                Debug.Log("Collision to Cube");
                rb.velocity = Vector3.zero;
                rb.rotation = Quaternion.identity;
            }

        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer == LayerMask.NameToLayer("Block"))
    //    {
    //        if (other.gameObject.tag == "BottomBlock")
    //        {
    //            rb.velocity = Vector3.zero;
    //            rb.rotation = Quaternion.identity;
    //            Debug.Log("Collision to bottom");

    //        }
    //        else
    //        {
    //            Debug.Log("Collision to side");

    //            ChangeMoveDir();
    //        }

    //    }
    //    else if (other.gameObject.layer == LayerMask.NameToLayer("Cube"))
    //    {
    //        Debug.Log("Collision to Cube");

    //        rb.velocity = Vector3.zero;
    //        //rb.rotation = Quaternion.identity;

    //    }
    //}

    void GetEndPointFromMousePos()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            endPoint = hit.point;
            endPoint.z = zAxis;
        }
    }

    void InitVelocity()
    {
        startPoint = transform.position;
        zAxis = transform.position.z;
        GetEndPointFromMousePos();
        moveDir = endPoint - startPoint;
        rb.velocity = moveDir.normalized * moveSpeed;
    }

    void ChangeMoveDir()
    {
        moveDir = endPoint - startPoint;
        moveDir.x = -moveDir.x;
        startPoint = transform.position;
        endPoint = startPoint + moveDir;

        rb.velocity = moveDir.normalized * moveSpeed;
    }

    //public float duration = 100.0f;

    // object move to Mouse pos
    //void KeepMovingToEndPoint()
    //{
    //    transform.position = Vector3.Lerp(transform.position,
    //                                          endPoint,
    //                                          1 / (duration * (Vector3.Distance(transform.position, endPoint))));
    //}
}
