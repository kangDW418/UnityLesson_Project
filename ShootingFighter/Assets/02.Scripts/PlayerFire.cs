using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //-------- ��� 1, �Ѿ��� �ѱ��� �����Ѵ� -----------
            Instantiate(bullet, firePoint);
            firePoint.DetachChildren();

            /*//-------- ��� 2, �Ѿ��� ������ �Ŀ� �ѱ� ��ġ�� ���� ���´� --------
            // GameObject�� �ν��Ͻ�ȭ 
            GameObject tmpBullet = Instantiate(bullet);
            // Ŭ������ �ν��Ͻ�ȭ :
            // Ŭ����Ÿ�� �����̸� = new Ŭ����������
            tmpBullet.transform.position = firePoint.position;
            tmpBullet.transform.rotation = firePoint.rotation;*/
        }
    }
}