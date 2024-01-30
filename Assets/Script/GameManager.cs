using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject MeteorA;
    public GameObject MeteorB;
    public GameObject MeteorC;
    public GameObject MeteorD;

    public TextMeshProUGUI timeText;
    public static float time;

    private static GameManager instance = null;

    [SerializeField] private int currentWaveIndex = 0;
    private int currentSpawnCount = 0;
    private int waveSpawnCount = 0;
    private int waveSpawnPosCount = 0;

    public float spawnInterval = .5f;

    [SerializeField] private Transform spawnPositionsRoot;
    private List<Transform> spawnPositions = new List<Transform>();




    public List<GameObject> rewards = new List<GameObject>();






    void Awake()
    {
        if (null == instance)      //�� �̵� �� �ش� ���� �̹� GameManager ������Ʈ �ν��Ͻ��� ������ �� �ش���� �ν��Ͻ��� �����ϰ� �� �ν��Ͻ��� �����
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


        for (int i = 0; i < spawnPositionsRoot.childCount; i++) //������Ʈ ȣ����ġ ���� �Լ�
        {
            spawnPositions.Add(spawnPositionsRoot.GetChild(i));
        }


    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public void Start()
    {
        time = 0f;
        Time.timeScale = 1f;

        StartCoroutine("StartNextWave", 0f);

        InvokeRepeating("MakeMeteor", 0f, 0.5f);
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
    }


    private void MakeMeteor()
    {
        Instantiate(MeteorA);
        Instantiate(MeteorB);
        Instantiate(MeteorC);
        Instantiate(MeteorD);
    }












    IEnumerator StartNextWave() //�ð����� �Լ� �� �Լ��� ���õ� ������Ʈ ȣ��
    {
        while(true)
        {
            if(currentSpawnCount == 0)
            {
                yield return new WaitForSeconds(5f);

                if(currentWaveIndex % 10 == 0)
                {
                    waveSpawnPosCount = waveSpawnPosCount + 1 > spawnPositions.Count ? waveSpawnPosCount : waveSpawnPosCount + 1;
                    waveSpawnCount = 0;
                }

                if (currentWaveIndex % 5 == 0)
                {
                    
                }

                if(currentWaveIndex % 3 == 0)
                {
                    waveSpawnCount += 1;
                    
                }


                if (currentWaveIndex % 5 == 0)
                {
                    CreateReward();
                    
                }

               




                for (int i = 0; i < waveSpawnCount; i++)
                {
                    int posIdx = Random.Range(0, spawnPositions.Count);
                    for(int j = 0; j < waveSpawnCount; j++)
                    {
                        //int prefabIdx = Random.Range(0, blueshielditemPrefabs.Count);
                        //GameObject blueshielditem = Instantiate(blueshielditemPrefabs[prefabIdx], spawnPositions[posIdx].position, Quaternion.identity);
                        //currentSpawnCount++;
                    }
                }



            }
            yield return null;
        }
    }

    


    void CreateReward() //������ ȣ��
    {
        int idx = Random.Range(0, rewards.Count);
        int posIdx = Random.Range(0, spawnPositions.Count);

        GameObject obj = rewards[idx];
        Instantiate(obj, spawnPositions[posIdx].position, Quaternion.identity);
    }







}