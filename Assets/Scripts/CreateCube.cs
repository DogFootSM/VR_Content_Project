using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
  
    [SerializeField] private GameObject[] boxPrefab = new GameObject[2];
    [SerializeField] private float createTimer;

    private Coroutine boxCreateCo;

    //기본 박스 생성 위치 0, 1, -23
    //두 개가 같이 생성되면 같은 방향으로
    //같은 색상의 박스이면 위, 아래 붙어서
    //다른 색상의 박스이면 좌, 우 떨어져서
    private Vector3 offset = new Vector3(0, 2, 0);
    private float[] xPosArr = { -1.5f, -0.5f, 0.5f, 1.5f };


    //박스 스크립트에 박스 데이터 저장
    //박스 스크립트에서 Onenable 되면 
    //박스 생성 개수 및 색깔을 랜덤으로 지정?
   

    void Start()
    {
        boxCreateCo = StartCoroutine(CreateCoroutine());
    }

    private void Update()
    {
        
    }


    private IEnumerator CreateCoroutine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(createTimer);

        //게임이 종료되면 코루틴 중지하면 될듯
        while (true)
        {
            float xPos = Random.Range(0, 1);
            float zPos = Random.Range(0, 2);
            offset = new Vector3(0,0,0);

            GameObject instance = Instantiate(boxPrefab[Random.Range(0, 2)], transform.position +offset, transform.rotation);

            yield return waitTime;
            
            Destroy(instance);
        }

         
    }


}
    