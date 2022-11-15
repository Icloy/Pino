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
        if (iDown && nearObject != null) //게임오브젝트가 근처에 있을경우
        {

            Destroy(nearObject);//게임오브젝트를 삭제한다.
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
