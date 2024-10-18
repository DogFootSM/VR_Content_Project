using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Material[] materials;

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
     

    public void SetDirImage()
    {
        //방향에 맞게 위치 변경
    }


}
