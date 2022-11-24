using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    public int itemCount;
    public GameObject itemObject; // �����ϰ� ���� ���ӿ�����Ʈ
    

    public Item item;
    public Image itemImage; // �����ϰ� ���� ���� �̹���

    [SerializeField]
    private Text text_Count;  // ��� �ؽ�Ʈ
    [SerializeField]
    private GameObject go_CountImage; // �ؽ�Ʈ�� �� �ڽ�

    private void SetColor(float _alpha)  // ���� �̹��� ���� ����
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }



    private void Awake()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
    }
   

   

    private void OnTriggerEnter(Collider col) //Ʈ���ſ� ������
    {
        if (col.tag == "Player") // �������� �÷��̾���
        {
            

                for (int i = 0; i < inventory.slots.Length; i++) 
                {

                    if (inventory.fullCheck[i] == false) // �κ��丮 i��°�� ������ ���ٸ�
                    {
                        inventory.fullCheck[i] = true; // true�� üũ

                        //Instantiate(itemObject, inventory.slots[i].transform, false); 
                        // gameObject ���� ���� �������̹��� ����
                        //Instantiate(go_CountImage, inventory.slots[i].transform, false);
                        // ����ī��Ʈ �̹��� ����



                        Destroy(gameObject); // ���� ����

                        break;
                    }


                }
            
        }
    }

    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        go_CountImage.SetActive(false);
        text_Count.text = "0";
    }


    
}
