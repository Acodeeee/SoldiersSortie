/*
 * LevelWindowButtonController.cs
 * 
 * Create by WRF
 */

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelWindowButtonController : MonoBehaviour {

    public List<GameObject> buttonList;

    MainButtonController mainButtonController;
    Vector3 oldPosition;

    void Start(){
        mainButtonController = GameObject.FindWithTag(Tags.MainButton).GetComponent<MainButtonController>();
        oldPosition = transform.localPosition;

        InitButton();
    }

    void InitButton(){
        foreach(var item in buttonList){
            switch(item.name){
                case R.BackBtn:
                    UIEventListener.Get(item).onClick = go =>{
                        StartCoroutine(WindowDown());
                    };

                    break;
            }
        }
    }

    //LevelWindow自由落体，1s后销毁刚体组件，并且LevelWindow归位
    IEnumerator WindowDown()
    {
        Rigidbody rig = gameObject.AddComponent<Rigidbody>();

        yield return new WaitForSeconds(1f);

        Destroy(rig);
        transform.Rotate(0, 0, -60);
        transform.localPosition = oldPosition;

        mainButtonController.ApproveCollider();
    }
	
}

/**
*　　　　　　　　┏┓　　　┏┓+ +
*　　　　　　　┏┛┻━━━┛┻┓ + +
*　　　　　　　┃　　　　　　　┃ 　
*　　　　　　　┃　　　━　　　┃ ++ + + +
*　　　　　　 ████━█████+
*　　　　　　　┃　　　　　　　┃ +
*　　　　　　　┃　　　┻　　　┃
*　　　　　　　┃　　　　　　　┃ + +
*　　　　　　　┗━┓　　　┏━┛
*　　　　　　　　　┃　　　┃　　　　　　　　　　　
*　　　　　　　　　┃　　　┃ + + + +
*　　　　　　　　　┃　　　┃　　　　Code is far away from bug with the animal protecting　　　　　　　
*　　　　　　　　　┃　　　┃ + 　　　　神兽保佑,代码无bug　　
*　　　　　　　　　┃　　　┃
*　　　　　　　　　┃　　　┃　　+　　　　　　　　　
*　　　　　　　　　┃　 　　┗━━━┓ + +
*　　　　　　　　　┃ 　　　　　　　┣┓
*　　　　　　　　　┃ 　　　　　　　┏┛
*　　　　　　　　　┗┓┓┏━┳┓┏┛ + + + +
*　　　　　　　　　　┃┫┫　┃┫┫
*　　　　　　　　　　┗┻┛　┗┻┛+ + + +
*/
