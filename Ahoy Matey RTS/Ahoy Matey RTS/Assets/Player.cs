using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class Player : NetworkBehaviour{

    private Vector3 inputValue;
    private Material PlayerMaterial;

	// Use this for initialization
	void Start () {
        PlayerMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer)
        {
            return;
            
        }
        else
        {
           
            PlayerMaterial.color = Color.blue;
            inputValue.x = CrossPlatformInputManager.GetAxis("Vertical");
            inputValue.y = 0f;
            inputValue.z = CrossPlatformInputManager.GetAxis("Horizontal");

            transform.Translate(inputValue);
        }
	}

    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<Camera>().enabled = true;
    }
}
