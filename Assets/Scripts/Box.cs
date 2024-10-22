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

        //���� �ߵ� ���� �� �����Ǿ� �ִ� Box ����
        if(GameManager.Instance.curState == GameState.End)
        {
            Destroy(gameObject);
        }

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
     

    /// <summary>
    /// �ڽ� ���� �� ����
    /// </summary>
    /// <param name="hitPoint">�ڽ� �ǰ� ��ġ</param>
    public void DestroyBox(Vector3 hitPoint)
    {
        ParticleSystem destroyEffect = Instantiate(this.destroyEffect, hitPoint, transform.rotation);
        
        //�ڽ� ���� ��ƼŬ ���
        destroyEffect.Play();
        Destroy(gameObject);
    }


    public void SetDirObjectPos()
    {
        //���⿡ �°� ��ġ ����
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
