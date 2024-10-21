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
        //���� ���� && boxCreateCo != null > stopcoroutine
    }   

    private IEnumerator CreateCoroutine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(createTimer);
        GameObject[] instance;
        Box[] boxList;
        int createCount = 0;

        //������ ����Ǹ� �ڷ�ƾ �����ϸ� �ɵ�
        //������ ���� ������ ������ �ݺ��� ����
        while (true)
        {
            createCount = Random.Range(1, 3);
            instance = new GameObject[createCount];
            boxList = new Box[createCount];

            for (int i = 0; i <createCount; i++)
            { 
                //������ �ڽ� ȸ������ ���� ��ġ�� �ݿ�
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

                //ù ��° ���� Ÿ�� ����
                boxList[0].BoxDir = (BoxDir)Random.Range(0, (int)BoxDir.SIZE);
 
                //ù ��° ���� ������ ��
                instance[0].transform.position = new Vector3(spawnPos.x + xPos, spawnPos.y, spawnPos.z);

                //������ �ٸ� �ڽ��� ������ ����
                if (!boxColorCheck)
                { 
                    for (int i = 1; i < createCount; i++)
                    { 
                        xPos = Random.Range(-2, 2);

                        //ù ��° ���ڿ� xPos �� ������ xPos �ٽ� ����
                        if (instance[i - 1].transform.position.x == spawnPos.x + xPos)
                        {
                            i--; 
                        }
                        else
                        {
                            //���� ���ڵ�� �ٸ� ��ġ�� ����
                            boxList[i].BoxDir = (BoxDir)Random.Range(0, (int)BoxDir.SIZE); 
                            instance[i].transform.position = new Vector3(spawnPos.x + xPos, spawnPos.y, spawnPos.z);
                            
                        }
                    }

                }
                //������ ������ ������ ���� ���
                else
                {
                    float yPos = 0.5f;

                    for (int i = 1; i < createCount; i++)
                    {
                        //���� �ڽ� ���� ����
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
    