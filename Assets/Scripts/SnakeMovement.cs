using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SnakeMovement : MonoBehaviour
{
    public List<Transform> Tails;
    [Range(0, 3)]
    public float BonesDistance;
    public GameObject BonePrefab;
    [Range(0, 4)]

    private Transform _transform;
    

    public float Speed;
    public float Sensitivity = 10;
    public int Length = 4;
    public float speedX = 7;

    public UnityEvent OnEat;


    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        
        MoveSnake(transform.position + transform.forward * Speed * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = new Vector3(Input.GetAxis("Mouse X") * speedX * Time.deltaTime, 0, 0);
            transform.Translate(mouse * speedX);
        }
    }

    private void MoveSnake(Vector3 newPosition)
    {
        
        float sqrDistance = BonesDistance * BonesDistance;
        Vector3 previosPosition = _transform.position;

        foreach (var bone in Tails)
        {
            if ((bone.position - previosPosition).sqrMagnitude > sqrDistance)
            {
                var temp = bone.position;
                bone.position = previosPosition;
                previosPosition = temp;
            }
            else
            {
                break;
            }
        }
        _transform.position = newPosition;

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);

            var bone = Instantiate(BonePrefab);
            Tails.Add(bone.transform);

            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }
    }
}
