using UnityEngine;
using System.Collections;

public class FingerPosition : MonoBehaviour {
    public GameObject m_fingerObject;
    private int m_fingerId;
    private float m_fingerPositionX;
    private float m_fingerPositionY;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().StartTouching(m_fingerPositionX, m_fingerPositionY);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Touching(m_fingerPositionX, m_fingerPositionY);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().EndTouching(m_fingerPositionX, m_fingerPositionY);
        }
    }

    public void SetFingerId(int id)
    {
        m_fingerId = id;
    }

    public int GetFingerId()
    {
        return m_fingerId;
    }

    public void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }
}
