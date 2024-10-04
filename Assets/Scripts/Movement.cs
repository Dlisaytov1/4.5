using UnityEngine;

public class PlayerMovement : MonoBehaviour                                   
{
    [Header("��������� ������������")]
    [Space(10)]

    [Tooltip("�������� ������������")]
    [Range(0, 10)]
    [SerializeField] private float _moveSpeed;
    [Space(3)]
    [Tooltip("������ �� ������ ���������")]
    [SerializeField] private Rigidbody2D _rb;

    private void Update()
    {      
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");
        _rb.velocity = new Vector2(horizontal * _moveSpeed, vertical * _moveSpeed);
    }
}