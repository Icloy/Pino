using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Itemm : ScriptableObject
{

    public string itemName; // �������� �̸�
    public ItemType itemType; // �������� ����
    public Sprite itemImage; // �������� �̹���
    public GameObject itemPrefab; // �������� ������

    public string weaponType; // ���� ����

    public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        ETC
    }


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}