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
            Vector3 moveDir = newCube.transform.position - Input.mousePosition;
            moveDir.Normalize();
            // 이렇게 하면 방향 얻을 수 있고
            // 이 방향 대로 블럭이 이동하게 만들면 되겠다.


            
            //newCube.transform.Translate()
        }
	}
}
