﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ResourceType Type;
}

public enum ResourceType
{
    LifeSupport, Waste
}
