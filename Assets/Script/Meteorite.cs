using UnityEngine;
using System.Collections;

public class Meteorite : Enemy
{
    public GameObject m_meteorite;
    public TextMesh m_leaveTimes;

    override public void StartTouching(float x, float y)
    {
        int time = System.Int32.Parse(m_leaveTimes.text);
        time--;
        SetFingerPosition(x, y);
        m_leaveTimes.text = time.ToString();
        if (time <= 0)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }

    override public void Touching(float x, float y)
    {

    }

    override public void EndTouching(float x, float y)
    {

    }

    override public void Move()
    {
        
    }

    public void SetActive(bool active)
    {
        m_meteorite.SetActive(active);
    }
}
