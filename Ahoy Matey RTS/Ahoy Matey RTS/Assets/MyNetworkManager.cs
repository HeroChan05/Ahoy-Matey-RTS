using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {

    private GameObject main_Menu;

	// Use this for initialization
	void Start () {
        main_Menu = GameObject.FindGameObjectWithTag("M_Menu");
	}

    void Update()
    {

    }

    public void MyStartHost()
    {
        Debug.Log(Time.timeSinceLevelLoad + " Starting host");
        StartHost();
        main_Menu.SetActive(false);
    }

    override public void OnStartHost()
    {
        Debug.Log(Time.timeSinceLevelLoad + " Host Started");
    }

    public override void OnStartClient(NetworkClient myClient)
    {
        base.OnStartClient(myClient);
        Debug.Log(Time.timeSinceLevelLoad + " Client start requested");
        InvokeRepeating("dot",0f,1f);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log(Time.timeSinceLevelLoad + " Client is connected to Ip: " + conn.address);
        CancelInvoke();
        base.OnClientConnect(conn);
    }

    public void dot()
    {
        Debug.Log(".");
    }
        
}
