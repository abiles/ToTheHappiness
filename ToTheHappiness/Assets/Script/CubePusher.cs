using UnityEngine;
using System.Collections;

public class CubePusher : MonoBehaviour {

    public GameObject cube;
    
   
	
	// Update is called once per frame
	void Update () {

	    if(Input.GetButtonDown("Fire1"))
        {
            GameObject newCube = Instantiate(cube) as GameObject;
            newCube.transform.position = transform.position;
            //Vector3 moveDir = Input.mousePosition - newCube.transform.position;
            //moveDir.Normalize();
            //moveDir.z = 0;

            //Debug.Log(moveDir.x + " " + moveDir.y + " " + moveDir.z);
            //// 이렇게 하면 방향 얻을 수 있고
            //// 이 방향 대로 블럭이 이동하게 만들면 되겠다.
            //int moveSpeed = 10;
            //Vector3 firstVelocity = new Vector3(moveSpeed, moveSpeed, 0);
            //Vector3 newVelocity = new Vector3(firstVelocity.x * moveDir.x, firstVelocity.y * moveDir.y, 0);
            //newCube.GetComponent<Rigidbody>().velocity = newVelocity;

          
        }
	}
}
