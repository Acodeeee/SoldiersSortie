/*
 * HelpWindowButtonController.cs
 * 
 * Create by WRF
 */

using UnityEngine;
using System.Collections.Generic;

public class HelpWindowButtonController : MonoBehaviour {
    public List<GameObject> buttonList;
    public GameObject content;

    MainButtonController mainButtonController;

    void Start()
    {
        mainButtonController = GameObject.FindWithTag(Tags.MainButton).GetComponent<MainButtonController>();
        InitButton();
    }

    void InitButton(){
        foreach(var item in buttonList){
            switch(item.name){
                case R.CancelBtn:
                    UIEventListener.Get(item).onClick = go => {
                        Destroy(content.GetComponent<ContentOutput>());
                        content.GetComponent<UILabel>().text = "";
                        gameObject.SetActive(false);
                        mainButtonController.ApproveCollider();//   开启Main按钮碰撞体
                    };
                    break;

                case R.SkipBtn:
                    UIEventListener.Get(item).onClick = go =>{
                        content.GetComponent<ContentOutput>().isSkip = true;
                    };
                    break;
            }
        }
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
