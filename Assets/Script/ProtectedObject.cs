using UnityEngine;
using System.Collections;

public class ProtectedObject : MonoBehaviour {
    public GameObject m_protectedObject;
    public Menu m_menu;
    private bool isMoving = true;
    private float m_moveY = 0.01f;
    private float lastTime = 0f;
    // Use this for initialization
    void Start () {
        m_menu = GameObject.FindGameObjectsWithTag("Menu")[0].GetComponent<Menu>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        SetMoveY();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            m_menu.LoseGame();
            Time.timeScale = 0;
//            isMoving = false;
        }
        if(other.tag == "End")
        {
            m_menu.WinGame();
            Time.timeScale = 0;
//            isMoving = false;
        }
    }

    void Move()
    {
        if(isMoving)
            m_protectedObject.transform.position = new Vector3(m_protectedObject.transform.position.x, m_protectedObject.transform.position.y + m_moveY, m_protectedObject.transform.position.z);
    }

    public void SetMoveY()
    {
        if(Time.time - lastTime >= 10)
        {
            lastTime = Time.time;
            m_moveY += 0.005f;
        }
    }
}
