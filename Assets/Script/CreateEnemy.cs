using UnityEngine;
using System.Collections;

public class CreateEnemy : MonoBehaviour {
    public GameObject m_upperEdge;
    public GameObject m_enemy;
    private float m_moveY = 0.01f;
    private int m_timeCounter;
    private float m_timeLimit;
    private GameObject m_gameObject;
    private EnemyGroup enemyGroup;

    private int enemyNumber;
    private int touchLowerTimes;
    private int touchUpperTimes;
    private float percentNotMove;

    private float lastTime = 0f;

	// Use this for initialization
	void Start () {
        m_timeCounter = 0;
        m_gameObject = (GameObject)Instantiate(m_enemy, new Vector3(0f, m_upperEdge.transform.position.y, 0f), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        UpdateVariety();
        CreateEnemyGroup();
    }

    void Move()
    {

    }

    public void CreateEnemyGroup()
    {
        m_timeCounter++;
        if (m_timeCounter >= m_timeLimit)
        {
            m_timeCounter = 0;
            Random.seed = System.Guid.NewGuid().GetHashCode();
            for (int i = 0; i < enemyNumber; i++)
            {
                int percent = Random.Range(0, 100);
                if(percent > percentNotMove)
                {
                    float position1 = Random.Range(-30, 30) / 10f;
                    float position2 = Random.Range(-30, 30) / 10f;
                    int time = Random.Range(touchLowerTimes, touchUpperTimes);
                    m_gameObject = (GameObject)Instantiate(m_enemy, new Vector3(position1, m_upperEdge.transform.position.y, 0f), Quaternion.identity);
                    enemyGroup = m_gameObject.GetComponent<EnemyGroup>();
                    enemyGroup.SetState(position1, position2, time, 1);
                }
                else
                {
                    float position1 = Random.Range(-30, 30) / 10f;
                    float position2 = position1;
                    int time = Random.Range(touchLowerTimes, touchUpperTimes);
                    m_gameObject = (GameObject)Instantiate(m_enemy, new Vector3(position1, m_upperEdge.transform.position.y, 0f), Quaternion.identity);
                    enemyGroup = m_gameObject.GetComponent<EnemyGroup>();
                    enemyGroup.SetState(position1, position2, time, 1);
                }
            }
        }
    }

    public void UpdateVariety()
    {
        m_timeLimit = (1 / m_moveY) * (1 / 0.7f);
        float time = Time.time;
        if (time >= 0 && time < 5)
        {
            enemyNumber = 1;
            touchLowerTimes = 1;
            touchUpperTimes = 1;
            percentNotMove = 100;
        }
        else if(time >= 5 && time < 10)
        {
            enemyNumber = 1;
            touchLowerTimes = 1;
            touchUpperTimes = 2;
            percentNotMove = 100;
        }
        else if(time >= 10 && time < 15)
        {
            enemyNumber = 1;
            touchLowerTimes = 1;
            touchUpperTimes = 3;
            percentNotMove = 100;
        }
        else if(time >= 15 && time < 20)
        {
            enemyNumber = 2;
            touchLowerTimes = 1;
            touchUpperTimes = 3;
            percentNotMove = 100;
        }
        else if(time >= 20 && time < 25)
        {
            enemyNumber = 2;
            touchLowerTimes = 1;
            touchUpperTimes = 3;
            percentNotMove = 75;
        }
        else if(time >= 25 && time < 30)
        {
            enemyNumber = 2;
            touchLowerTimes = 2;
            touchUpperTimes = 3;
            percentNotMove = 75;
        }
        else if(time >= 30 && time < 35)
        {
            enemyNumber = 2;
            touchLowerTimes = 2;
            touchUpperTimes = 3;
            percentNotMove = 50;
        }
        else if(time >= 35)
        {
            enemyNumber = 3;
            touchLowerTimes = 2;
            touchUpperTimes = 3;
            percentNotMove = 50;
        }
    }
}
