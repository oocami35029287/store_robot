using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
	public bool manageSwitch = false;
    // Start is called before the first frame update
    public void Onclick(){
		if(manageSwitch){
			manageSwitch = false;
			this.gameObject.GetComponentInChildren<Text>().text = "Edit";
		}
		else if(!manageSwitch){
			manageSwitch = true;
			this.gameObject.GetComponentInChildren<Text>().text = "Finish Edit";
		}
		
	}
}
