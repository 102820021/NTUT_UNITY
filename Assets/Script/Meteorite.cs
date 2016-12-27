using UnityEngine;
using System.Collections;

public class Meteorite : Enemy
{
    public GameObject m_meteorite;
    public GameObject m_explosition;
    public Material[] m_materials;
    public int m_leaveTimes;

    override public void StartTouching(float x, float y)
    {
        m_leaveTimes--;
        SetFingerPosition(x, y);
        if (m_leaveTimes <= 0)
        {
            Instantiate(m_explosition, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity);
            Destroy(this.transform.parent.gameObject);
        }
        else
        {
            SetMaterial();
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

    public void SetTimes(int times)
    {
        m_leaveTimes = times;
        SetMaterial();
    }

    public void SetMaterial()
    {
        this.GetComponent<Renderer>().material = m_materials[m_leaveTimes - 1];
    }
}
