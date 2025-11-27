using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/Terrorist_Bodyguard")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "Terrorist_Bodyguard", message: "[Terrorist] is attacking President", category: "Events", id: "ca9e3b586829e0de108043e50e8d0cb4")]
public sealed partial class TerroristBodyguard : EventChannel<GameObject> { }

