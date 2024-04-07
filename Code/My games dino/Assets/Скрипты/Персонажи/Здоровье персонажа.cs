using UnityEngine;
using UnityEngine.SceneManagement;

public class Здоровьеперсонажа : MonoBehaviour
{
    public int maxHealth; // Максимальное здоровье каждого персонажа
    public int totalHealth; // Текущее здоровье

    void Start()
    {
        totalHealth = maxHealth; // Установим здоровье при старте игры
    }

    public void TakeDamage(int damage)
    {
        totalHealth -= damage; // Уменьшаем здоровье при получении урона

        if (totalHealth <= 0)
        {
            Die(); // Если здоровье заканчивается, вызываем метод смерти
        }
    }

    public void SetHealth(int bonusHealth)
    {
        totalHealth += bonusHealth; // Увеличиваем здоровье при лечении

        if (totalHealth > maxHealth)
        {
            totalHealth = maxHealth; // Не даем здоровью превысить максимальное значение
        }
    }

    void Die()
    {
        // Удаляем персонажа из сцены
        Destroy(gameObject);
    }
}
