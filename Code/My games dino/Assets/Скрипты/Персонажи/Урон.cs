using UnityEngine;

public class Урон : MonoBehaviour
{
    public Transform respawnPoint1; // Первая точка возрождения
    public Transform respawnPoint2; // Вторая точка возрождения
    public int collisionDamage;
    public string tagPlayer1;
    public string tagPlayer2;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(tagPlayer1) || coll.gameObject.CompareTag(tagPlayer2))
        {
            Здоровьеперсонажа healthManager1 = coll.gameObject.GetComponent<Здоровьеперсонажа>(); // Получаем компонент здоровья первого персонажа
            Здоровьеперсонажа healthManager2 = null;

            // Получаем компонент здоровья второго персонажа
            if (coll.gameObject.CompareTag(tagPlayer1))
                healthManager2 = GameObject.FindGameObjectWithTag(tagPlayer2)?.GetComponent<Здоровьеперсонажа>();
            else if (coll.gameObject.CompareTag(tagPlayer2))
                healthManager2 = GameObject.FindGameObjectWithTag(tagPlayer1)?.GetComponent<Здоровьеперсонажа>();

            // Проверяем, что оба компонента здоровья были найдены
            if (healthManager1 != null && healthManager2 != null)
            {
                // Применяем урон к обоим персонажам
                healthManager1.TakeDamage(collisionDamage);
                healthManager2.TakeDamage(collisionDamage);

                // Выбираем случайную точку возрождения
                Transform respawnPoint = Random.Range(0, 2) == 0 ? respawnPoint1 : respawnPoint2;

                // Перемещаем персонажей на выбранную точку возрождения
                healthManager1.transform.position = respawnPoint.position;
                healthManager2.transform.position = respawnPoint.position;

                // Сохраняем здоровье после получения урона (если требуется)
                SaveLoadManager.SavePlayerHealth(healthManager1.totalHealth);
                SaveLoadManager.SavePlayerHealth(healthManager2.totalHealth);
            }
        }
    }
}
