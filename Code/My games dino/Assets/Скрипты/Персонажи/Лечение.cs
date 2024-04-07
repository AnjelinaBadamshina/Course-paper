using UnityEngine;

public class Лечение : MonoBehaviour
{
    public int collisionHeal = 1; // Количество единиц здоровья, добавляемых при столкновении
    public string tagPlayer1;
    public string tagPlayer2; // Тег объекта, с которым взаимодействует этот объект лечения

    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Проверяем, столкнулся ли объект с объектом, имеющим указанный тег
        if (coll.gameObject.CompareTag(tagPlayer1) || coll.gameObject.CompareTag(tagPlayer2))
        {
            // Получаем компонент здоровья персонажа
            Здоровьеперсонажа health = coll.gameObject.GetComponent<Здоровьеперсонажа>();
            if (health != null)
            {
                // Вызываем метод лечения у компонента здоровья с передачей количества лечения
                health.SetHealth(collisionHeal);
            }

            // Уничтожаем объект лечения после использования
            Destroy(gameObject);
        }
    }
}