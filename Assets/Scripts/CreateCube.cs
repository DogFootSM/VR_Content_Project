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
    private float elapsedTime = 0f;

    private Coroutine boxCreateCo;
    private Vector3 spawnPos;
    

    private void Awake()
    {
        spawnPos = transform.position;
    }
 
    private void Update()
    {

        if(GameManager.Instance.curState == GameState.Start)
        {
            //노래 재생 시간
            elapsedTime += Time.deltaTime;

            //박스 생성 코루틴 시작
            if (boxCreateCo == null)
            { 
                boxCreateCo = StartCoroutine(CreateCoroutine());
            } 
        } 
        else if(GameManager.Instance.curState == GameState.End)
        {
            elapsedTime = 0f;

            //박스 생성 코루틴 종료
            if(boxCreateCo != null)
            {
                StopCoroutine(boxCreateCo);
                boxCreateCo = null;
            } 
        }
        
    }



    private IEnumerator CreateCoroutine()
    {
        int createCount = 0;

        float startTimer = 3f; 
        //재생할 노래의 총 길이
        float endTime = SoundManager.Instance.GetPlayTime();

        WaitForSeconds startWait = new WaitForSeconds(startTimer);
        WaitForSeconds waitTime = new WaitForSeconds(createTimer);
        GameObject[] instance;
        Box[] boxList;
         
        

        yield return startWait;

        //노래 끝나기 5초 전에 큐브 생산 종료
        while (elapsedTime < endTime - 5f)
        {
            //한번 생성할 박스 개수
            createCount = Random.Range(1, 3);
            instance = new GameObject[createCount];
            boxList = new Box[createCount];
 
            for (int i = 0; i <createCount; i++)
            { 
                //생성될 박스 회전값만 스폰 위치로 반영
                instance[i] = Instantiate(boxPrefab, Vector3.zero, transform.rotation);
                boxList[i] = instance[i].GetComponent<Box>();
            }
            
            //박스 2개 이상 생성 
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
                    float yPos = 0.8f;

                    for (int i = 1; i < createCount; i++)
                    {
                        //이전 박스 위에 생성
                        boxList[i].BoxDir = boxList[0].BoxDir;
                        instance[i].transform.position = new Vector3(spawnPos.x + xPos, spawnPos.y + yPos, spawnPos.z);
                        yPos += 0.8f;
                    }

                }
            }
            //박스 1개 생성
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
    