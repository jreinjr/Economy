using UnityEngine;
using UnityEngine.UI;
 
using UnityEditor;
 
// ---------------
//  String => Int
// ---------------
[UnityEditor.CustomPropertyDrawer(typeof(StringIntDictionary))]
public class StringIntDictionaryDrawer : SerializableDictionaryDrawer<string, int> {
    protected override SerializableKeyValueTemplate<string, int> GetTemplate() {
        return GetGenericTemplate<SerializableStringIntTemplate>();
    }
}
internal class SerializableStringIntTemplate : SerializableKeyValueTemplate<string, int> {}
 
// ---------------
//  GameObject => Float
// ---------------
[UnityEditor.CustomPropertyDrawer(typeof(GameObjectFloatDictionary))]
public class GameObjectFloatDictionaryDrawer : SerializableDictionaryDrawer<GameObject, float> {
    protected override SerializableKeyValueTemplate<GameObject, float> GetTemplate() {
        return GetGenericTemplate<SerializableGameObjectFloatTemplate>();
    }
}
internal class SerializableGameObjectFloatTemplate : SerializableKeyValueTemplate<GameObject, float> {}

// ---------------
//  Resource => Float
// ---------------
[UnityEditor.CustomPropertyDrawer(typeof(ResourceFloatDictionary))]
public class ResourceFloattDictionaryDrawer : SerializableDictionaryDrawer<Resource, float>
{
    protected override SerializableKeyValueTemplate<Resource, float> GetTemplate()
    {
        return GetGenericTemplate<SerializableResourceFloatTemplate>();
    }
}
internal class SerializableResourceFloatTemplate : SerializableKeyValueTemplate<Resource, float> { }

// ---------------
//  Task => Float
// ---------------
[UnityEditor.CustomPropertyDrawer(typeof(ResourceFloatDictionary))]
public class TaskFloattDictionaryDrawer : SerializableDictionaryDrawer<TaskType, float>
{
    protected override SerializableKeyValueTemplate<TaskType, float> GetTemplate()
    {
        return GetGenericTemplate<SerializableTaskFloatTemplate>();
    }
}
internal class SerializableTaskFloatTemplate : SerializableKeyValueTemplate<TaskType, float> { }
