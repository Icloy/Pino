using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Player : MonoBehaviour
{
    GameObject nearObject;

    bool iDown;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Interation();
    }

    void GetInput()
    {
        iDown = Input.GetButtonDown("Interation");
    }

    void Interation()
    {
        if (iDown && nearObject != null) //���ӿ�����Ʈ�� ��ó�� �������
        {

            Destroy(nearObject);//���ӿ�����Ʈ�� �����Ѵ�.
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Weapon")
        {
            
            nearObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weapon")
        {
            nearObject = null;
        }
    }


}
