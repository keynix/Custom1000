using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hp : MonoBehaviour
{
    [SerializeField]
    private int HP;

    //  [SerializeField]
    private int ShotNolmal_Lv1 = 2;

    //  [SerializeField]
    private int ShotNolmal_Lv2 = 10;

    // [SerializeField]
    private int ShotPenetrationLv1 = 1;

    private SpriteRenderer col = null;
    private bool Color_red = false;
    private float Color_red_count = 0.0f;

    [SerializeField]
    private int R;
    [SerializeField]
    private int G;
    [SerializeField]
    private int B;


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SpriteRenderer>();
        col.color = new Color(R, G, B, 1);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(HP);

        if (HP < 0)
        {
            //武器のレベルアップポイント
            CPData.ArmShot_norml_Lv += 1;
            Destroy(this.gameObject);
        }

        Color_cheng();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //
        if (other.gameObject.tag == "Bullet")
        {
            HP -= ShotNolmal_Lv1;
        }
        if (other.gameObject.tag == "Bullet2")
        {
            HP -= ShotNolmal_Lv2;
        }
        if (other.gameObject.tag == "Penetration_Bullet")
        {
            //壁を貫通した弾ならダメージアップするようにする
            HP -= ShotPenetrationLv1;
        }

        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Bullet2" ||
       other.gameObject.tag == "Penetration_Bullet")
        {

            Color_red = true;
        }


    }



    private void OnTriggerStay2D(Collider2D other)
    {
       

        //if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Bullet2" ||
        //other.gameObject.tag == "Penetration_Bullet")
        //{

        //    Color_red = true;
        //}


    }

    void Color_cheng()
    {
        if (Color_red)
        {

            col.color = new Color(1, 0, 0, 1);


            //一瞬の赤色変換
            Color_red_count += Time.deltaTime;
            if (Color_red_count > 0.2f)
            {

                Color_red = false;
            }

        }
        else
        {

            col.color = new Color(R, G, B, 1);


            Color_red_count = 0.0f;

        }
    }



}
