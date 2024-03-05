using System.Collections.Concurrent;

namespace Concurrency.ChapterNine.ConcurrentDictionary;

public static class ConcurrentDictionaryExample
{
    public static void ExecuteConcurrentDictionaryExample()
    {
        var dictionary = new ConcurrentDictionary<int, string>();
        
        // key - ключ
        // addValueFactory - делегат, преобразующий ключ в значение, которое добавится в словарь (0 в "Zero")
        // делегат addValueFactory выполняется если ключ не существует в словаре
        // updateValueFactory - делегат, преобразующий ключ и старое значение в обновлённое значение
        // делегат updateValueFactory выполняется, если ключ уже существует в словаре
        // AddOrUpdate вернёт новое значение ключа
        var newValue = dictionary.AddOrUpdate(
            key:0, 
            addValueFactory:key => "Zero", 
            updateValueFactory:(key, oldValue) => "Zero");

        // Упрощённый синтаксис. Добавляет/обновляет ключ 1, связывая его со значением One
        dictionary[1] = "One";

        // Если ключ существует, isKeyExists = true, а currentValue будет содержать значение по ключу 
        // Если ключ не существует, isKeyExists = false, а currentValue будет содержать null 
        var isKeyExists = dictionary.TryGetValue(0, out var currentValue);

        // Получение по индексу лучше не использовать, ибо при отсутствии ключа будет сгенерировано исключение
        // System.Collections.Concurrent.ConcurrentDictionary`2.ThrowKeyNotFoundException(TKey key)
        var value = dictionary[2];
        
        // Удаление значения по аналогии:
        var wasKeyExist = dictionary.TryRemove(0, out var removedValue);
        
        // Не генерирует исключений
        var a = dictionary.Remove(5, out var deletedValue);
    }
}