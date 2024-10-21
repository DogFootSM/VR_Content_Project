using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class CreateCube : MonoBehaviour
{

    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private float createTimer;

    private bool boxColorCheck = false;

    private Coroutine boxCreateCo;

    private Vector3 spawnPos;

    private void Awake()
    {
        spawnPos = transform.position;
    }

    void Start()
    {
        boxCreateCo = StartCoroutine(CreateCoroutine());
    }

    private void Update()
    {
        //게임 종료 && boxCreateCo != null > stopcoroutine
    }   

    private IEnumerator CreateCoroutine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(createTimer);
        GameObject[] instance;
        Box[] boxList;
        int createCount = 0;

        //게임이 종료되면 코루틴 중지하면 될듯
        //게임이 시작 상태일 때에만 반복문 실행
        while (true)
        {
            createCount = Random.Range(1, 3);
            instance = new GameObject[createCount];
            boxList = new Box[createCount];

            for (int i = 0; i <createCount; i++)
            { 
                //생성될 박스 회전값만 스폰 위치로 반영
                instance[i] = Instantiate(boxPrefab, Vector3.zero, transform.rotation);
                boxList[i] = instance[i].GetComponent<Box>();
            }
            
             
            if (createCount > 1)
            { 
                for(int i = 1; i < boxList.Length; i++)
                {
                    boxColorCheck = boxList[0].curBoxColor == boxList[i].curBoxColor;
                }

                float xPos = Random.Range(-2, 2);

                //첫 번째 상자 타격 방향
                boxList[0].BoxDir = (BoxDir)Random.Range(0, (int)BoxDir.SIZE);
 
                //첫 번째 상자 포지션 값
                instance[0].transform.position = new Vector3(spawnPos.x + xPos, spawnPos.y, spawnPos.z);

                //색깔이 다른 박스가 생성된 상태
                if (!boxColorCheck)
                { 
                    for (int i = 1; i < createCount; i++)
                    { 
                        xPos = Random.Range(-2, 2);

                        //첫 번째 상자와 xPos 가 같으면 xPos 다시 돌림
                        if (instance[i - 1].transform.position.x == spawnPos.x + xPos)
                        {
                            i--; 
                        }
                        else
                        {
                            //이전 상자들과 다른 위치에 생성
                            boxList[i].BoxDir = (BoxDir)Random.Range(0, (int)BoxDir.SIZE); 
                            instance[i].transform.position = new Vector3(spawnPos.x + xPos, spawnPos.y, spawnPos.z);
                            
                        }
                    }

                }
                //생성된 상자의 색깔이 같은 경우
                else
                {
                    float yPos = 0.5f;

                    for (int i = 1; i < createCount; i++)
                    {
                        //이전 박스 위에 생성
                        boxList[i].BoxDir = boxList[0].BoxDir;
                        instance[i].transform.position = new Vector3(spawnPos.x + xPos, spawnPos.y + yPos, spawnPos.z);
                        yPos += 0.5f;
                    }

                }
            }
            else
            {
                float xPos = Random.Range(-2, 2);
                instance[0].transform.position = new Vector3(spawnPos.x + xPos, spawnPos.y, spawnPos.z);
                boxList[0].BoxDir = (BoxDir)Random.Range(0, (int)BoxDir.SIZE);
            }
            
            yield return waitTime;
            
        }
    }


}
    