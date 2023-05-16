using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercon : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movedir;


    [SerializeField]
    private float Moverpower;
    [SerializeField]
    private float Jumppower;
    [SerializeField]
    private float Rotatepower;
    // ������� ���� 
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
        Rotate();
       //LookAt();

    }
    private void Move()
    {
        // rb.AddForce(movedir*Moverpower,ForceMode.Force);
        transform.Translate(Vector3.forward*Moverpower * movedir.z * Time.deltaTime); //������ �����̰� ���� ����
        // x:1m/s      deltaTime == �����ð�����// �������Ӵ� �ɸ��½ð�
        // transform.Translate(movedir * Time.deltaTime); ������ �Ȱ���.
        // Translate �÷��̾ �ٶ󺸴� ������ �������� �����δ�;
       // transform.Translate(movedir * Time.deltaTime,Space.World); world �������� �����¿�
        //transform.Translate(movedir * Time.deltaTime, Space.Self);�ڱ� �������� �����¿�
       
        
    }
    public void Rotate()
    {
                        //Vector3.up �������� ���� �������  
        transform.Rotate(Vector3.up, movedir.x *Rotatepower * Time.deltaTime,Space.Self);
    }

    public void LookAt()
    {
        transform.LookAt(new Vector3(0, 0, 0));
    }
    // Quarternion�� rotation ������
    // <Quarternion & Euler>
    // Quarternion	: ����Ƽ�� ���ӿ�����Ʈ�� 3���� ������ �����ϰ� �̸� ���⿡�� �ٸ� ���������� ��� ȸ������ ����
    //				  �������� ȸ������ ������ ������ �߻����� ����
    // EulerAngle	: 3���� �������� ���������� ȸ����Ű�� ���
    //				  ������������ ������ ������ �߻��Ͽ� ȸ���� ��ġ�� ���� ���� �� ����
    // ������		: ���� �������� ������Ʈ�� �� ȸ�� ���� ��ġ�� ����

    // Quarternion�� ���� ȸ�������� ����ϴ� ���� ���������� �ʰ� �����ϱ� �����
    // ������ ��� ���ʹϾ� -> ���Ϸ����� -> �������� -> ������Ϸ����� -> ������ʹϾ� �� ���� ������ ��� ���ʹϾ��� �����
    public void Rotation()
    {
        // Ʈ�������� ȸ������ Euler���� ǥ���� �ƴ� Quaternion�� �����
        transform.rotation = Quaternion.identity; //identity ȸ�� ���� 000����

        // Euler������ Quaternion���� ��ȯ
        transform.rotation = Quaternion.Euler(0, 90, 0);
      //  transform.rotation.EulerAngles(); ���Ϸ� �ޱ۷κ�ȭ
    }
    public void Jump()
    {
       // rb.AddForce(Vector3.up * Jumppower,ForceMode.Impulse);
    }
    private void OnMove(InputValue Value)
    {
        movedir.x = Value.Get<Vector2>().x;
        movedir.z = Value.Get<Vector2>().y;     // y���� ���϶� z
      
    }
    private void OnJump(InputValue Value)
    {
        Jump();
    }


    // <Ʈ������ �θ�-�ڽ� ����>
    // Ʈ�������� �θ� Ʈ�������� ���� �� ����
    // �θ� Ʈ�������� �ִ� ��� �θ� Ʈ�������� ��ġ, ȸ��, ũ�� ������ ���� �����
    // �̸� �̿��Ͽ� ������ ������ �����ϴµ� ������ (ex. ���� �����̸�, �հ����� ���� ������)
    // ���̾��Ű â �󿡼� �巡�� & ����� ���� �θ�-�ڽ� ���¸� ������ �� ����
    private void TransformParent()
    {
        GameObject newGameObject = new GameObject() { name = "NewGameObject" };
        // �θ� ����
        transform.parent = newGameObject.transform;

        // �θ� ���������� Ʈ������(�θ������ �������)
        // transform.localPosition	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ��ġ
        // transform.localRotation	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ȸ��
        // transform.localScale		: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ũ��

        // �θ� ����
        transform.parent = null; // �θ�Ʈ�������� ���� ��� ���ӿ�����Ʈ�� ���� �������� ��ġ�� ��´�
        
        // ���带 ���������� Ʈ������
		// transform.localPosition == transform.position	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ��ġ
		// transform.localRotation == transform.rotation	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ȸ��
		// transform.localScale								: �θ�Ʈ�������� ���� ��� ���带 �������� �� ũ��
    
    }
}
