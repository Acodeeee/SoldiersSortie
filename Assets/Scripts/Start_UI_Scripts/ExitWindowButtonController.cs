/*
 * ExitWindowButtonController.cs
 * 
 * Create by WRF
 */

using UnityEngine;
using System.Collections.Generic;

public class ExitWindowButtonController : MonoBehaviour {
    public List<GameObject> buttonList;

    Vector3 oldPosition;    //窗口原始位置
    MainButtonController mainButtonController;  //用于使Button的Collider有效

    void Start()
    {
        oldPosition = transform.localPosition;
        mainButtonController = GameObject.FindWithTag(Tags.MainButton).GetComponent<MainButtonController>();

        InitButton();
    }
    
    void InitButton(){
        foreach(var item in buttonList){
            switch(item.name){
                case R.YesBtn:
                    UIEventListener.Get(item).onClick = go =>{
                        //退出游戏
                        Application.Quit();
                    };
                    break;

                case R.NoBtn:
                    UIEventListener.Get(item).onClick = go =>{
                        mainButtonController.ApproveCollider();
                        //关闭ConfirmWindow，添加一个TweenPosition组件
                        TweenPosition tween = gameObject.AddComponent<TweenPosition>();
                        tween.from = transform.localPosition;
                        tween.to = oldPosition;
                        tween.duration = 0.5f;
                        tween.PlayForward();
                        Destroy(tween,2f);
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
