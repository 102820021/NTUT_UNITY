using UnityEngine;
using System.Collections;

public class EnemyGroup : MonoBehaviour {
    public GameObject m_meteorite;
    private int m_leaveTimes;
    private float m_leftPosition;
    private float m_rightPosition;
    private float m_moveX;
    private float m_moveY = 0.01f;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMove();
    }

    public void EnemyMove()
    {
        float position = this.transform.position.x + m_moveX;
        if(m_rightPosition > m_leftPosition)
        {
            if(!(position > m_leftPosition && position < m_rightPosition))
            {
                m_moveX = -1 * m_moveX;
            }
        }
        else if(m_leftPosition > m_rightPosition)
        {
            if(!(position > m_rightPosition && position < m_leftPosition))
            {
                m_moveX = -1 * m_moveX;
            }
        }
        this.transform.position = new Vector3(position, this.transform.position.y - m_moveY, this.transform.position.z);
    }

    public void SetState(float position1, float position2, int time, float weights)
    {
        m_leftPosition = position1;
        m_rightPosition = position2;
        m_leaveTimes = time;
        m_meteorite.GetComponent<Meteorite>().SetTimes(time);
        m_moveX = (m_rightPosition - m_leftPosition) * Time.deltaTime * 0.5f;
    }
}
