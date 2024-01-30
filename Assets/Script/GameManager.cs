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
        if (null == instance)      //씬 이동 시 해당 씬에 이미 GameManager 오브젝트 인스턴스가 존재할 시 해당씬의 인스턴스는 삭제하고 이 인스턴스를 남긴다
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


        for (int i = 0; i < spawnPositionsRoot.childCount; i++) //오브젝트 호출위치 관련 함수
        {
            spawnPositions.Add(spawnPositionsRoot.GetChild(i));
        }


    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
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












    IEnumerator StartNextWave() //시간별로 함수 및 함수에 관련된 오브젝트 호출
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

    


    void CreateReward() //아이템 호출
    {
        int idx = Random.Range(0, rewards.Count);
        int posIdx = Random.Range(0, spawnPositions.Count);

        GameObject obj = rewards[idx];
        Instantiate(obj, spawnPositions[posIdx].position, Quaternion.identity);
    }







}