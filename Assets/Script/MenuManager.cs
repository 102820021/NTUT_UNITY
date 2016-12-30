using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject CurrentMenu;
	// Use this for initialization
	void Start () {
        MainMenu.active = true;
//        CurrentMenu.active = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowMenu(GameObject menu)
    {
        if (!MainMenu.name.Equals(menu.name))
        {
            Debug.Log("*");
            MainMenu.active = false;
            MainMenu = menu;
            menu.active = true;
        }
    }
}
