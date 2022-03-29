using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectOccupation : MonoBehaviour
{
	private Vector3 Center;
	private Vector3 Size;
	public GridManager _GridManager;
    public static ObjectOccupation Instance;
	 void Awake(){
     Instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
		Center = GetComponent< Renderer>().bounds.center;
		Size = GetComponent<Collider>().bounds.size;
		//Debug.Log(Center);
        //Debug.Log(Size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
