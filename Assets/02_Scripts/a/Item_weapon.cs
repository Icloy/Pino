using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_weapon : MonoBehaviour
{
    private Inventory inventory;
    public int itemCount;
    public GameObject itemObject;

    public Item item;
    public Image itemImage;

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }



    private void Awake()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {

                if (inventory.fullCheck[i] == false)
                {
                    inventory.fullCheck[i] = true;

                    Instantiate(itemObject, inventory.slots[i].transform, false);
                    // gameObject 생성 라인
                 




                    Destroy(gameObject);

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
