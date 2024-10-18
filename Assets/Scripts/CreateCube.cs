using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
  
    [SerializeField] private GameObject[] boxPrefab = new GameObject[2];
    [SerializeField] private float createTimer;

    private Coroutine boxCreateCo;

    //�⺻ �ڽ� ���� ��ġ 0, 1, -23
    //�� ���� ���� �����Ǹ� ���� ��������
    //���� ������ �ڽ��̸� ��, �Ʒ� �پ
    //�ٸ� ������ �ڽ��̸� ��, �� ��������
    private Vector3 offset = new Vector3(0, 2, 0);
    private float[] xPosArr = { -1.5f, -0.5f, 0.5f, 1.5f };


    //�ڽ� ��ũ��Ʈ�� �ڽ� ������ ����
    //�ڽ� ��ũ��Ʈ���� Onenable �Ǹ� 
    //�ڽ� ���� ���� �� ������ �������� ����?
   

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

        //������ ����Ǹ� �ڷ�ƾ �����ϸ� �ɵ�
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
    