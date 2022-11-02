using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range; // ���� ������ �ִ� �Ÿ�

    private bool pickupActivated = false; //���� ������ �� true

    private RaycastHit hitInfo; //�浹ü ���� ����

    // ������ ���̾�� �����ϵ��� ���̾� ����ũ�� ����
    [SerializeField]
    private LayerMask layerMask;

    // �ʿ��� ������Ʈ
    [SerializeField]
    private Text actionText; //���¿��� 1��Ī ������ �ؽ�Ʈ�� �ϴ� ���� (https://youtu.be/bAfCxYH0TG0)



    // Update is called once per frame
    void Update()
    {
        TryAction();
    }

    private void TryAction() //EŰ�� ������ ȹ��
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickup();
        }
    }

    private void CanPickup() // ������ ȹ�� ������ �Ǹ� ���ڸ� �����
    {
        if(pickupActivated)
        {
            if(hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "get");
                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
            }
        }
    }
    private void CheckItem() // �±װ� ���������� Ȯ���Ѵ�.
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoApper();
            }
        }
        else
            InfoDisappear();
    }

    private void ItemInfoApper() 
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "get" + "<color=yellow>" + "(E)" + "</color>";
    }

    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
}
