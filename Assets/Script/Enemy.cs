using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    protected float m_lastFingerPositionX;
    protected float m_lastFingerPositionY;
    protected Vector2 m_fingerMoving;
    protected int m_touchTime;
    public int m_touchedUpperLimit;
    // Use this for initialization
    void Start () {
        m_touchTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    public virtual void StartTouching(float x, float y)
    {

    }

    public virtual void Touching(float x, float y)
    {
        
    }

    public virtual void EndTouching(float x, float y)
    {

    }

    public virtual void Move()
    {
        
    }

    public void MoveFingerDirextion(float x, float y)
    {
        m_fingerMoving = new Vector2(x - m_lastFingerPositionX, y - m_lastFingerPositionY);
    }

    public void SetFingerPosition(float x, float y)
    {
        m_lastFingerPositionX = x;
        m_lastFingerPositionY = y;
    }
}
