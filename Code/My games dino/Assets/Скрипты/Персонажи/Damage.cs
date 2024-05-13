using UnityEngine;

public class Damage : MonoBehaviour
{
    public Transform respawnPoint1; // Первая точка возрождения
    public Transform respawnPoint2; // Вторая точка возрождения
    public int collisionDamage;
    public string tagPlayer1;
    public string tagPlayer2;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<HealthHero>() != null)
        {
            HealthHero healthManager = coll.gameObject.GetComponent<HealthHero>(); // Получаем компонент здоровья первого персонажа
            HealthHero healthManager2 = null;

            if (coll.gameObject.CompareTag(tagPlayer1))
                healthManager2 = GameObject.FindGameObjectWithTag(tagPlayer2).GetComponent<HealthHero>();
            else if (coll.gameObject.CompareTag(tagPlayer2))
                healthManager2 = GameObject.FindGameObjectWithTag(tagPlayer1).GetComponent<HealthHero>();

            // Применяем урон к обоим персонажам
            healthManager.SetHealth(- collisionDamage);
    
                // Выбираем случайную точку возрождения
                Transform respawnPoint = Random.Range(0, 2) == 0 ? respawnPoint1 : respawnPoint2;

                // Перемещаем персонажей на выбранную точку возрождения
                healthManager.transform.position = respawnPoint.position;
                healthManager2.transform.position = respawnPoint.position;

                // Сохраняем здоровье после получения урона (если требуется)
                SaveLoadManager.SavePlayerHealth(HealthHero.totalHealth);
            
        }
    }
}
