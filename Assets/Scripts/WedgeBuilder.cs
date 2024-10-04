using UnityEngine;

public class WedmgeBuilder : MonoBehaviour
{
    [Header("Настройки создание клина")]
    [Space(10)]

    [Tooltip("Ссылка на префаб (это объекты который будут построены клином)")]
    [SerializeField] private GameObject cubePrefab;

    [Space(3)]
    [Tooltip("Сколько объектов будет в самом начале клина")]
    [Range(0, 10)]
    [SerializeField] private int width = 5;
    [Tooltip("Расстояние между объектами")]
    [Space(3)]
    [Range(1, 2)]
    [SerializeField] private float spacing = 1.1f; 

    private void Start()
    {
        BuildWedge();
    }

    private void BuildWedge()
    {
        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < width - y; x++)
            {
                Vector3 position = new Vector3(x * spacing, y * spacing, 0);
                Instantiate(cubePrefab, position, Quaternion.identity);
            }
        }
    }
}