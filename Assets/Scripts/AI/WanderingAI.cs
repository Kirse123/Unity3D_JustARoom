using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    private bool _alive;
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    //метод для проверки состояния моба (жив/мертв)
    public void SetAlive(bool state)
    {
        _alive = state;
    }

    void Start()
    {
        _alive = true;      //инициализация
    }

    void Update()
    {
        if (_alive)
        {     
            //постоянное передвижение
            transform.Translate(0, 0, speed * Time.deltaTime);
            //бросаем луч
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;    //получаем объект, в который попали
                //если это игрок, стреляем
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    //если на сцене нет снарядов, то запускаем
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;      //создаем снаряд из заготовки
                        //направляем снаряд на игрока
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);    
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                //ищем препятствие во время движении
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }
}
