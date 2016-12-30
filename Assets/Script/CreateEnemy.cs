using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using Assets.Script;

public class CreateEnemy : MonoBehaviour {

    private const int MAX_WAVE = 1;

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

    private List<Wave> _enemyList;
    private int _waveNo;

    // Use this for initialization
    void Start () {
        m_timeCounter = 0;
        _waveNo = 0;
        _enemyList = new List<Wave>();
        ReadWave(1);
        //m_gameObject = (GameObject)Instantiate(m_enemy, new Vector3(0f, m_upperEdge.transform.position.y, 0f), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        //Move();
        //UpdateVariety();
        //CreateEnemyGroup();
        m_timeCounter++;
        if(m_timeCounter > (int)(1.5f / Time.smoothDeltaTime) && _waveNo < _enemyList.Count)
        {
            InitiateWave(_enemyList[_waveNo]);
            _waveNo++;
            m_timeCounter = 0;
        }
    }
    

    //Initiate File Read
    void ReadWave(int level)
    {
        if(level>0 && level <= MAX_WAVE)
        {
            string fileLocation = Application.dataPath + "/Maps/Enemy/" + level + ".txt";
            Load(fileLocation);
        }else
        {
            Debug.Log("Max level exceeded");
        }
    }

    //Create Waves of Enemy from List of Interger
    public void InitiateWave(Wave wave)
    {
        for(int i = 0; i<6; i++)
        {
            if(wave._enemyFormation[i] > 0)
            {
                float position1, position2;
                if (!wave._isRandom)
                {
                    position1 = (-25 + i * 10) / 10.0f;
                }else
                {
                    position1 = (UnityEngine.Random.Range(0, 10) - 30 + i * 10) / 10.0f;
                }

                if (wave._canMove)
                {
                    position2 = position1 + UnityEngine.Random.Range(1, 3) * RandomOne();
                }
                else
                {
                    position2 = position1;
                }
                
                m_gameObject = (GameObject)Instantiate(m_enemy, new Vector3(position1, m_upperEdge.transform.position.y, 0f), Quaternion.identity);
                enemyGroup = m_gameObject.GetComponent<EnemyGroup>();
                enemyGroup.SetState(position1, position2, wave._enemyFormation[i]);
            }
        }
    }

    int RandomOne()
    {
        int rand = UnityEngine.Random.Range(-100, 100);
        if(rand > 0)
        {
            return 1;
        }else
        {
            return -1;
        }
    }

    public void CreateEnemyGroup()
    {
        m_timeCounter++;
        if (m_timeCounter >= m_timeLimit)
        {
            m_timeCounter = 0;
            UnityEngine.Random.seed = System.Guid.NewGuid().GetHashCode();
            for (int i = 0; i < enemyNumber; i++)
            {
                int percent = UnityEngine.Random.Range(0, 100);
                if(percent > percentNotMove)
                {
                    float position1 = UnityEngine.Random.Range(-30, 30) / 10f;
                    float position2 = UnityEngine.Random.Range(-30, 30) / 10f;
                    int time = UnityEngine.Random.Range(touchLowerTimes, touchUpperTimes);
                    m_gameObject = (GameObject)Instantiate(m_enemy, new Vector3(position1, m_upperEdge.transform.position.y, 0f), Quaternion.identity);
                    enemyGroup = m_gameObject.GetComponent<EnemyGroup>();
                    enemyGroup.SetState(position1, position2, time);
                }
                else
                {
                    float position1 = UnityEngine.Random.Range(-30, 30) / 10f;
                    float position2 = position1;
                    int time = UnityEngine.Random.Range(touchLowerTimes, touchUpperTimes);
                    m_gameObject = (GameObject)Instantiate(m_enemy, new Vector3(position1, m_upperEdge.transform.position.y, 0f), Quaternion.identity);
                    enemyGroup = m_gameObject.GetComponent<EnemyGroup>();
                    enemyGroup.SetState(position1, position2, time);
                }
            }
        }
    }

    private bool Load(string fileName)
    {
        try
        {
            string line;
            _enemyList.Clear();
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            using (theReader)
            {
                do
                {
                    line = theReader.ReadLine();

                    if (line != null)
                    {
                        _enemyList.Add(CreateLine(line));
                    }
                }
                while (line != null); 
                theReader.Close();
                return true;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }

    Wave CreateLine(string line)
    {
        Wave wave = new Assets.Script.Wave();
        if(line[0] == 'R')
        {
            wave._isRandom = true;
        }else
        {
            wave._isRandom = false;
        }
        if (line[1] == 'M')
        {
            wave._canMove = true;
        }
        else
        {
            wave._canMove = false;
        }

        for(int i = 2; i< 8; i++)
        {
            if(line[i] >= '0' && line[i] <= '9')
            {
                wave._enemyFormation.Add(line[i] - '0');
            }else
            {
                wave._enemyFormation.Add(0);
            }
        }
        return wave;
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
