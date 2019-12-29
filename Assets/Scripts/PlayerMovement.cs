using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public Camera MainCamera;
    public float Speed = 5;
    public int Damage = 5;
    public float RotationSpeed = 5f;
    public bool OnlyKeyboard;

    public Vector2 _move;
    public Vector2 _mouse;
    public float _angle;

    private void Update()
    {
        if (OnlyKeyboard)
        {
            _angle = Input.GetAxis("Horizontal");
            _move.y = Input.GetAxis("Vertical");
        }
        else
        {
            _move.x = Input.GetAxis("Horizontal");
            _move.y = Input.GetAxis("Vertical");
            _mouse = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        Vector3 cameraPos = new Vector3(transform.position.x, transform.position.y, MainCamera.transform.position.z);
        MainCamera.transform.position = cameraPos;

    }

    private void FixedUpdate()
    {
        if (OnlyKeyboard)
        {
            float angle = Rigidbody.rotation * Mathf.Deg2Rad;
            _move.x = -_move.y * Mathf.Sin(angle);
            _move.y = _move.y * Mathf.Cos(angle);
            Rigidbody.MovePosition(Rigidbody.position + _move * Speed * Time.fixedDeltaTime);
            Rigidbody.rotation -= _angle * RotationSpeed;
        }
        else
        {
            Rigidbody.MovePosition(Rigidbody.position + _move * Speed * Time.fixedDeltaTime);
            Vector2 pointing = (_mouse - Rigidbody.position);
            float angle = Mathf.Atan2(pointing.y, pointing.x) * Mathf.Rad2Deg - 90f;
            Rigidbody.rotation = angle;
        }
    }

    private void OnGUI()
    {
        OnlyKeyboard = GUILayout.Toggle(OnlyKeyboard, "OnlyKeyboard");
    }
}
