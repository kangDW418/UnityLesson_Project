using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    // public 접근제한자를 사용하면 Inspector 창에 노출이 된다
    // 만약에 다른 클래스로부터의 접근근 제한하면서 Inspertor 창에 노출시키고 싶으면 [SerializeField] 속성을 사용한다.

    [SerializeField] private float speed = 1;
    [SerializeField] private float roateSpeed = 1;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();


        // trasform에 접근해서 좌표에 대한 데이터를 변경시켜도 되지만 굳이 Transform 멤버변수 tr을 선언해서
        // Trasnform component 를 대입한 후에 사용하는 이유
        // 캐시 메모리 문제 때문
        // transform을 사용하면 이 멤버변수를 호출할 때 마다 gameObject에 접근해서 getComponent로 Transform 성분을 가져옴
        // 하지만 Transform 멤버변수 tr에다가 한번 넣어놓고 사용하면
        // tr은 사용할 때 마다 처음에 넣어줬던 Transform component  에 바로 접근하기 때문에
        // 동시에 아주 많은 게임오브렉트들의 Transform컴포넌트 써야하면 그때는 퍼포먼스에서 차이가 난다.

        tr = this.gameObject.GetComponent<Transform>(); // 이 클래스를 포함하는 게임 오브젝트에게서 Transfrom 컴포넌트를 가져온다.
    }

    // Update is called once per frame
    void Update()
    {
        // Position
        // ==========================================================================

        //z 축 프레임당 z 축 1 전진

        // 만약에 60FPS, 30FPS 기기가 있다면
        // 60FPS 는 1초에 60만큼, 30FPS는 1초에 30만큼 이동함
        //tr.position += new Vector3(0, 0, 1);

        //직전 프레임과 현재 ㅍ프레임사이 걸린 시간
        // Time.dataTime을 곱해주면 기기성능에 관계없이 포당 같은 변화량을 가질 수있다.
        //tr.position += new Vector3(0, 0, 1) * Time.deltaTime;

        // tr.position -= new Vector3(0, 0, 1) * FixedUpdate;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log("h = " + h);
        Debug.Log($"v = {v}");


        //  Z axis forwar, backward
        //  X axis left, right
        //  Y axis up, down
        // tr.position += new Vector3(h, 0, v) * Time.deltaTime * speed;

        //Vector3 movePos = new Vector3(h, 0, v) * speed * Time.deltaTime;  // 동시에 여러축으로(대각선) 움직였을때 방향 백터의 크키가 1이 넘어가서 속도가 일정하지 않다.

        //tr.Translate(movePos);
        // 다른 클래스의 변수를 직접 바꾸기 보단 함수로 접근하는것이 더 좋은 코드이다.
        //tr.position= Vector3.forward

        // Vector 방향과 크기를 모두 가지는 성질
        // 특히 Veotor 크기가 1인 백터를 단위벡터 (Unit Vector)
        // 움직이고 싶은 방향에 대한 단위벡터 * 속도 로 물체를 움직임

        Vector3 dir = new Vector3(h, 0, v).normalized;   // 방향에 대한 Vector
        Vector3 moveVec = dir * speed * Time.deltaTime;
        //tr.Translate(moveVec);

        //tr.Translate(moveVec, Space.Self);  // local 좌표계 기준 이동
        tr.Translate(-dir, Space.World); // World 좌표게 기준 이동


        // Rotation
        // =========================================================================
        tr.Rotate(new Vector3(0f, 30f, 0f)); // Y 축으로 30 radian 만큼 회전하라. Degree 0~360 까지 나타내는 단위

        float r = Input.GetAxis("Mouse X");
        Vector3 rotateVec = Vector3.up * roateSpeed * r * Time.deltaTime;
        tr.Rotate(rotateVec);
       
    }
}

