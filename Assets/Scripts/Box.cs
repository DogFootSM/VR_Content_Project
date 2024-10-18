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

        //�ڽ� �÷� �ε���
        colorIndex = Random.Range(0, (int)BoxColor.SIZE);

        //������ �ڽ� Color
        MeshRenderer.material = materials[colorIndex];

        //���� �ڽ� Color
        boxColor = (BoxColor)colorIndex;
         
    }
     

    public void SetDirImage()
    {
        //���⿡ �°� ��ġ ����
    }


}
