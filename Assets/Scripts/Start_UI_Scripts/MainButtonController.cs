/*
 * ButtonListController.cs
 * 开始界面，Start, Help, Exit三个按钮的点击事件
 * Create by WRF
 */

using UnityEngine;
using System.Collections.Generic;

public class MainButtonController : MonoBehaviour {

    public List<GameObject> buttonList;
    public GameObject HelpWindow;       //帮助界面对象
    public GameObject content;       //内容组件

    List<CapsuleCollider> colliderList;     //三个button的Collider组件，用于点击后取消button的点击作用
    GameObject LevelWindow;                  //LevePanellWindow组件
    GameObject confirmWindow;
    Vector3 targetPosition;                    //ConfirmWindow的原始位置

    


    void Awake()
    {
        LevelWindow = GameObject.FindWithTag(Tags.LevelPanel);

        confirmWindow = GameObject.FindWithTag(Tags.ConfirmWindow);
        targetPosition = new Vector3(-142, -25, 0);

        colliderList = new List<CapsuleCollider>();
        //获取到每个button的Collider组件
        foreach(var item in buttonList){
            colliderList.Add(item.GetComponent<CapsuleCollider>());
        }
    }

    void Start(){
        InitButton();
    }
	//绑定三个button的点击事件
    void InitButton(){
        foreach(var item in buttonList){
            switch(item.name){
                case R.StartBtn:
                    //Start
                    UIEventListener.Get(item).onClick = go =>{
                        CancelCollider();
                        LevelWindow.AddComponent<RotateSelf>();
                    };
                    break;
                
                case R.HelpBtn:
                    //Help
                    UIEventListener.Get(item).onClick = go =>{
                        CancelCollider();
                        HelpWindow.SetActive(true);
                        content.AddComponent<ContentOutput>();
                    };

                    break;

                case R.ExitBtn:
                    //Exit
                    UIEventListener.Get(item).onClick = go =>{
                        //打开ConfirmWindow，添加一个TweenPosition组件
                        CancelCollider();
                        TweenPosition tween = confirmWindow.AddComponent<TweenPosition>();
                        tween.from = confirmWindow.transform.localPosition;
                        tween.to = targetPosition;
                        tween.duration = 0.5f;
                        tween.PlayForward();
                        Destroy(tween,2f);
                    };

                    break;
            }
        }
    }
    //取消Collider
    void CancelCollider(){
        foreach(var item in colliderList){
            item.enabled = false;
        }
    }
    //勾选Collider,用于给外部调用
    public void ApproveCollider(){
        foreach(var item in colliderList){
            item.enabled = true;
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
