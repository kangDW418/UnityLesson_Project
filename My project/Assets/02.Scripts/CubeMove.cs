using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    // public ���������ڸ� ����ϸ� Inspector â�� ������ �ȴ�
    // ���࿡ �ٸ� Ŭ�����κ����� ���ٱ� �����ϸ鼭 Inspertor â�� �����Ű�� ������ [SerializeField] �Ӽ��� ����Ѵ�.

    [SerializeField] private float speed = 1;
    [SerializeField] private float roateSpeed = 1;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();


        // trasform�� �����ؼ� ��ǥ�� ���� �����͸� ������ѵ� ������ ���� Transform ������� tr�� �����ؼ�
        // Trasnform component �� ������ �Ŀ� ����ϴ� ����
        // ĳ�� �޸� ���� ����
        // transform�� ����ϸ� �� ��������� ȣ���� �� ���� gameObject�� �����ؼ� getComponent�� Transform ������ ������
        // ������ Transform ������� tr���ٰ� �ѹ� �־���� ����ϸ�
        // tr�� ����� �� ���� ó���� �־���� Transform component  �� �ٷ� �����ϱ� ������
        // ���ÿ� ���� ���� ���ӿ��귺Ʈ���� Transform������Ʈ ����ϸ� �׶��� �����ս����� ���̰� ����.

        tr = this.gameObject.GetComponent<Transform>(); // �� Ŭ������ �����ϴ� ���� ������Ʈ���Լ� Transfrom ������Ʈ�� �����´�.
    }

    // Update is called once per frame
    void Update()
    {
        // Position
        // ==========================================================================

        //z �� �����Ӵ� z �� 1 ����

        // ���࿡ 60FPS, 30FPS ��Ⱑ �ִٸ�
        // 60FPS �� 1�ʿ� 60��ŭ, 30FPS�� 1�ʿ� 30��ŭ �̵���
        //tr.position += new Vector3(0, 0, 1);

        //���� �����Ӱ� ���� �������ӻ��� �ɸ� �ð�
        // Time.dataTime�� �����ָ� ��⼺�ɿ� ������� ���� ���� ��ȭ���� ���� ���ִ�.
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

        //Vector3 movePos = new Vector3(h, 0, v) * speed * Time.deltaTime;  // ���ÿ� ����������(�밢��) ���������� ���� ������ ũŰ�� 1�� �Ѿ�� �ӵ��� �������� �ʴ�.

        //tr.Translate(movePos);
        // �ٸ� Ŭ������ ������ ���� �ٲٱ� ���� �Լ��� �����ϴ°��� �� ���� �ڵ��̴�.
        //tr.position= Vector3.forward

        // Vector ����� ũ�⸦ ��� ������ ����
        // Ư�� Veotor ũ�Ⱑ 1�� ���͸� �������� (Unit Vector)
        // �����̰� ���� ���⿡ ���� �������� * �ӵ� �� ��ü�� ������

        Vector3 dir = new Vector3(h, 0, v).normalized;   // ���⿡ ���� Vector
        Vector3 moveVec = dir * speed * Time.deltaTime;
        //tr.Translate(moveVec);

        //tr.Translate(moveVec, Space.Self);  // local ��ǥ�� ���� �̵�
        tr.Translate(-dir, Space.World); // World ��ǥ�� ���� �̵�


        // Rotation
        // =========================================================================
        tr.Rotate(new Vector3(0f, 30f, 0f)); // Y ������ 30 radian ��ŭ ȸ���϶�. Degree 0~360 ���� ��Ÿ���� ����

        float r = Input.GetAxis("Mouse X");
        Vector3 rotateVec = Vector3.up * roateSpeed * r * Time.deltaTime;
        tr.Rotate(rotateVec);
       
    }
}

