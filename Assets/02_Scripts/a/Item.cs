using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    public int itemCount;
    public GameObject itemObject; // 복사하고 싶은 게임오브젝트
    

    public Item item;
    public Image itemImage; // 복사하고 싶은 게임 이미지

    [SerializeField]
    private Text text_Count;  // 띄울 텍스트
    [SerializeField]
    private GameObject go_CountImage; // 텍스트가 들어갈 박스

    private void SetColor(float _alpha)  // 게임 이미지 투명도 조절
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }



    private void Awake()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
    }
   

   

    private void OnTriggerEnter(Collider col) //트리거에 닿으면
    {
        if (col.tag == "Player") // 닿은것이 플레이어라면
        {
            

                for (int i = 0; i < inventory.slots.Length; i++) 
                {

                    if (inventory.fullCheck[i] == false) // 인벤토리 i번째에 옵젝이 없다면
                    {
                        inventory.fullCheck[i] = true; // true로 체크

                        //Instantiate(itemObject, inventory.slots[i].transform, false); 
                        // gameObject 생성 라인 아이템이미지 띄우기
                        //Instantiate(go_CountImage, inventory.slots[i].transform, false);
                        // 갯수카운트 이미지 띄우기



                        Destroy(gameObject); // 옵젝 삭제

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
