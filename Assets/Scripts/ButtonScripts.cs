using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour
{

    public GameObject objectToEnable;
    

    public UpAndDown UDScript;
    public ButtonScripts btnScript;

    // Use this for initialization
    void Start()
    {
        UDScript = GetComponent<UpAndDown>();
        btnScript.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        
          
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) //Tjekker om mit gameobject rammer "Player"
        {
            if (btnScript.enabled == true)
            {
                UDScript.enabled = true;
            }
        }
    }
}
