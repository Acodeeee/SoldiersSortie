/*
 * RotateSelf.cs
 * Level面板摇摆入场
 * Create by WRF
 */

using UnityEngine;
using System.Collections;

public class RotateSelf : MonoBehaviour {

    public float rotateSpeed = 2f;

    Vector3 eulerAngles;        //欧拉角，面板旋转的角度
    float newZ = -60f;          //根据z轴的旋转角度，不断更新
    float MaxZ = 60f;           //最大旋转角度，不断更新
    bool isClockwise = false;   //是否顺时针旋转
    

    void Start()
    {
        
    }

    void Update()
    {
        Sway();

    }
    //面板摇摆
    void Sway(){
        MaxZ -= 0.3f;
        if(MaxZ < 1){
            rotateSpeed = 0f;
            Destroy(this);      //旋转停下，销毁自己
        }
        //超过第三象限界限
        if(newZ < -MaxZ){
            isClockwise = true;
        //超过第四象限界限
        }else if(newZ > MaxZ){
            isClockwise = false;
        }
        if(isClockwise){
            newZ += rotateSpeed;
            eulerAngles = new Vector3(0, 0, newZ);
        }else{
            newZ -= rotateSpeed;
            eulerAngles = new Vector3(0, 0, newZ);
        }
        transform.rotation = Quaternion.Euler(eulerAngles);
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
