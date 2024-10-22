using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;


public class Box : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Material[] materials;
    [SerializeField] private ParticleSystem destroyEffect;
    [SerializeField] private GameObject dirObject;

    private MeshRenderer MeshRenderer;

    private BoxDir boxDir;
    public BoxDir BoxDir { get { return boxDir; } set { boxDir = value; } }

    private BoxColor boxColor;
    public BoxColor curBoxColor { get { return boxColor; } }

    private int colorIndex;
 
    private void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();  
    }
     

    private void OnEnable()
    {
        SetBoxInfo(); 
    }

    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
        SetDirObjectPos();

        //게임 중도 포기 시 생성되어 있는 Box 삭제
        if(GameManager.Instance.curState == GameState.End)
        {
            Destroy(gameObject);
        }

    }

    private void SetBoxInfo()
    {

        //박스 컬러 인덱스
        colorIndex = Random.Range(0, (int)BoxColor.SIZE);

        //생성될 박스 Color
        MeshRenderer.material = materials[colorIndex];

        //현재 박스 Color
        boxColor = (BoxColor)colorIndex; 
    }
     

    /// <summary>
    /// 박스 삭제 후 동작
    /// </summary>
    /// <param name="hitPoint">박스 피격 위치</param>
    public void DestroyBox(Vector3 hitPoint)
    {
        ParticleSystem destroyEffect = Instantiate(this.destroyEffect, hitPoint, transform.rotation);
        
        //박스 삭제 파티클 재생
        destroyEffect.Play();
        Destroy(gameObject);
    }


    public void SetDirObjectPos()
    {
        //방향에 맞게 위치 변경
        switch (boxDir)
        {
            case BoxDir.Up:
                dirObject.transform.localPosition = new Vector3(0, 0.3f, 0.5f);
                break;

            case BoxDir.Down:
                dirObject.transform.localPosition = new Vector3(0, -0.3f, 0.5f);
                break;

            case BoxDir.Left:
                dirObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                dirObject.transform.localPosition = new Vector3(0.3f, 0f, 0.5f);
                break;

            case BoxDir.Right: 
                dirObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                dirObject.transform.localPosition = new Vector3(-0.3f, 0f, 0.5f);
                break; 
        } 
    }

    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.CompareTag("EndLine"))
        { 
            Destroy(gameObject);
        } 
    }



}
