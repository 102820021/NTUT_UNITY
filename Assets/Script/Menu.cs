using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public GameObject m_menu;
    public Text m_gameResult;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void WinGame()
    {
        m_menu.SetActive(true);
        m_gameResult.text = "WIN";
    }

    public void LoseGame()
    {
        m_menu.SetActive(true);
        m_gameResult.text = "LOSE";
    }

    public void StartGame()
    {

    }

    public void QuitGame()
    {

    }

    public void ReplayGame()
    {

    }
}
