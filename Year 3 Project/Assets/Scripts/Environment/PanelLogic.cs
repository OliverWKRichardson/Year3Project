using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLogic : MonoBehaviour
{
    
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ExitClick()
    {
        Debug.Log("exiting");
        player.GetComponent<ShopInteract>().closeShop();

    }

    public void HelpClick() {
        Debug.Log("helpinhg");
        player.GetComponent<ShopInteract>().OpenHelpMenu();
        
        
    }

    public void HelpExitClick()
    {
        player.GetComponent <ShopInteract>().CloseHelpMenu();
    }

    
    
}
