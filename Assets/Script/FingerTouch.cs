﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FingerTouch : MonoBehaviour {
    public GameObject m_fingerPosition;
    public int m_fingerNumber = 2;
    private List<GameObject> m_fingerObject;
    Vector2 m_screenPos = new Vector2();
    private float m_fieldPositionZ = 10f;
    private float m_fieldFarPositionZ = 100f;
	// Use this for initialization
	void Start () {
        Input.multiTouchEnabled = true;
        m_fingerObject = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        
        #if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
                MobileInput ();
        #else
                DesktopInput();
        #endif
    }

    public void DesktopInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePositionOnNearPlane = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_fieldPositionZ));
            GameObject newObject = (GameObject)Instantiate(m_fingerPosition, mousePositionOnNearPlane, Quaternion.identity);
            m_fingerObject.Add(newObject);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePositionOnNearPlane = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_fieldPositionZ));
            GameObject oldObject = m_fingerObject[0];
            FingerPosition script = oldObject.GetComponent<FingerPosition>();
            script.SetPosition(mousePositionOnNearPlane);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(m_fingerObject[0]);
            m_fingerObject.RemoveAt(0);
        }
    }

    public void MobileInput()
    {
        int length = Input.touchCount;

        for (int i = 0; i < length && i < m_fingerNumber; i++)
        {
            int id = Input.touches[i].fingerId;
            Vector3 mousePositionOnNearPlane = Camera.main.ScreenToWorldPoint(new Vector3(Input.touches[i].position.x, Input.touches[i].position.y, m_fieldPositionZ));
            
            //開始觸碰
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                GameObject newObject = (GameObject)Instantiate(m_fingerPosition, mousePositionOnNearPlane, Quaternion.identity);
                FingerPosition script = newObject.GetComponent<FingerPosition>();
                script.SetFingerId(Input.touches[i].fingerId);
                m_fingerObject.Add(newObject);
            }
            else if (Input.touches[i].phase == TouchPhase.Moved)
            {
                GameObject oldObject = GetFingerPosition(id);
                if(oldObject != null)
                {
                    FingerPosition script = oldObject.GetComponent<FingerPosition>();
                    script.SetPosition(mousePositionOnNearPlane);
                }
            }

            //手指離開螢幕
            if (Input.touches[i].phase == TouchPhase.Ended || Input.touches[i].phase == TouchPhase.Canceled)
            {
                GameObject oldObject = GetFingerPosition(id);
                if (oldObject != null)
                {
                    Destroy(oldObject);
                    m_fingerObject.Remove(oldObject);
                }
            }
        }
        Debug.Log(m_fingerObject.Count);
    }

    public GameObject GetFingerPosition(int id)
    {
        int length = m_fingerObject.Count;

        for(int i = 0; i < length; i++)
        {
            FingerPosition script = m_fingerObject[i].GetComponent<FingerPosition>();
            int fingerId = script.GetFingerId();
            if(fingerId == id)
            {
                return m_fingerObject[i];
            }
        }
        return null;
    }
}
