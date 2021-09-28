// https://qiita.com/Nekomasu/items/f526b9392fd16f2bd243?utm_source=pocket_mylist
// https://qiita.com/uroshinse/items/b167a411ce2168e0c5a0
// https://xr-hub.com/archives/9268
// http://negi-lab.blog.jp/Dakou
// http://corevale.com/unity/7206
// https://light11.hatenadiary.com/entry/2019/03/24/013917
// https://qiita.com/4_mio_11/items/c90767b62d1cc5b9eddf

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMotion : MonoBehaviour {
    // T:1回上下するのに要する時間
    [Header("周期（一周期に要する時間）")]
    [SerializeField] [RangeAttribute(0,50)] private float Speed = 1.0f;
    private enum MoveType
    {
        HORIZONTAL = 0,  // 水平運動
        VERTICAL = 1,   // 垂直運動
        ROTATION = 2,  // 円運動
    }
    [TooltipAttribute("動きの種類を選択")]
    [SerializeField] private MoveType moveType = MoveType.HORIZONTAL;
    void Start()
    {
        defPosition = transform.position;
    }
    void Update ()
    {
        float sin = Col_sin();
        float cos = Col_cos();
        switch ( moveType ){
            case MoveType.VERTICAL:
                VerticalMove(sin);
                break;
            case MoveType.HORIZONTAL:
                HorizontalMove(sin);
                break;
            case MoveType.ROTATION:
                RotateMove();
                break;
        }
    }
    public float Col_sin()
    {
        // float sin = Mathf.Sin(Time.time);
        float T = Speed;
        float f = 1.0f / T;
        float sin = Mathf.Sin(2 * Mathf.PI * f * Time.time);
        return sin;
    }
    public float Col_cos()
    {
        // float sin = Mathf.Sin(Time.time);
        float T = Speed;
        float f = 1.0f / T;
        float cos = Mathf.Cos(2 * Mathf.PI * f * Time.time);
        return cos;
    }
    // 上下の直線運動
    public void VerticalMove(float sin)
    {
        this.transform.position = new Vector3(0,sin,0);
    }
    // 左右の直線運動
    public void HorizontalMove(float sin)
    {
        this.transform.position = new Vector3(sin,0,0);
    }
    // 円運動
    [Header("円運動の半径")]
    //[SerializeField, RangeAttribute(0,100), EnabledIf("_example", (int)MoveType.ROTATION, EnabledIfAttribute.HideMode.Invisible)]
    [SerializeField]
    private int radius = 2;
    private Vector3 defPosition;
    public void RotateMove()
    {
        float T = Speed;
        float f = 1.0f / T;
        float sin = radius * Mathf.Sin(2 * Mathf.PI * f * Time.time);
        float cos = radius * Mathf.Cos(2 * Mathf.PI * f * Time.time);
        this.transform.position = new Vector3(defPosition.x + sin,defPosition.y + cos,defPosition.z);
    }
}